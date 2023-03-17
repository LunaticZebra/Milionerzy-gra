using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text finalText;

    [SerializeField]
    private TMP_Text scoreText;


    void Start()
    {
        SetAllTexts();
    }

    private void SetAllTexts()
    {
        string nickname = ManageButtonState.getNickname();

        if (GameStateManager.gameLost)
        {
            finalText.color = Color.red;
            finalText.text = "You lost!";
            scoreText.text = "Sorry " + nickname + ", but you lost. \n Your consolation prize: " + GameStateManager.backupScore + " dollars";

        }
        else if (GameStateManager.gameLeft)
        {
            finalText.color = Color.yellow;
            finalText.text = "You left!";
            scoreText.text = nickname + ", you are leaving with " + GameStateManager.currentScore + " dollars";
        }
        else
        {
            finalText.color = Color.green;
            finalText.text = "You won!";
            scoreText.text = "Congratulations " + nickname + "! You won all of the money - " + GameStateManager.currentScore + " dollars!";
        }
    }

}
