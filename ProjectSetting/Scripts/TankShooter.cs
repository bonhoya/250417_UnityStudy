using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;

    [Range(10, 50)]
    [SerializeField] float bulletSpeed;

    public void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instance = Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Rigidbody bulletRigidbody = instance.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = muzzlePoint.forward * bulletSpeed;
        }
    }
}
