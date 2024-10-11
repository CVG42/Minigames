using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    Vector3 moveDirection;
    public bool hasBullet = false;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (controller == null) return;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, vertical, 0f);

        controller.Move(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet") && !hasBullet)
            hasBullet = true;

        if (other.CompareTag("Attack"))
        {
            GetComponent<ScoreManager>().score--;
            print(GetComponent<ScoreManager>().score);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            hasBullet = false;
        }
    }
}
