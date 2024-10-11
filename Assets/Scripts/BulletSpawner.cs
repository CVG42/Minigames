using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float respawnTime = 1.0f;
    private Vector3 screenBouds;

    void Start()
    {
        screenBouds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(MissleWave());
    }

    private void MissileSpawn()
    {
        GameObject m = Instantiate(bullet) as GameObject;
        m.transform.position = new Vector3(screenBouds.y * -0.5f, Random.Range(-screenBouds.z, screenBouds.z));
    }

    IEnumerator MissleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            MissileSpawn();
        }
    }
}
