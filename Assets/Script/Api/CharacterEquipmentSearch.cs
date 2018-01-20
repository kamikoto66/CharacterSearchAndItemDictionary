using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class CharacterEquipmentSearch : DnfApiBase
{
    string _CharacterCode;

    public void SearchUrl(Server server, string chracterCode)
    {
        _Server = server;
        _CharacterCode = chracterCode;

        StartCoroutine(SearchData());
    }

    protected override IEnumerator SearchData()
    {
        string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        Url += "/characters/" + _CharacterCode;
        Url += "/equip/equipment?";
        Url += "apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterEquipment>(www.text);

        json.Print();
    }
}