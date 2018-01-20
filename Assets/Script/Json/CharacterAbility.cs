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

    public new void Print() 
    {
        base.Print();

        foreach(var v in _Buffs)
        {
            Debug.Log(v._Name);
            Debug.Log(v._Level);

            foreach(var vv in v._Status)
            {
                Debug.Log(vv._Name);
                Debug.Log(vv._Value);
            }
        }
    }
}

