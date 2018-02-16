using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmblemPage : UI {

    void Start()
    {
        UIHelper.AddButtonListener(Vars["back"], () => {
            UIStack.Instance.PopUI();
        });
    }
}
