using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Discovery : MonoBehaviour
{
    public static bool success;
    private bool[] bools;
    [SerializeField] GameObject trophie;
    [SerializeField] GameObject trophie_mini;

    void Start()
    {
        bools = new bool[9];
        for(int i = 0; i < 9; i++)
        {
            bools[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!bools.Contains(false))
        {
            success = true;
            trophie.SetActive(true);
            trophie_mini.SetActive(true);
        }
    }

    public void Activate(int number)
    {
        bools[number - 1] = true;
    }
}
