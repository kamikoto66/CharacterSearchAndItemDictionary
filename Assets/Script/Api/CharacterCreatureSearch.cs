﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CharacterCreatureSearch : DnfApiBase {

    private string _CharacterCode;

    public void SearchUrl(Server server, string characterCode)
    {
        _Server = server;
        _CharacterCode = characterCode;

        StartCoroutine(SearchData());
    }


    protected override IEnumerator SearchData()
    {
        string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        Url += "/characters/" + _CharacterCode;
        Url += "/equip/creature?";
        Url += "apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterCreature>(www.text);

        json.Print();
    }
}