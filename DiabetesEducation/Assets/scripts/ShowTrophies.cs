using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrophies : MonoBehaviour
{
    public GameObject trophyQuiz;
    public GameObject trophyIG;
    void Start()
    {
        if(quiz.success_quiz){
            trophyQuiz.SetActive(true);
        }
    }
}
