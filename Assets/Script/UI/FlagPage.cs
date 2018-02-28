using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagPage : UI {

    public Dictionary<string, Coroutine> _Coroutines = new Dictionary<string, Coroutine>();

    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });
    }

    public IEnumerator SpriteLoad(string slot, string id)
    {
        string Url = "https://img-api.neople.co.kr/df/items/" + id;

        WWW www = new WWW(Url);
        yield return www;

        Vars[slot].GetComponent<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));

        StopCoroutine(_Coroutines[slot]);
        _Coroutines.Remove(slot);
    }

    public void OnClick(string name, string Description)
    {
        Vars["Name"].GetComponentInChildren<Text>().text = name;
        Vars["Description"].GetComponentInChildren<Text>().text = Description;
    }

}
