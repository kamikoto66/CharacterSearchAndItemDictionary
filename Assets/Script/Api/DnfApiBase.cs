using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Server
{
    anton,
    bakal,
    cain,
    casillas,
    diregie,
    hillder,
    prey,
    siroco
};


public abstract class DnfApiBase : MonoBehaviour {

    public enum WorldType
    {
        macth,
        front,
        full
    };

    public List<string> _SlotName = new List<string> { "무기", "칭호","머리어깨", "상의", "하의", "허리", "신발", "팔찌", "목걸이", "반지", "보조장비", "마법석", "귀걸이", "보조무기" };


    public WorldType _WorldType;
    protected Server _Server;
    protected string ApiKey = "kY6CeAILmIU4TKUufr1yaX4MNElGRMEh";

    protected abstract IEnumerator SearchData();
}
