using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static int currentScore = 0;
    public static int backupScore = 0;
    public static bool gameLost = false;
    public static bool gameLeft = false;
    public Image arrow;
    private int currentQuestionIndx = 0;

    private int[] scores = { 500, 1000, 2000, 5000, 10000, 20000, 50000, 75000, 150000, 250000, 500000, 1000000 };
    public void LeaveGame()
    {
        gameLeft = true;
        SceneManager.LoadSceneAsync(2);
    }
    public void IncrementQuestionIndx()
    {
        currentQuestionIndx++;
    }
    public void LostGame()
    {
        if (1 < currentQuestionIndx && currentQuestionIndx < 7)
        {
            backupScore = scores[1];
        }
        else if(currentQuestionIndx >=7)
        {
            backupScore = scores[6];
        }
        gameLost = true;
        SceneManager.LoadSceneAsync(2);
    }
    public void RestartGame()
    {
        currentScore = 0;
        backupScore = 0;
        gameLost = false;
        gameLeft = false;
        SceneManager.LoadScene(0);
    }
    public void WonGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void IncreaseScore()
    {
        if (currentQuestionIndx == 12)
        {
            WonGame();
        }
        else
        {
            currentScore = scores[currentQuestionIndx];
            MoveArrow(30);
        }
    }

    private void MoveArrow(int moveBy)
    {
        arrow.rectTransform.localPosition += Vector3.up * moveBy;
    }

}
