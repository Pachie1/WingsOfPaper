using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin};

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] GameObject FirePoint;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private Vector3 bulletRotation = new Vector3(0f,0f, 135f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin)
        {
            bulletRotation = new Vector3(0f,0f,bulletRotation.z+1f);
            if (bulletRotation.z > 225)
            {
                bulletRotation = new Vector3(0f, 0f, 135f);
            }
        }
        else
        {
            bulletRotation = new Vector3(0, 0, 180);
        }
        if (timer >= firingRate)
        {
            Fire();
            timer= 0f;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            spawnedBullet = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = Quaternion.Euler(bulletRotation);
        }
    }
}
