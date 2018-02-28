using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gem : MonoBehaviour {

    private string _Name;
    private string _Description;

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    private void Start()
    {
        UIHelper.AddButtonListener(GetComponent<Button>(), OnClick);
    }

    public void OnClick()
    {
        transform.parent.parent.GetComponent<UI>().Vars["Name"].GetComponentInChildren<Text>().text = _Name;
        transform.parent.parent.GetComponent<UI>().Vars["Description"].GetComponentInChildren<Text>().text = _Description;
    }
}
