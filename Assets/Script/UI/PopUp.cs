using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["cancel"], () => {
            Destroy(this.gameObject);
        });
	}
}
