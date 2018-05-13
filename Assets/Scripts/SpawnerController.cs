using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    public float spawnTime = 5f;        
    public float spawnDelay = 3f;      
    public GameObject enemy;        


    void Start ()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }


    void Spawn ()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
