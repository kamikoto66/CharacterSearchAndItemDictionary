using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStack : MonoBehaviour{

    private Stack<GameObject> _UIStack = new Stack<GameObject>();
    private static UIStack _Instance;

    public static UIStack Instance
    {
        get
        {
            if(!_Instance)
            {
                _Instance = GameObject.FindObjectOfType<UIStack>();
                if(!_Instance)
                {
                    GameObject uiManagerPrefab = Resources.Load<GameObject>("Prefab/UIStack");
                    _Instance = Instantiate<GameObject>(uiManagerPrefab).GetComponent<UIStack>();
                }
            }

            return _Instance;
        }
    }
    
    public GameObject PushUI(GameObject UIInstance)
    {
        if(!_UIStack.Contains(UIInstance))
        {
            if(_UIStack.Count == 0)
            {
                _UIStack.Push(UIInstance);
            }
            else
            {
                var v = _UIStack.Peek();
                v.SetActive(false);

                _UIStack.Push(UIInstance);
            }
        }

        return UIInstance;
    }


    public GameObject PopUI()
    {
        GameObject ui = null;

        if(_UIStack.Count != 0)
        {
            ui = _UIStack.Pop();
            Destroy(ui);

            _UIStack.Peek().SetActive(true);


        }

        return ui;
    }

}
