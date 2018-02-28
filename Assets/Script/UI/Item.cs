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
            _Reinforce.color = new Color(128, 0, 128, 255);
        }

        if (_Equipment._SlotName.Equals("무기") && _Equipment._Refine > 0)
        {
            output += "(" + _Equipment._Refine.ToString() + ")";
        }

        return output;
    }

    private void NameSetting()
    {
        switch (_Equipment._ItemRarity)
        {
            case "에픽":
                Debug.Log(new Color(255, 215, 0));
                //_Name.color.
                break;
            case "레전더리":
                //_Name.color = new Color(255.0f,140.0f,0.0f);
                break;
            case "레어":
                _Name.color = Color.blue;
                break;
        }
    }
}
