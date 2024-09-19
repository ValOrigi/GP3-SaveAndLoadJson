using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        GameObject bullet;
        Rigidbody bulletRB;

        bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
    }
}
