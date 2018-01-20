using UnityEngine;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[SerializeField]
public class CharacterEquipment : CharacterInfo
{
    [SerializeField]
    public class Equipment
    {
        [JsonProperty("slotId")]
        public string _SlotId;

        [JsonProperty("slotName")]
        public string _SlotName;

        [JsonProperty("itemId")]
        public string _ItemId;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemType")]
        public string _ItemType;

        [JsonProperty("itemTypeDetail")]
        public string _ItemTypeDetail;

        [JsonProperty("itemAvailableLevel")]
        public int _ItemAvailableLevel;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;

        [JsonProperty("setItemName")]
        public string _SetItemName;

        [JsonProperty("reinforce")]
        public int _Reinforce;

        [JsonProperty("refine")]
        public int _Refine;

        [JsonProperty("amplificationName")]
        public string _AmplificationName;
    }

    [JsonProperty("equipment")]
    public ReadOnlyCollection<Equipment> _Equipment;

    public new void Print()
    {
        base.Print();

        foreach(var v in _Equipment)
        {
            Debug.Log(v._ItemName);
        }

    }
}