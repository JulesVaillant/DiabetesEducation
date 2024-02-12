using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;
    [SerializeField] GameObject spawn;

    void Start()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Count-1)], spawn.transform.position, spawn.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
