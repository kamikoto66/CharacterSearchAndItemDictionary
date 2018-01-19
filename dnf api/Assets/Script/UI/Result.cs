using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : UI {

    private GameObject _ServerControl;

    public GameObject ServerControl
    {
        get { return _ServerControl; }
        set { _ServerControl = value; }
    }

	// Use this for initialization
	void Start () {
        UIHelper.AddButtonListener(Vars["back"], () => {
            Destroy(GameObject.Find("Result(Clone)"));
            _ServerControl.SetActive(true);
        });
	}
	
}
