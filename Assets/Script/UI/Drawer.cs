using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : UI {

    public Button _EmptyButton;
    public Animator _DrawerAnimator;
    public Transform _Canvas;

    // Use this for initialization
    void Start () {
        UIHelper.AddButtonListener(Vars["EmptyButton"], ()=> {
            _DrawerAnimator.SetTrigger("close");
            _EmptyButton.interactable = false;
        });

        UIHelper.AddButtonListener(Vars["CharacterSearch"], () =>
        {
            GameObject.Find("Drawer").GetComponent<Animator>().SetTrigger("close");
            _EmptyButton.interactable = false;

            if (GameObject.FindObjectOfType<ServerControl>() == null)
            {
                var obj = Instantiate(Resources.Load<GameObject>("Prefabs/ServerControl"));
                obj.transform.SetParent(_Canvas);
                obj.transform.localPosition = Vector2.zero;

                UIStack.Instance.PushUI(obj);
            }
        });
    }
}
