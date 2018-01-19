using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerSelect : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["cancle"], () => {
            GetComponent<Animator>().SetTrigger("close");
        });
	}
	
}
