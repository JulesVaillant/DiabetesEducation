using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnregistrerAliments : MonoBehaviour
{
    [SerializeField] List<GameObject> right;
    [SerializeField] PrefabSpawn spawner;
    [SerializeField] GestionEcran canva;
    private bool found;

    private void OnTriggerEnter(Collider other)
    {
        spawner.putted = true;
        found = false;
        foreach (var item in right)
        {
            if (item.name.Equals(other.name))
            {
                canva.Valid();
                found = true;
                break;
            }
        }
        if (!found)
        {
            canva.Invalid();
        }
        Destroy(other.gameObject);
    }
}
