using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeedMax = 90;
    public float rotationSpeedMin = -90;
    public float rotationSpeed;
    public float jugi = 50;
    void Start()
    {
        rotationSpeed = Random.Range(rotationSpeedMax, rotationSpeedMin);
    }
    void Update()
    {
        jugi -= 1;
        transform.Rotate(0f, rotationSpeed * Time.deltaTime * 2, 0f );
        if (jugi <= 0)
        {
            rotationSpeed = Random.Range(rotationSpeedMax, rotationSpeedMin);
            jugi = 50;
        }
    }
}