using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

        if(json != null)
        {
            json.ListToDictionary();

            var Canvas = FindObjectOfType<Canvas>().transform;

            var equipment = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Equipment"));
            equipment.transform.SetParent(Canvas.transform);
            equipment.transform.localPosition = Vector3.zero;
            UIStack.Instance.PushUI(equipment);

            RectTransform content = equipment.GetComponent<UI>().Vars["Content"].transform as RectTransform;
            var Name = equipment.GetComponent<UI>().Vars["Name"].GetComponentInChildren<Text>().text = json.characterName + "\n" + "Lv." + json.level.ToString() + "|" + json.jobName + "|" + GetServer(_Server);


            foreach (var s in _SlotName)
            {
                if (json._Equipment.ContainsKey(s))
                {
                    CharacterEquipment.Equipment Equi = json._Equipment[s];

                    GameObject obj = Instantiate(Resources.Load<GameObject>("Prefabs/Character/Item"));
                    obj.GetComponent<Item>().SetUp(Equi);
                    obj.GetComponent<Item>().SpriteLoad();
                    obj.transform.SetParent(content);
                }
            }

            var size = content.sizeDelta;
            size.y = content.transform.childCount * 50.0f;
            content.sizeDelta = size;
        }

        Destroy(this.gameObject);
    }
}