using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBullet : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody masterbulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        masterbulletRigidbody = GetComponent<Rigidbody>();
        masterbulletRigidbody.velocity = transform.forward * speed * 8;
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Die();
            }
        }
    }
}
