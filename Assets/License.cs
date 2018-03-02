using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class License : UI {

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["NeoPleOpenAPI"], ()=> {
            Application.OpenURL("https://developers.neople.co.kr");
        });

        UIHelper.AddButtonListener(Vars["Back"], () => {
            Destroy(this.gameObject);
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
