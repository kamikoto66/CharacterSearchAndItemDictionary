using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : UI {

    private CharacterEquipment.Equipment _Equipment;
    private Text _SlotName;
    private Text _Name;
    private Text _Reinforce;

	// Use this for initialization
	private void Init() {
    }

    public GameObject SetUp(CharacterEquipment.Equipment Equi)
    {
        _SlotName = Vars["Index"].GetComponentInChildren<Text>();
        _Name = Vars["Name"].GetComponentInChildren<Text>();
        _Reinforce = Vars["Reinforce"].GetComponentInChildren<Text>();

        _Equipment = Equi;

        string s = ReinforceSetting();

        _SlotName.text = _Equipment._SlotName;
        _Name.text = _Equipment._ItemName;
        _Reinforce.text = s;

        NameSetting();

        return this.gameObject;
    }

    private string ReinforceSetting()
    {
        string output = "- ";

        if(_Equipment._AmplificationName == null && _Equipment._Reinforce > 0)
        {
            output = "+" + _Equipment._Reinforce.ToString() +"강화";
        }

        if(_Equipment._AmplificationName != null && _Equipment._Reinforce > 0)
        {
            output = "+" + _Equipment._Reinforce.ToString() + "증폭";
            _Reinforce.color = new Color(1, 0, 1, 1);
        }

        if (_Equipment._SlotName.Equals("무기") && _Equipment._Refine > 0)
        {
            output += "(" + _Equipment._Refine.ToString() + ")";
            _Reinforce.color = new Color(1, 0, 1, 1);
        }

        return output;
    }

    private void NameSetting()
    {
        Color color=new Color();

        switch (_Equipment._ItemRarity)
        {
            case "에픽":
                ColorUtility.TryParseHtmlString("#ffd700", out color);
                break;
            case "레전더리":
                ColorUtility.TryParseHtmlString("#ff8c00", out color);
                break;
            case "크로니클":
                ColorUtility.TryParseHtmlString("#D45555FF", out color);
                break;
            case "레어":
                ColorUtility.TryParseHtmlString("#4169e1", out color);
                break;
            case "유니크":
                color = new Color(1, 0, 1, 1);
                break;
            case "언커먼":
                ColorUtility.TryParseHtmlString("#87cefa", out color);
                break;
            case "커먼":
                color = Color.black;
                break;
        }

        _Name.color = color;

    }
}
