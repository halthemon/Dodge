using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBulletSpawner : MonoBehaviour
{
    public GameObject superbulletPrefab;
    public float spawnRateMin = 4f;
    public float spawnRateMax = 6f;
    public float ziptan = 5f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            if (ziptan >= 0)
            {
                ziptan -= 1;
                GameObject superbullet
                    = Instantiate(superbulletPrefab, transform.position, transform.rotation);
                superbullet.transform.LookAt(target);
                spawnRate = 5;
            }
            else
            {
                timeAfterSpawn = 0f;
                GameObject superbullet
                    = Instantiate(superbulletPrefab, transform.position, transform.rotation);
                superbullet.transform.LookAt(target);
                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
                ziptan = 5;
            }
        }
    }
}