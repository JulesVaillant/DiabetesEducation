using UnityEngine;
using System.IO;
using UnityEngine.UIElements;

public class QuestionLoader : MonoBehaviour
{
    public string jsonFilePath = "C:/Users/admin/Desktop/quiz.json";
    private QuestionList questionList;

    void Start()
    {
        
    }

    public void getQuestion(){
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFilePath);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            questionList = JsonUtility.FromJson<QuestionList>(json);
            int questionID = Random.Range(0, questionList.questions.Count);

            Debug.Log("Question:" + questionList.questions[questionID].question);
            Debug.Log("Reponses disponibles:" + questionList.questions[questionID].reponses);
            Debug.Log("Reponse: "+ questionList.questions[questionID].reponses[questionList.questions[questionID].reponseCorrecte]);
            // Vous pouvez maintenant accéder à vos questions comme suit :
            /*foreach (var questionData in questionList.questions)
            {
                Debug.Log("Question : " + questionData.question);
                foreach (var reponse in questionData.reponses)
                {
                    Debug.Log("Réponse : " + reponse);
                }
                Debug.Log("Réponse correcte : " + questionData.reponses[questionData.reponseCorrecte]);
            }*/
        }
        else
        {
            Debug.LogError("Le fichier JSON des questions n'existe pas : " + filePath);
        }

    }
}
