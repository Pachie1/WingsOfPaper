using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Spin};

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
<<<<<<< Updated upstream:Assets/Scripts/BulletSpawner.cs

    private GameObject spawnedBullet;
    private float timer = 0f;
=======
    [SerializeField] GameObject FirePoint;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private Vector3 bulletRotation = new Vector3(0f,0f, 135f);
>>>>>>> Stashed changes:Assets/Code/Scripts/BulletSpawner.cs

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
<<<<<<< Updated upstream:Assets/Scripts/BulletSpawner.cs
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+1f);
=======
            bulletRotation = new Vector3(0f,0f,bulletRotation.z+1f);
            if (bulletRotation.z > 225)
            {
                bulletRotation = new Vector3(0f, 0f, 135f);
            }
        }
        else
        {
            bulletRotation = new Vector3(0, 0, 180);
>>>>>>> Stashed changes:Assets/Code/Scripts/BulletSpawner.cs
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
<<<<<<< Updated upstream:Assets/Scripts/BulletSpawner.cs
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = transform.rotation;
        }
    }
=======
            spawnedBullet = Instantiate(bullet, FirePoint.transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Bullet>().speed = speed;
            spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            spawnedBullet.transform.rotation = Quaternion.Euler(bulletRotation);
        }
    }



>>>>>>> Stashed changes:Assets/Code/Scripts/BulletSpawner.cs
}
