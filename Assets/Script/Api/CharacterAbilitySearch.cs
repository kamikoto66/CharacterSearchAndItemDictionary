using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CharacterAbilitySearch : DnfApiBase{

    private Server _Server;
    private string _CharacterCode;

    public void SearchUrl(Server server, string chracterCode)
    {
        _Server = server;
        _CharacterCode = chracterCode;

        StartCoroutine(SearchData());
    }

    protected override IEnumerator SearchData()
    {
        string Url = "https://api.neople.co.kr/df/";
        Url += "servers/" + _Server.ToString();
        Url += "/characters/" + _CharacterCode;
        Url += "/status?";
        Url += "apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterAbility>(www.text);

        if(json != null)
        {

            json.Print();
        }

    }
}
