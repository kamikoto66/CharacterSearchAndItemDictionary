using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterFlag : CharacterInfo
{
    public class Gem
    {
        [JsonProperty("slotNo")]
        public int _SlotNo;

        [JsonProperty("itemId")]
        public string _ItemId;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;

        [JsonProperty("itemAbility")]
        public string _ItemAbility;
    }


    [SerializeField]
    public class Flag
    {
        [JsonProperty("itemId")]
        public string _ItemId;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemAvailableLevel")]
        public int _ItemAvailableLevel;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;

        //강화?
        [JsonProperty("reinforce")]
        public int _Reinforce;

        [JsonProperty("itemAbility")]
        public string _ItemAbility;

        [JsonProperty("gems")]
        public List<Gem> _Gems;
    }

    [JsonProperty("flag")]
    public Flag _Flag;

    public new void Print()
    {
        base.Print();

        Debug.Log(_Flag._ItemName);

        foreach(var v in _Flag._Gems)
        {
            Debug.Log(v._SlotNo);
            Debug.Log(v._ItemId);
            Debug.Log(v._ItemName);
        }
    }
}
