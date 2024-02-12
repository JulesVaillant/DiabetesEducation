using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class quiz : MonoBehaviour
{
    public TMP_Text questionText;
    public Button[] answerButtons;
    
    private List<Question> questions;
    private Question currentQuestion;
    private int questionNumber;    
    private int score;
    void Start()
    {
        score = 0;
        InitQuestions();
        ShowNextQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int buttonIndex = i; 
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
        questionNumber=0;
    }

    void InitQuestions()
    {
        questions = new List<Question>();
        questions.Add(new Question("Quelle est la capitale de la France ?", new string[]{"Londres", "Paris", "Berlin", "Rome"}, 1));
        questions.Add(new Question("Comment tu fais you cunt ?", new string[]{"Moscou", "Bite", "Dank", "Rome"}, 2));
        questions.Add(new Question("Qui est la meilleure waifu ?", new string[]{"Anime girl 1", "Anime girl 2", "Anime girl 3", "Nicolas Cage"}, 3));
    }

    void ShowNextQuestion()
    {
        currentQuestion = questions[questionNumber];
        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
        }
   }

   void ShowEndScreen(){
       for (int i=0; i<answerButtons.Length;i++){
            answerButtons[i].enabled = false;
       }
       questionText.text = "Quiz terminé! Ton score final est de "+score; 
   }

    public void CheckAnswer(int buttonIndex)
    {
        if (buttonIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Bonne réponse !");
            score++;
        }
        else
        {
            Debug.Log("Mauvaise réponse.");
        }

        if(questions.Count > questionNumber){
            questionNumber++; 
            ShowNextQuestion();
        }
        else{
            ShowEndScreen();
        }
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;

    public Question(string question, string[] answers, int correctAnswerIndex)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}
