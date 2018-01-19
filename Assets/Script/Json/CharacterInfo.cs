using UnityEngine;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

[SerializeField]
public class CharacterInfo
{
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

    [JsonProperty("adventureName")]
    public string adventureName;

    [JsonProperty("guildId")]
    public string guildId;

    [JsonProperty("guildName")]
    public string guildName;

    public void Print()
    {
        Debug.Log("characterId: " + characterId + "characterName: " + characterName + "level: " + level.ToString()
            + "jobId: " + jobId + "jobGrowId: " + jobGrowId + "jobName: " + jobName + "jobGrowName: " + jobGrowName 
            + "adventureName: " + adventureName + "guildId: " + guildId + "guildName: " + guildName);
    }
}