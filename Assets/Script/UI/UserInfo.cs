using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour {

    private Server _Server;
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

    public Server Server
    {
        get { return _Server; }
        set { _Server = value; }
    }

    private void Start()
    {
        UIHelper.AddButtonListener(GetComponent<Button>(), () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/CharacterInfoSearch")).GetComponent<CharacterInfoSearch>().SearchUrl(_Data, _Server);
        });
    }
}
