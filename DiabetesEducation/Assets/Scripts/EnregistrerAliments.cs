using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnregistrerAliments : MonoBehaviour
{
    [SerializeField] PrefabSpawn spawner;
    [SerializeField] GestionEcran canva;
    [SerializeField] string TagName;

    private void OnTriggerEnter(Collider other)
    {
        spawner.putted = true;
        if (other.tag.Equals(TagName))
        {
                canva.Valid();
        }else{
            canva.Invalid();
        }
        Destroy(other.gameObject);
    }
}
