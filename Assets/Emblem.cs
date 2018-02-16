using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emblem : UI {

    public enum EmblemType
    {
        Emblem_2,
        Emblem_3
    }


    private EmblemType _Type;
    private CharacterAvatar.Avatar _Avatar;
    private List<string> _UINames = new List<string> { "slotName", "Name", "optionAbility", "1", "2", "3"};

    public void SetUp(EmblemType type, CharacterAvatar.Avatar avatar)
    {
        _Type = type;
        _Avatar = avatar;
        SetUp();
    }

    private void SetUp()
    {
        string[] SlotNames = _Avatar._SlotName.Split();
        Vars[_UINames[0]].GetComponent<Text>().text = SlotNames[0];

        Vars[_UINames[1]].GetComponent<Text>().text = _Avatar._ItemName;

        if (_Avatar._OptionAbility != null)
            Vars[_UINames[2]].GetComponent<Text>().text = _Avatar._OptionAbility;

        if (_Avatar._Emblems.Count > 0)
            Vars[_UINames[3]].GetComponent<Text>().text = _Avatar._Emblems[0]._ItemName;

        if (_Avatar._Emblems.Count > 1)
            Vars[_UINames[4]].GetComponent<Text>().text = _Avatar._Emblems[1]._ItemName;

        if (_Type == EmblemType.Emblem_3 && _Avatar._Emblems != null)
            Vars[_UINames[5]].GetComponent<Text>().text = _Avatar._Emblems[2]._ItemName;
    }
}
