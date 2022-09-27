using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperBullet : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody superbulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        superbulletRigidbody = GetComponent<Rigidbody>();
        superbulletRigidbody.velocity = transform.forward * speed * 13;
        Destroy(gameObject, 6f);
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
