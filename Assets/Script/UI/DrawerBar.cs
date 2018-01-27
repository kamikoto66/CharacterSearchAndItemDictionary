using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrawerBar : UI {

    public Button _EmptyButton;

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["Button"], ()=> {
            var Drawer = GameObject.Find("Drawer");
            Drawer.GetComponent<Animator>().SetTrigger("open");
            _EmptyButton.gameObject.SetActive(true);
        });
	}
}
