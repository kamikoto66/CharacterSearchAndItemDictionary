using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterCreature : CharacterInfo {

    [SerializeField]
    public class Skill
    {
        [JsonProperty("name")]
        public string _Name;

        [JsonProperty("description")]
        public string _Description;

        [JsonProperty("cooldownTime")]
        public int _CooldownTime;

        [JsonProperty("level")]
        public int _Level;

        [JsonProperty("levelupCondition")]
        public string _LevelupCondition;
    }

    [SerializeField]
    public class Artifact
    {
        [JsonProperty("slotColor")]
        public string _SlotColor;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemAvailableLevel")]
        public int _ItemAvailableLevel;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;
    }

    [SerializeField]
    public class Creature
    {
        [JsonProperty("itemId")]
        public string _ItemId;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;

        [JsonProperty("itemAbility")]
        public string _ItemAbility;

        [JsonProperty("optionAbility")]
        public string _OptionAbility;

        [JsonProperty("Skill")]
        public Skill _Skill;

        [JsonProperty("overskill")]
        public Skill _OverSkill;

        [JsonProperty("artifact")]
        public ReadOnlyCollection<Artifact> _Artifact;
    }

    [JsonProperty("creature")]
    public Creature _Creature;

    public new void Print()
    {
        base.Print();

        Debug.Log(_Creature._ItemName);

        foreach(var v in _Creature._Artifact)
        {
            Debug.Log(v._ItemName);
        }

        Debug.Log(_Creature._Skill._Name + "|" + _Creature._Skill._Description);
        Debug.Log(_Creature._OverSkill._Name + "|" + _Creature._OverSkill._Description);

    }
}
