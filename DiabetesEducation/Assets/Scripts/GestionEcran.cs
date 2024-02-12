using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GestionEcran : MonoBehaviour
{
    [SerializeField] PrefabSpawn spawner;
    static int score;
    [SerializeField] static int scoremax;
    public void Begin()
    {
        spawner.begin = true;
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Placer l'aliment dans l'un des bols";
        gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez : "+score+" sur "+scoremax;
        gameObject.transform.Find("Pret").GetComponent<Button>().gameObject.SetActive(false);
        gameObject.transform.Find("Annuler").GetComponent<Button>().gameObject.SetActive(false);
        gameObject.transform.Find("Retour_menu").GetComponent<Button>().gameObject.SetActive(true);
    }

    public void Valid()
    {
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Bien joué";
        score += 2;
        if (score >= scoremax)
        {
            spawner.begin = false;
            gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez atteint le score maximum, retourner au menu pour choisir une au";
        }
    }

    public void Invalid()
    {
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Mauvais choix";
        score -= 1;
    }
}
