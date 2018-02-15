using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPage : UI {
    // Use this for initialization
    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });
    }
}
