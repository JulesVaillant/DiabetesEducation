using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class GestionEcran : MonoBehaviour
{
    [SerializeField] PrefabSpawn spawner;
    static int score;
    [SerializeField] int scoremax;
    [SerializeField] XRRayInteractor rayLeft;
    [SerializeField] GameObject trophie;
    public static bool victory;

    public void Begin()
    {
        victory = false;
        spawner.begin = true;
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Placer l'aliment dans l'un des bols";
        gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez : "+score+" sur "+scoremax;
        gameObject.transform.Find("Pret").GetComponent<Button>().gameObject.SetActive(false);
        gameObject.transform.Find("Annuler").GetComponent<Button>().gameObject.SetActive(false);
        gameObject.transform.Find("Retour_menu").GetComponent<Button>().gameObject.SetActive(true);
        rayLeft.gameObject.SetActive(false);
    }

    public void Valid()
    {
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Bien joué";
        score += 2;
        gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez : " + score + " sur " + scoremax;
        if (score >= scoremax)
        {
            victory = true;
            spawner.begin = false;
            trophie.SetActive(true);
            gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez atteint le score maximum, retourner au menu pour choisir une autre activité";
        }
    }

    public void Invalid()
    {
        gameObject.transform.Find("Titre").GetComponent<TMP_Text>().text = "Mauvais choix";
        score -= 1;
        gameObject.transform.Find("Context").GetComponent<TMP_Text>().text = "Vous avez : " + score + " sur " + scoremax;
    }
}
