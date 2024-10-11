using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private float speed = 5.0f;
    Vector3 moveDirection;
    public bool hasBullet = false;

    public int ammo = 0;
    public Transform spawnBullet;
    public GameObject bullet;
    public int bulletSpeed;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && ammo >= 1)
        {
            var mybullet = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            mybullet.GetComponent<Rigidbody>().velocity = spawnBullet.right * bulletSpeed; 
            GetComponent<ScoreManager>().score += 5;
            print(GetComponent<ScoreManager>().score);
        }
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

        if (other.CompareTag("Bullet"))
            ammo++;

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

        if (other.CompareTag("Spawned"))
        {
            ammo++;
        }
    }
}
