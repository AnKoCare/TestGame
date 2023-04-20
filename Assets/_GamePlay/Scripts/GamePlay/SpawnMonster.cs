using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject monPrefab_1;
    [SerializeField] private Transform starPoint_1;
    private float timeRespawn = 0;

    private void Update() 
    {
        if(timeRespawn < 2f)
        {
            timeRespawn += Time.deltaTime;
        }
        else
        {
            timeRespawn = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        
    }
}
