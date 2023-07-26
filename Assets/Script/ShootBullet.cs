using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform turret;
    [SerializeField] Rigidbody2D rb;

    void Update()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 newRotation = turret.rotation.eulerAngles;
            Instantiate(bullet, turret.position, Quaternion.Euler(newRotation));
        }
    }
}
