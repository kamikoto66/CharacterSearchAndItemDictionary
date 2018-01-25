using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["back"], () =>{
            UIStack.Instance.PopUI();
        });
    }
}
