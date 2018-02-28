using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


        if (json != null && json._Creature != null)
        {
            var Canvas = FindObjectOfType<Canvas>().transform;

            var equipment = Instantiate(Resources.Load<GameObject>("Prefabs/Character/CreaturePage"));
            equipment.transform.SetParent(Canvas.transform);
            equipment.transform.localPosition = new Vector3(0.0f, -30.0f, 0.0f);
            UIStack.Instance.PushUI(equipment);

            equipment.GetComponent<CreaturePage>().StartCoroutine(equipment.GetComponent<CreaturePage>().SpriteLoad(json._Creature._ItemId));
            equipment.GetComponent<UI>().Vars["Name"].GetComponentInChildren<Text>().text = json._Creature._ItemName;
            equipment.GetComponent<UI>().Vars["Skill"].GetComponentInChildren<Text>().text = json._Creature._Skill._Description;
            equipment.GetComponent<UI>().Vars["OverSkill"].GetComponentInChildren<Text>().text = json._Creature._OverSkill._Description;

            json.Print();
        }
        else
        {
            //팝업창
            UIManager.OpenUI<PopUp>("Prefabs/PopUp");
        }


        Destroy(this.gameObject);
    }
}
