using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : UI {

    private Server _Server;
    private string _CharacterCode;

    public Server Server
    {
        get { return _Server; }
        set { _Server = value; }
    }

    public string CharacterCode
    {
        get { return _CharacterCode; }
        set { _CharacterCode = value; }
    }

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["장착장비"], () => {
        });
        UIHelper.AddButtonListener(Vars["능력치"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/CharacterAbilitySearch")).GetComponent<CharacterAbilitySearch>().SearchUrl(_Server, _CharacterCode);
        });
        UIHelper.AddButtonListener(Vars["아바타"], () => { });
        UIHelper.AddButtonListener(Vars["크리쳐"], () => { });
        UIHelper.AddButtonListener(Vars["휘장"], () => { });
        UIHelper.AddButtonListener(Vars["back"], () => { UIStack.Instance.PopUI(); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
