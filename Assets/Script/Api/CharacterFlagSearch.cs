using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class CharacterFlagSearch : DnfApiBase
{
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
        Url += "/equip/flag?";
        Url += "apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterFlag>(www.text);

        if (json != null && json._Flag != null)
        {
            var Canvas = FindObjectOfType<Canvas>().transform;

            var FlagPage = Instantiate(Resources.Load<GameObject>("Prefabs/Character/FlagPage"));
            FlagPage.transform.SetParent(Canvas.transform);
            FlagPage.transform.localPosition = new Vector3(0.0f, -30.0f, 0.0f);
            UIStack.Instance.PushUI(FlagPage);

            var flag = FlagPage.GetComponent<FlagPage>();
            flag.Vars["Flag"].GetComponent<Gem>().Name = json._Flag._ItemName;
            flag.Vars["Flag"].GetComponent<Gem>().Description = json._Flag._ItemAbility;

            var flagCoroutine = flag.StartCoroutine(flag.SpriteLoad("Flag", json._Flag._ItemId));
            flag._Coroutines.Add("Flag", flagCoroutine);

            foreach (var gem in json._Flag._Gems)
            {
                var gemCoroutine = flag.StartCoroutine(flag.SpriteLoad(gem._SlotNo.ToString(), gem._ItemId));
                flag._Coroutines.Add(gem._SlotNo.ToString(), gemCoroutine);

                flag.Vars[gem._SlotNo.ToString()].GetComponent<Gem>().Name = gem._ItemName;
                flag.Vars[gem._SlotNo.ToString()].GetComponent<Gem>().Description = gem._ItemAbility;
            }

            FlagPage.GetComponent<UI>().Vars["FlagName"].GetComponentInChildren<Text>().text = json._Flag._ItemName;
            FlagPage.GetComponent<UI>().Vars["Name"].GetComponentInChildren<Text>().text = json._Flag._ItemName;
            FlagPage.GetComponent<UI>().Vars["Description"].GetComponentInChildren<Text>().text = json._Flag._ItemAbility;

            json.Print();
        }
        else
        {
            UIManager.OpenUI<PopUp>("Prefabs/PopUp");
        }
    }
}
