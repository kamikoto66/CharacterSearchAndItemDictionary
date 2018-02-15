using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterAbility : CharacterInfo, IListToDictionary
{
    [SerializeField]
    public class Status
    {
        [JsonProperty("name")]
        public string _Name;

        [JsonProperty("value")]
        public float _Value;
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

    public Dictionary<string, Status> _Ability;

    public new void Print() 
    {
        //base.Print();
        foreach (var buff in _Buffs)
        {
            Debug.Log(buff._Name);
        }

        foreach (var status in _Status)
        {
            Debug.Log(status._Name);
            Debug.Log(status._Value);
        }
    }

    public void ListToDictionary()
    {
        _Ability = new Dictionary<string, Status>();

        foreach (var status in _Status)
        {
            string index = status._Name;

            if (!_Ability.ContainsKey(index))
            {
                _Ability.Add(index, status);
            }
        }
    }
}

