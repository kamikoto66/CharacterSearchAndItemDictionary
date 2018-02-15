using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour {

    private CharacterAbility.Status _Status;
    private Text _AbilityText;

    public void SetUp(CharacterAbility.Status status)
    {
        _Status = status;
        _AbilityText = transform.GetChild(1).GetChild(0).GetComponent<Text>();

        _AbilityText.text = _Status._Value.ToString();
    }
}
