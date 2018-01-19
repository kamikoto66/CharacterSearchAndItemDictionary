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

    public enum worldType
    {
        macth,
        front,
        full
    };

    public worldType _WorldType;
    protected string ApiKey = "kY6CeAILmIU4TKUufr1yaX4MNElGRMEh";
}
