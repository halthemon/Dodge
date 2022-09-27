using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBulletSpawner : MonoBehaviour
{
    public GameObject masterbulletPrefab;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = 2f;
        target = FindObjectOfType<PlayerController>().transform;
    }
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject masterbullet
            = Instantiate(masterbulletPrefab, transform.position, transform.rotation);
            masterbullet.transform.LookAt(target);
            
            
            spawnRate = 10f;            
        }
    }
}