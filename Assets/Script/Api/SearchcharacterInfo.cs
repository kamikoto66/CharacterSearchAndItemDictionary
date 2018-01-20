using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class SearchcharacterInfo : DnfApiBase {

    private string _CharacterName;
    private GameObject _ServerControl;

    public void SearchUrl(Server server, string characterName, GameObject ServerControl)
    {
        _Server = server;
        _CharacterName = characterName;
        _ServerControl = ServerControl;

        StartCoroutine(SearchData());
    }

    protected override IEnumerator SearchData()
    {
        if (_CharacterName.Length == 1)
            _WorldType = WorldType.macth;
        else
            _WorldType = WorldType.full;

        string CharacterNameUrl = WWW.EscapeURL(_CharacterName, System.Text.Encoding.UTF8);
        string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        Url += "/characters?characterName=" + CharacterNameUrl;
        Url += "&limit=200";
        Url += "&wordType=" + _WorldType.ToString();
        Url += "&apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterSerch>(www.text);

        if(json.rows.Count != 0 && json != null)
        {
            var Result = Instantiate(Resources.Load<GameObject>("Prefabs/Result"));
            Result.transform.SetParent(GameObject.Find("Canvas-UIManager").transform);
            Result.transform.localPosition = Vector2.zero;

            RectTransform Content = Result.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();

            Vector3 pos = new Vector3(350.0f, -150.0f, 0.0f);

            foreach (var user in json.rows)
            {
                string UserInfoText = "";

                CharacterSerch.Data userData = new CharacterSerch.Data(user);
                UserInfoText += userData.characterName;
                UserInfoText += "/Lv." + userData.level.ToString();
                UserInfoText += "/" + userData.jobGrowName;

                var UserInfo = Instantiate(Resources.Load<GameObject>("Prefabs/UserInfo"));
                UserInfo.GetComponent<UserInfo>().Data = userData;
                UserInfo.GetComponent<UserInfo>().Server = _Server;
                UserInfo.GetComponentInChildren<Text>().text = UserInfoText;
                UserInfo.transform.SetParent(Content);
                UserInfo.transform.localPosition = pos;

                pos.y -= 170.0f;
            }

            int childCount = Content.childCount;

            var size = Content.sizeDelta;
            size.Set(size.x, size.y + childCount*150.0f);
            Content.sizeDelta = size;

            UIStack.Instance.PushUI(Result);
        }
        else
        {
            //팝업창
            UIManager.OpenUI<PopUp>("Prefabs/PopUp");
        }

        Destroy(this.gameObject);
        StopAllCoroutines();
    }
}
