using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;
    [SerializeField] GameObject spawn;
    [NonSerialized] public bool begin;
    [NonSerialized] public bool putted;
    private bool spawned;

    void Start()
    {
        begin = false;
        spawned = false;
        putted = false;
    }

    void Update()
    {
        if (begin && !spawned)
        {
            Spawning();
        }
        if (putted)
        {
            spawned = false;
            putted = false;
        }
    }

    public void Spawning()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Count - 1)], spawn.transform.position, spawn.transform.rotation);
        spawned = true;
    }
}
