using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class SearchcharacterInfo : DnfApiBase {

    //public RectTransform _Content;

    public void SearchUrl(Server server, string characterName, GameObject ServerControl)
    {
        if(characterName.Length == 1)
            _WorldType = worldType.macth;
        else
            _WorldType = worldType.full;
        
        string CharacterNameUrl = WWW.EscapeURL(characterName, System.Text.Encoding.UTF8);
        string Url = "https://api.neople.co.kr/df/servers/" + server.ToString();
        Url += "/characters?characterName=" + CharacterNameUrl;
        Url += "&limit=10";
        Url += "&wordType=" + _WorldType.ToString();
        Url += "&apikey=" + ApiKey;

        StartCoroutine(SearchCharacterData(Url, ServerControl));
    }

    protected IEnumerator SearchCharacterData(string url, GameObject ServerControl)
    {
        WWW www = new WWW(url);
        yield return www;

        var json = Newtonsoft.Json.JsonConvert.DeserializeObject<CharacterSerch>(www.text);

        if(json.rows.Count != 0 && json != null)
        {
            var Result = Instantiate(Resources.Load<GameObject>("Prefabs/Result"));
            Result.transform.SetParent(GameObject.Find("Canvas").transform);
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
                UserInfo.GetComponentInChildren<Text>().text = UserInfoText;
                UserInfo.transform.SetParent(Content);
                UserInfo.transform.localPosition = pos;

                pos.y -= 170.0f;
            }

            int childCount = Content.childCount;

            var size = Content.sizeDelta;
            size.Set(size.x, size.y + childCount*150.0f);
            Content.sizeDelta = size;

            Result.GetComponent<Result>().ServerControl = ServerControl;
            ServerControl.SetActive(false);
        }
        else
        {
            //팝업창

        }

        Destroy(this.gameObject);
        StopAllCoroutines();

        //나중에
        //string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        //Url += "/characters/" + characterId;
        //Url += "?apikey=" + ApiKey;

        //WWW www = new WWW(Url);
        //yield return www;

        //var JsonData = JsonConvert.DeserializeObject<CharacterInfo>(www.text);

        //JsonData.Print();
        //GameObject.Find("Response").GetComponent<Text>().text = www.text;
    }
}
