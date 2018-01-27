using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : UI {

    public Button _EmptyButton;
    public Animator _DrawerAnimator;

    //private Transform _Holder;

    // Use this for initialization
    void Start () {

        //_Holder = GameObject.Find("Holder").transform;

        UIHelper.AddButtonListener(Vars["EmptyButton"], ()=> {
            _DrawerAnimator.SetTrigger("close");
            _EmptyButton.gameObject.SetActive(false);
        });

        UIHelper.AddButtonListener(Vars["CharacterSearch"], () =>
        {
            GameObject.Find("Drawer").GetComponent<Animator>().SetTrigger("close");
            _EmptyButton.gameObject.SetActive(false);


            if (GameObject.FindObjectOfType<ServerControl>() == null)
            {
                var obj = Instantiate(Resources.Load<GameObject>("Prefabs/ServerControl"));
                UIStack.Instance.PushUI(obj, true);
                obj.transform.localPosition = Vector2.zero;

            }
        });
    }
}
