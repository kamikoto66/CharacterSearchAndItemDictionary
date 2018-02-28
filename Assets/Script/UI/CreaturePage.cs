using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaturePage : UI {

    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });
    }

    public IEnumerator SpriteLoad(string ItemCode)
    {
        string Url = "https://img-api.neople.co.kr/df/items/" + ItemCode;

        WWW www = new WWW(Url);
        yield return www;

        Vars["ItemImage"].GetComponent<Image>().sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f));
    }
}
