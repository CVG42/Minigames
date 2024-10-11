using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missile;
    public float respawnTime = 1.0f;
    private Vector3 screenBouds;
    public Boss boss;
    public bool isAlive = true;

    void Start()
    {
        screenBouds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(MissleWave());
        boss = GetComponent<Boss>();
    }

    private void Update()
    {
        if(boss == null)
        {
            return;
        }
    }

    private void MissileSpawn()
    {
        GameObject m = Instantiate(missile) as GameObject;
        m.transform.position = new Vector3(screenBouds.z * -0.5f, Random.Range(-screenBouds.y, screenBouds.y));
    }

    IEnumerator MissleWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            MissileSpawn();
        }
    }
}
