using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBullet : MonoBehaviour
{
    [SerializeField] GameObject collisionEfectPrefab;
    [SerializeField] Rigidbody bulletrigid;
    EnemyTankMover eTM;

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
        if (collision.gameObject.tag == "Enemy")
        {
            eTM = collision.gameObject.GetComponent<EnemyTankMover>();
            if (eTM.enermyHP != 0)
            {
                eTM.DamagedEnemy(1);
                Debug.Log("Damage 1");
            }
        }
    }
}
