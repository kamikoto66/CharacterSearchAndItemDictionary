using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterAbility : CharacterInfo
{
    [SerializeField]
    public class Status
    {
        [JsonProperty("name")]
        public string _Name;
        [JsonProperty("value")]
        public int _Value;
    }

    [SerializeField]
    public class Buff
    {
        [JsonProperty("name")]
        public string _Name;
        [JsonProperty("level")]
        public int _Level;
        [JsonProperty("status")]
        public ReadOnlyCollection<Status> _Status;
    }

    [JsonProperty("buff")]
    public ReadOnlyCollection<Buff> _Buffs;

    [JsonProperty("status")]
    public ReadOnlyCollection<Status> _Status;

    public new void Print() 
    {
        base.Print();

        foreach(var v in _Buffs)
        {
            Debug.Log(v);
        }

        foreach(var v in _Status)
        {
            Debug.Log(v);
        }
    }
}

