using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CharacterAbilitySearch : DnfApiBase{

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
        json.ListToDictionary();

        if(json != null)
        {
            var Canvas = FindObjectOfType<Canvas>().transform;

            var AbilityPage = Instantiate(Resources.Load<GameObject>("Prefabs/Character/AbilityPage"));
            AbilityPage.transform.SetParent(Canvas.transform);
            AbilityPage.transform.localPosition = Vector3.zero;
            UIStack.Instance.PushUI(AbilityPage);

            var AbilityUI = AbilityPage.GetComponent<UI>();

            foreach(var ability in _Ability)
            {
                var status = json._Ability[ability];

                AbilityUI.Vars[ability].GetComponent<Text>().text = status._Value.ToString();
            }

            string buffs = "";

            foreach(var buff in json._Buffs)
            {
                buffs += buff._Name;
                if (buff._Level > 0)
                    buffs += " Lv." + buff._Level.ToString() + " ";
                else
                    buffs += " ";
            }

            AbilityUI.Vars["Text"].GetComponent<Text>().text = buffs;
        }
        Destroy(this.gameObject);
    }
}
