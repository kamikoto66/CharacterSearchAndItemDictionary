using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour {

    private CharacterSerch.Data _Data;

    public CharacterSerch.Data Data
    {
        get
        {
            return _Data;
        }

        set
        {
            _Data = value;
        }
    }	
}
