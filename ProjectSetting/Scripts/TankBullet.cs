using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    [SerializeField] GameObject collisionEfectPrefab;
    [SerializeField] Rigidbody bulletrigid;

    private void Update()
    {
        if(bulletrigid.velocity.magnitude > 0)
        {
            transform.forward = bulletrigid.velocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(collisionEfectPrefab, transform.position, transform.rotation);
    }
}
