using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class QuestionsManager : MonoBehaviour
{
    private struct Question
    {
        public string questionText;
        public string[] answers;
        public int correctAnswerIdx;

        public Question(string questionText, string[] answers, int correctAnswer)
        {
            this.questionText = questionText;
            this.answers = answers;
            this.correctAnswerIdx = correctAnswer;
        }
    }

    public Button[] answerButtons;
    public TextMeshProUGUI questionText;

    private Question[] questionsDatabase;
    private Question currentQuestion;
    private int currentQuestionNumber = 0;

    public void Start()
    {
        string[] answers1 = {"Humanity", "Health", "Honour", "Household"};
        string questionText1 = "In the UK, the abbreviation NHS stands for National what Service?";
        int correctAnswer1 = 2;
        Question question1 = new Question(questionText1, answers1, correctAnswer1);
        string[] answers2 = { "Pocahontas", "Sleeping Beauty", "Cinderella", "Elsa" };
        string questionText2 = "Which Disney character famously leaves a glass slipper behind at a royal ball?";
        int correctAnswer2 = 3;
        Question question2 = new Question(questionText2, answers2, correctAnswer2);
        string[] answers3 = { "Hangar", "Terminal", "Concourse", "Carousel" };
        string questionText3 = " What name is given to the revolving belt machinery in an airport that delivers checked luggage from the plane to baggage reclaim?";
        int correctAnswer3 = 4;
        Question question3 = new Question(questionText3, answers3, correctAnswer3);
        string[] answers4 = { "Philips", "Flymo", "Chubb", "Ronseal" };
        string questionText4 = "500 - Which of these brands was chiefly associated with the manufacture of household locks?";
        int correctAnswer4 = 3;
        Question question4 = new Question(questionText4, answers4, correctAnswer4);

        getNextQuestion();
    }
    private void getNextQuestion()
    {
        currentQuestion = questionsDatabase[currentQuestionNumber];
        currentQuestionNumber++;
        questionText.text = currentQuestion.questionText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<TextMeshProUGUI>().text = currentQuestion.answers[i];
        }
    }

    public void CheckAnswer(int buttonNumber)
    {

        Image buttonImage = answerButtons[buttonNumber].gameObject.GetComponent<Image>();
        Color newColor;
        Color oldColor = buttonImage.color;

        if (buttonNumber == currentQuestion.correctAnswerIdx)
        {
            newColor = Color.green;
        }
        else
        {
            newColor = Color.red;
        }
        buttonImage.color = newColor;
        StartCoroutine(GiveSomeTime());
        buttonImage.color = oldColor;

        getNextQuestion();
    }

    IEnumerator GiveSomeTime()
    {
        yield return new WaitForSeconds(3);
    }
}
