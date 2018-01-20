using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoSearch : DnfApiBase {

    private CharacterSerch.Data _UserData;
    private Server _Server;

    public void SearchUrl(CharacterSerch.Data data, Server server)
    {
        _UserData = data;
        _Server = server;

        StartCoroutine(SearchData());
    }

    protected override IEnumerator SearchData()
    {
        string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        Url += "/characters/" + _UserData.characterId;
        Url += "?apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var JsonData = JsonConvert.DeserializeObject<CharacterInfo>(www.text);
        var Canvas = GameObject.FindObjectOfType<Canvas>();

        if(JsonData != null)
        {
            var obj = Instantiate(Resources.Load<GameObject>("Prefabs/Character"));
            obj.GetComponent<Character>().Server = _Server;
            obj.GetComponent<Character>().CharacterCode = _UserData.characterId;

            obj.transform.SetParent(Canvas.transform);
            obj.transform.localPosition = Vector3.zero;

            UIStack.Instance.PushUI(obj);

            JsonData.Print();
        }
    }
}
