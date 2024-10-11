using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 screenBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, -speed, 0f);
        screenBounds = Camera.main.ScreenToViewportPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
