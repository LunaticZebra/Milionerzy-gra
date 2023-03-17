using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

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
    public Image arrow;

    private Question[] questionsDatabase;
    private Question currentQuestion;
    private int currentQuestionNumber = 0;

    public GameStateManager gameStateManager;

    public void Start()
    {
        initialzeQuestions();
        getNextQuestion();
    }
    public int CurrentQuestionIndx()
    {
        return currentQuestionNumber;
    }
    private void getNextQuestion()
    {
        currentQuestion = questionsDatabase[currentQuestionNumber];
        currentQuestionNumber++;
        questionText.text = currentQuestion.questionText;
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.answers[i];
        }
    }

    public void CheckAnswer(int buttonNumber)
    {
        StartCoroutine(CheckButtons(buttonNumber));
    }
    IEnumerator CheckButtons(int buttonNumber)
    {
        Debug.Log("BUtton Number" + buttonNumber);
        bool lost = false;
        Image buttonImage = answerButtons[buttonNumber - 1].gameObject.GetComponent<Image>();
        Cursor.lockState = CursorLockMode.Locked;
        Color newColor;
        Color oldColor = buttonImage.color;

        if (buttonNumber == currentQuestion.correctAnswerIdx)
        {
            newColor = Color.green;
        }
        else
        {
            newColor = Color.red;
            lost = true;
        }
        buttonImage.color = newColor;
        yield return new WaitForSeconds(1.5f);
        Cursor.lockState = CursorLockMode.None;
        if (lost)
        {
            gameStateManager.LostGame();
        }
        else
        {
            buttonImage.color = oldColor;
            gameStateManager.IncreaseScore();
            gameStateManager.IncrementQuestionIndx();
            getNextQuestion();
        }

    }

    private void initialzeQuestions()
    {
        string[] answers1 = { "Humanity", "Health", "Honour", "Household" };
        string questionText1 = "In the UK, the abbreviation NHS stands for National what Service?";
        int correctAnswer1 = 2;
        Question question1 = new Question(questionText1, answers1, correctAnswer1);
        string[] answers2 = { "Pocahontas", "Sleeping Beauty", "Cinderella", "Elsa" };
        string questionText2 = "Which Disney character famously leaves a glass slipper behind at a royal ball?";
        int correctAnswer2 = 3;
        Question question2 = new Question(questionText2, answers2, correctAnswer2);
        string[] answers3 = { "Hangar", "Terminal", "Concourse", "Carousel" };
        string questionText3 = "What name is given to the revolving belt machinery in an airport that delivers checked luggage from the plane to baggage reclaim?";
        int correctAnswer3 = 4;
        Question question3 = new Question(questionText3, answers3, correctAnswer3);
        string[] answers4 = { "Philips", "Flymo", "Chubb", "Ronseal" };
        string questionText4 = "Which of these brands was chiefly associated with the manufacture of household locks?";
        int correctAnswer4 = 3;
        Question question4 = new Question(questionText4, answers4, correctAnswer4);
        string[] answers5 = { "Republicanism", "Communism", "Conservatism", "Liberalism" };
        string questionText5 = "The hammer and sickle is one of the most recognisable symbols of which political ideology?";
        int correctAnswer5 = 2;
        Question question5 = new Question(questionText5, answers5, correctAnswer5);
        string[] answers6 = { "Bratz Dolls", "Sylvanian Families", "Hatchimals", "Transformers" };
        string questionText6 = " Which toys have been marketed with the phrase “robots in disguise”?";
        int correctAnswer6 = 4;
        Question question6 = new Question(questionText6, answers6, correctAnswer6);
        string[] answers7 = { "Angry", "Chatty", "Beautiful", "Shy" };
        string questionText7 = "What does the word loquacious mean?";
        int correctAnswer7 = 2;
        Question question7 = new Question(questionText7, answers7, correctAnswer7);
        string[] answers8 = { "Childbirth", "Broken bones", "Heart conditions", "Old age" };
        string questionText8 = "Obstetrics is a branch of medicine particularly concerned with what?";
        int correctAnswer8 = 1;
        Question question8 = new Question(questionText8, answers8, correctAnswer8);
        string[] answers9 = { "Bow-tie, braces and tweed jacket", "Wide-brimmed hat and extra long scarf",
            "Pinstripe suit and trainers", "Cape, velvet jacket and frilly shirt" };
        string questionText9 = " In Doctor Who, what was the signature look of the fourth Doctor, as portrayed by Tom Baker?";
        int correctAnswer9 = 2;
        Question question9 = new Question(questionText9, answers9, correctAnswer9);
        string[] answers10 = { "Ramadan", "Diwali", "Lent", "Hanukkah" };
        string questionText10 = "Which of these religious observances lasts for the shortest period of time during the calendar year?";
        int correctAnswer10 = 2;
        Question question10 = new Question(questionText10, answers10, correctAnswer10);
        string[] answers11 = { "Bahamas", "US Virgin Island", "Turks and Caicos Islands", "Bermuda" };
        string questionText11 = "At the closest point, which island group is only 50 miles south-east of the coast of Florida?";
        int correctAnswer11 = 1;
        Question question11 = new Question(questionText11, answers11, correctAnswer11);
        string[] answers12 = { "Empire State Building", "Royal Albert Hall", "Eiffel Tower", "Big Ben Clock Tower" };
        string questionText12 = "Construction of which of these famous landmarks was completed first?";
        int correctAnswer12 = 4;
        Question question12 = new Question(questionText12, answers12, correctAnswer12);
        questionsDatabase = new Question[12];
        questionsDatabase[0] = question1;
        questionsDatabase[1] = question2;
        questionsDatabase[2] = question3;
        questionsDatabase[3] = question4;
        questionsDatabase[4] = question5;
        questionsDatabase[5] = question6;
        questionsDatabase[6] = question7;
        questionsDatabase[7] = question8;
        questionsDatabase[8] = question9;
        questionsDatabase[9] = question10;
        questionsDatabase[10] = question11;
        questionsDatabase[11] = question12;


    }
}
