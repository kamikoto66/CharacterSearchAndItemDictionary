using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmblemPage : UI {

    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });
    }
}
