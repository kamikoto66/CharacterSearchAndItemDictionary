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

    public WorldType _WorldType;
    protected Server _Server;
    protected string ApiKey = "kY6CeAILmIU4TKUufr1yaX4MNElGRMEh";

    protected abstract IEnumerator SearchData();
}
