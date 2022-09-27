using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public float speed = 4f;
    private Rigidbody normalbulletRigidbody;
    void Start()
    {
        normalbulletRigidbody = GetComponent<Rigidbody>();
        normalbulletRigidbody.velocity = transform.forward * speed * 7;

        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
