using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class CharacterAvatarSearch : DnfApiBase
{
    private string _CharacterCode;

    public void SearchUrl(Server server, string characterCode)
    {
        _Server = server;
        _CharacterCode = characterCode;

        StartCoroutine(SearchData());
    }


    protected override IEnumerator SearchData()
    {
        string Url = "https://api.neople.co.kr/df/servers/" + _Server.ToString();
        Url += "/characters/" + _CharacterCode;
        Url += "/equip/avatar?";
        Url += "apikey=" + ApiKey;

        WWW www = new WWW(Url);
        yield return www;

        var json = JsonConvert.DeserializeObject<CharacterAvatar>(www.text);
        json.ListToDictionary();

        if(json != null)
        {
            var Canvas = FindObjectOfType<Canvas>().transform;

            var EmblemPage = Instantiate(Resources.Load<GameObject>("Prefabs/EmblemPage"));
            EmblemPage.transform.SetParent(Canvas.transform);
            EmblemPage.transform.localPosition = new Vector3(0f, -30f, 0f);

            RectTransform content = EmblemPage.GetComponent<UI>().Vars["Content"].transform as RectTransform;
            Vector3 position = new Vector3(-40f, 470f, 0f);

            foreach (var avatar in json._AvatarDictionary)
            {
                CharacterAvatar.Avatar value = avatar.Value;
                Emblem.EmblemType type = Emblem.EmblemType.Emblem_2;

                if (value._ItemRarity.Equals("레어") && (value._SlotName.Equals("상의 아바타") || value._SlotName.Equals("하의 아바타"))){
                    type = Emblem.EmblemType.Emblem_3;
                }

                GameObject AvatarObject = Instantiate(Resources.Load<GameObject>("prefabs/emblem"));
                AvatarObject.GetComponent<Transform>().SetParent(content);
                AvatarObject.GetComponent<Transform>().localPosition = position;
                AvatarObject.GetComponent<Emblem>().SetUp(type, value);
            }

            int childCount = content.childCount;

            var size = content.sizeDelta;
            size.Set(size.x, size.y + childCount * 220f);
            content.sizeDelta = size;
            UIStack.Instance.PushUI(EmblemPage);


            //json.Print();

            Destroy(this.gameObject);
        }
    }
}
