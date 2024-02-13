using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrophies : MonoBehaviour
{
    public GameObject trophyQuiz;
    public GameObject trophyIG;
    public GameObject trophyDisco;
    void Start()
    {
        if(quiz.success_quiz){
            trophyQuiz.SetActive(true);
        }
        if (GestionEcran.victory)
        {
            trophyIG.SetActive(true);
        }
        if (Discovery.success)
        {
            trophyDisco.SetActive(true);
        }
    }
}
