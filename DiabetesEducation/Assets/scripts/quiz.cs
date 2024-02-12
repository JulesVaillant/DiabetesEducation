using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Collections;
using TMPro.Examples;

public class quiz : MonoBehaviour
{
    public static bool success_quiz;
    public TMP_Text questionText;
    public Button[] answerButtons;
    public GameObject trophy;

    private List<Question> questions;
    private Question currentQuestion;
    private int questionNumber;
    private int score, totalScore;
    private int answerDuration = 1;
    void Start()
    {
        success_quiz = false;
        score = 0;
        totalScore = 0;
        InitQuestions();
        ShowNextQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int buttonIndex = i;
            answerButtons[i].onClick.AddListener(() => CheckAnswer(buttonIndex));
        }
        questionNumber = 0;
    }

    void InitQuestions()
    {
        const int nb_reponses = 4;
        questions = new List<Question>
        {
            new("Quel diabète touche le plus de personne ?", new string[nb_reponses] { "Diabète de type I", "Diabète de type II", null, null }, 1),
            new("Où je jette les aiguilles des seringues à insuline ?", new string[nb_reponses] { "Dans une poubelle spéciale", "A la poubelle normale", null, null }, 0),
            new("Quel facteur ne participe PAS à l’apparition du diabète de type 2 ?", new string[nb_reponses] { "L’hérédité", "Une mauvaise alimentation", "Le stress", "Un manque d’activité physique" }, 0),
            //new("Qui est la meilleure waifu ?", new string[4] { "Anime girl 1", "Anime girl 2", "Anime girl 3", "Nicolas Cage" }, 3),  //A ENLEVER
            new("Combien existe-t-il de diabète?", new string[nb_reponses] { "1", "2", "3", null }, 1),
            new("Le diabète est-il douloureux ?", new string[nb_reponses] { "Oui", "Non", null, null }, 1),
            new("Comment s'appelle le taux de sucre que l'on a dans le sang ?", new string[nb_reponses]{"La glycémie", "La sucrémie", "L’insulinémie", null}, 0),
            new("Ai-je le droit de pratiquer du sport en tant que diabétique ?", new string[nb_reponses]{"Oui", "Non", null, null}, 0),
            new("Est-ce que je dois totalement arrêter de manger du sucre si je suis diabétique ?", new string[nb_reponses]{"Oui", "Non", null, null}, 1),
            new("Comment mesurer ma glycémie ?", new string[nb_reponses]{"A l’aide d’un glucomètre", "A l’aide d’un test urinaire", null, null}, 1),
            new("Le diabète m’empêche de vivre une vie normale ?", new string[nb_reponses]{"Oui", "Non", null, null}, 1)
        };

    }

    void ShowNextQuestion()
    {
        //currentQuestion = questions[questionNumber];
        currentQuestion = questions[Random.Range(0, questions.Count)];
        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(true);
            if (currentQuestion.answers[i] == null) answerButtons[i].gameObject.SetActive(false);
            answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
        }
    }

    void ShowEndScreen()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        questionText.text = "Quiz terminé! \nTon score final est de " + score + " sur " + totalScore+ "!\nVous avez obtenu le badge de Maître du diabète!";
        success_quiz = true;
        trophy.SetActive(true);
    }

    public void CheckAnswer(int buttonIndex)
    {
        if (buttonIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Bonne réponse !");
            score++;
            StartCoroutine(ChangeButtonCorrect(answerButtons[buttonIndex]));
        }
        else
        {
            Debug.Log("Mauvaise réponse.");
            StartCoroutine(ChangeButtonWrong(answerButtons[buttonIndex]));
            StartCoroutine(ChangeButtonCorrect(answerButtons[currentQuestion.correctAnswerIndex]));
        }
        totalScore++;
        questions.Remove(currentQuestion);
        Debug.Log(questions.Count);
    }

    IEnumerator ChangeButtonCorrect(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color originalColor = buttonImage.color;
        buttonImage.color = Color.green;
        yield return new WaitForSeconds(answerDuration);
        buttonImage.color = originalColor;

        if (questions.Count > 0)
        {
            ShowNextQuestion();
        }
        else
        {
            ShowEndScreen();
        }
    }

    IEnumerator ChangeButtonWrong(Button button)
    {
        Image buttonImage = button.GetComponent<Image>();
        Color originalColor = buttonImage.color;
        buttonImage.color = Color.red;
        yield return new WaitForSeconds(answerDuration);
        buttonImage.color = originalColor;
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
