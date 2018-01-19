using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Newtonsoft.Json;

[SerializeField]
public class CharacterSerch
{
    [SerializeField]
    public class Data
    {
        public Data()
        {
            characterId = "";
            characterName = "";
            level = 0;
            jobId = "";
            jobGrowId = "";
            jobName = "";
            jobGrowName = "";
        }

        public Data(Data data)
        {
            characterId = data.characterId;
            characterName = data.characterName;
            level = data.level;
            jobId = data.jobId;
            jobGrowId = data.jobGrowId;
            jobName = data.jobName;
            jobGrowName = data.jobGrowName;
        }

        [JsonProperty("characterId")]
        public string characterId;

        [JsonProperty("characterName")]
        public string characterName;

        [JsonProperty("level")]
        public int level;

        [JsonProperty("jobId")]
        public string jobId;

        [JsonProperty("jobGrowId")]
        public string jobGrowId;

        [JsonProperty("jobName")]
        public string jobName;

        [JsonProperty("jobGrowName")]
        public string jobGrowName;
    }

    [JsonProperty("rows")]
    public List<Data> rows;
}
