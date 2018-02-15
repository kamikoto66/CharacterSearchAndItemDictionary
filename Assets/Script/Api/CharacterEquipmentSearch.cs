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
        json.ListToDictionary();

        var Canvas = FindObjectOfType<Canvas>().transform;

        var equipment = Instantiate(Resources.Load<GameObject>("Prefabs/Equipment"));
        equipment.transform.SetParent(Canvas.transform);
        equipment.transform.localPosition = Vector3.zero;
        UIStack.Instance.PushUI(equipment);

        RectTransform content = equipment.GetComponent<UI>().Vars["Content"].transform as RectTransform;
        Vector3 position = new Vector3(0f, 140f, 0f);

        foreach (var s in _SlotName)
        {
            Debug.Log(s);

            if(json._Equipment.ContainsKey(s))
            {
                CharacterEquipment.Equipment Equi = json._Equipment[s];

                GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Item"));
                obj.GetComponent<Item>().SetUp(Equi);
                obj.transform.SetParent(content);
                obj.transform.localPosition = position;

                position.y -= 100f;
            }
 
        }
    }
}