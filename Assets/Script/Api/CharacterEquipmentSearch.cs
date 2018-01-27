using Newtonsoft.Json;
using System.Collections;
using UnityEngine;

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
        json.Test();

        var Canvas = FindObjectOfType<Canvas>().transform;

        var Equiment = Instantiate(Resources.Load<GameObject>("Prefabs/Equipment"));
        Equiment.transform.SetParent(Canvas.transform);

        //var content = UIStack.Instance.PushUI();
        //var Equipment = Instantiate(Resources.Load<GameObject>("Prefabs/Equipment"));
        //Equipment.transform.SetParent(GameObject.Find("Holder").transform);
        //UIStack.Instance.PushUI(Equipment);

        //foreach (var s in _SlotName)
        //{
        //    CharacterEquipment.Equipment Equi = json._Equipment[s];

        //    GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Item"));
        //    obj.GetComponent<Item>().SetUp(Equi);
        //    obj.transform.SetParent(Equipment.transform.Find("Content"));
        //    obj.transform.position = Vector3.zero;
        //}

        Debug.Log(www.text);
        json.Print();
    }
}