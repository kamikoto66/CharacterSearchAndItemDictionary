﻿using System.Collections;
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
        //장착장비 검색
        UIHelper.AddButtonListener(Vars["장착장비"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/Api/CharacterEquipmentSearch")).GetComponent<CharacterEquipmentSearch>().SearchUrl(_Server, _CharacterCode);
        });

        //능력치 검색
        UIHelper.AddButtonListener(Vars["능력치"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/Api/CharacterAbilitySearch")).GetComponent<CharacterAbilitySearch>().SearchUrl(_Server, _CharacterCode);
        });

        //아바타 검색
        UIHelper.AddButtonListener(Vars["아바타"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/Api/CharacterAvatarSearch")).GetComponent<CharacterAvatarSearch>().SearchUrl(_Server, _CharacterCode);
        });

        //크리쳐 검색
        UIHelper.AddButtonListener(Vars["크리쳐"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/Api/CharacterCreatureSearch")).GetComponent<CharacterCreatureSearch>().SearchUrl(_Server, _CharacterCode);
        });

        //휘장 검색
        UIHelper.AddButtonListener(Vars["휘장"], () => {
            Instantiate(Resources.Load<GameObject>("Prefabs/Api/CharacterFlagSearch")).GetComponent<CharacterFlagSearch>().SearchUrl(_Server, _CharacterCode);
        });

        //뒤로가기 키
        UIHelper.AddButtonListener(Vars["back"], () => { UIStack.Instance.PopUI(); });
    }
}
