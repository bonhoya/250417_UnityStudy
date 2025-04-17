using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMover : MonoBehaviour
{
    [SerializeField] Transform enemyEyeTransform;
    private float enemySightRange = 10f;
    private float enemySpeed = 4f;
    private GameObject target;

    private void Update()
    {
        Patrol();
        if(target != null)
        {
            Trace();
        }
    }
    private void Patrol()
    {
        if (Physics.Raycast(enemyEyeTransform.position, enemyEyeTransform.forward, out RaycastHit hitInfo, enemySightRange))
        {
            Debug.DrawLine(enemyEyeTransform.position, hitInfo.point, Color.red);
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                target = hitInfo.collider.gameObject;
            }
            else
                target = null;
        }
        else
        {
            Debug.DrawLine(enemyEyeTransform.position, enemyEyeTransform.position + enemyEyeTransform.forward * enemySightRange, Color.blue);
            target = null;
        }
    }

    private void Trace()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, enemySpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
    
}
