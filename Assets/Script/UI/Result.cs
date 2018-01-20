using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["back"], () => {
            //Destroy(GameObject.Find("Result(Clone)"));
            UIStack.Instance.PopUI();
        });
	}
}
