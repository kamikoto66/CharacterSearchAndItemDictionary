using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterAvatar : CharacterInfo, IListToDictionary {

    [SerializeField]
    public class Emblems
    {
        [JsonProperty("slotNo")]
        public int _SlotNo;
        [JsonProperty("slotColor")]
        public string _SlotColor;
        [JsonProperty("itemName")]
        public string _ItemName;
        [JsonProperty("itemRarity")]
        public string _ItemRarity;
    }

    [SerializeField]
    public class Avatar
    {
        [JsonProperty("slotId")]
        public string _SlotId;

        [JsonProperty("slotName")]
        public string _SlotName;

        [JsonProperty("itemId")]
        public string _ItemId;

        [JsonProperty("itemName")]
        public string _ItemName;

        [JsonProperty("itemRarity")]
        public string _ItemRarity;

        [JsonProperty("cloneAvatarName")]
        public string _CloneAvatarName;

        [JsonProperty("optionAbility")]
        public string _OptionAbility;

        [JsonProperty("emblems")]
        public ReadOnlyCollection<Emblems> _Emblems;
    }

    [JsonProperty("avatar")]
    public ReadOnlyCollection<Avatar> _Avatar;

    public Dictionary<string, Avatar> _AvatarDictionary;

    public new void Print()
    {
        base.Print();

        foreach(var v in _Avatar)
        {
            Debug.Log(v._ItemName);

            foreach(var vv in v._Emblems)
            {
                Debug.Log(vv._ItemName);
            }
        }
    }

    public void ListToDictionary()
    {
        _AvatarDictionary = new Dictionary<string, Avatar>();

        foreach (var avatar in _Avatar)
        {
            string Name = avatar._SlotName;

            if(!_AvatarDictionary.ContainsKey(Name))
            {
                _AvatarDictionary.Add(Name, avatar);
            }
        }
    }
}
