using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer : UI {

    public Button _EmptyButton;
    public Animator _DrawerAnimator;

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["EmptyButton"], ()=> {
            _DrawerAnimator.SetTrigger("close");
            _EmptyButton.interactable = false;
           //GetComponentInChildren<Button>().interactable = false;
        });
	}
}
