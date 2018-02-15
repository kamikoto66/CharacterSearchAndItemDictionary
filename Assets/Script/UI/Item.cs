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

        string s = Test();

        _SlotName.text = _Equipment._SlotName;
        _Name.text = _Equipment._ItemName;
        _Reinforce.text = s;

        return this.gameObject;
    }

    private string Test()
    {
        string output = "- ";

        if(_Equipment._AmplificationName == null && _Equipment._Reinforce > 0)
        {
            output = "+" + _Equipment._Reinforce.ToString() +"강화";
        }

        if(_Equipment._AmplificationName != null && _Equipment._Reinforce > 0)
        {
            output = "+" + _Equipment._Reinforce.ToString() + "증폭";
        }

        if (_Equipment._SlotName.Equals("무기") && _Equipment._Refine > 0)
        {
            output += "(" + _Equipment._Refine.ToString() + ")";
        }

        return output;
    }
}
