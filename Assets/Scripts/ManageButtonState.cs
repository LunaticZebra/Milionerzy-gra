using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManageButtonState : MonoBehaviour
{
    [SerializeField]
    Button button;

    [SerializeField]
    TextMeshProUGUI inputField;

    static string nickname;
    private void turnOffButton()
    {
        button.interactable = false;
    }

    private void turnOnButton()
    {
        button.interactable = true;
    }
    public void checkIfNameProvided()
    {
        if (inputField.text.Length > 1)
        {
            turnOnButton();
            
        }
        else
        {
            turnOffButton();
        }
    }

    public void saveName()
    {
        nickname = inputField.text;
    }

    public static string getNickname()
    {
        if(nickname != null)
        {
            return nickname;
        }
        return "NAME_NOT_FOUND";
    }
}
