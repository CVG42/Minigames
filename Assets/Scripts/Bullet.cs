using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform objTransform, player;
    public bool pickedup;
    public float speed;
    public PlayerController playerController;
    public bool isShot = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && pickedup && !isShot)
        {
            //objTransform.parent = null;
            //GetComponent<Rigidbody>().isKinematic = false;
            //GetComponent<Rigidbody>().AddForce(player.right * speed, ForceMode.VelocityChange);
            GetComponent<Rigidbody>().velocity = player.right * speed;
            GetComponentInParent<ScoreManager>().score += 5;
            print(GetComponentInParent<ScoreManager>().score);
            isShot = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !pickedup && playerController.hasBullet == false)
        {
            objTransform.parent = player;
            pickedup = true;
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
