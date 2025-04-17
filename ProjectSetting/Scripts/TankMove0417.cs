using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove0417 : MonoBehaviour
{
    private float tankSpeed = 5;
    private float rotateSpeed = 10;
    [SerializeField] GameObject tankTurretPrefab;
    [SerializeField] TankShooter tankShooter;

    [Range(30, 100)]
    [SerializeField] float tankTurretRotate;

    private void Update()
    {
        Mover();
        TankTurretMover();
        tankShooter.Fire();
        
    }

    private void Mover()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternion = Quaternion.LookRotation(Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternion = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternion = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * tankSpeed * Time.deltaTime, Space.World);
            Quaternion quaternion = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Lerp(transform.rotation, quaternion, rotateSpeed * Time.deltaTime);
        }
    }
    
    private void TankTurretMover()
    {
        if (Input.GetKey(KeyCode.D))
        {
            tankTurretPrefab.transform.Rotate(Vector3.up, tankTurretRotate * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            tankTurretPrefab.transform.Rotate(Vector3.up, -tankTurretRotate * Time.deltaTime);
        }
    }

    public void DamagedTank()
    {
        Destroy(gameObject);
    }
}
