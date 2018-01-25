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
	void Start () {
        _SlotName = Vars["Index"].GetComponentInChildren<Text>();
        _Name = Vars["Name"].GetComponentInChildren<Text>();
        _Reinforce= Vars["reinforce"].GetComponentInChildren<Text>();
    }

    public GameObject SetUp(CharacterEquipment.Equipment Equi)
    {
        _Equipment = Equi;

        string s = Test(_Equipment._AmplificationName.StartsWith("차원"), _Equipment._SlotName.Equals("무기"));

        _SlotName.text = _Equipment._SlotName;
        _Name.text = _Equipment._ItemName;
        _Reinforce.text = s;

        return this.gameObject;
    }

    private string Test(bool Amplification, bool Slot)
    {
        string output = "-";

        if(_Equipment._Reinforce > 0)
        {
            output += "+" + _Equipment._Reinforce.ToString() +"강화";
        }

        if(Amplification && _Equipment._Reinforce > 0)
        {
            output += "+" + _Equipment._Reinforce.ToString() + "재련";
        }

        if (Slot.Equals("무기") && _Equipment._Refine > 0)
        {
            output += "(" + _Equipment._Refine.ToString() + ")";
        }

        return output;
    }
}
