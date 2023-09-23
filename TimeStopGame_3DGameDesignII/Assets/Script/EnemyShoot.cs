using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Tooltip("Where the bullet will spawn")]
    public Transform bulletSpawnPosition;

    public Transform enemyTransform;

    public GameObject Bullet;

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate = 1.0f;
    //Cooldown time for the next fire
    float nextFire = 0.0f;
    //keep track of the curren cooldown time
    float currentFireCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        currentFireCount += Time.deltaTime;

        //callAttackCount > nextFire: A Condition That Prevent Player From Shooting Rapidly
        if (currentFireCount > nextFire)
        {
            //SpawnBullet
            if (Bullet != null && bulletSpawnPosition != null)
            {
                GameObject bullet = Instantiate(Bullet, bulletSpawnPosition.position, Quaternion.identity);
                bullet.transform.eulerAngles = new Vector3(90.0f + enemyTransform.eulerAngles.x, enemyTransform.eulerAngles.y, enemyTransform.eulerAngles.z);
            }


            //Reset The CoolDown Time(Make The Character Able To Shoot Again)
            nextFire = fireRate;
            currentFireCount = 0.0f;
        }
    }
}
