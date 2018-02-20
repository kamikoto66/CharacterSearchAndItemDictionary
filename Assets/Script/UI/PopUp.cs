using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopUp : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["cancel"], () => {
            Destroy(this.gameObject);
        });
	}

    //public void SetUp(string error)
    //{
    //    Vars["Error"].GetComponent<Text>().text = error;
    //}
}
