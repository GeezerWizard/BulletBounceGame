using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform turret;
    [SerializeField] Rigidbody2D rb;
    private List<GameObject> bullets = new List<GameObject>();

    private void Start() {
        //GameEvents.current.onGameStart +=
        GameEvents.current.onPlayerDeath += DestroyAllBullets;
    }

    void Update()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 newRotation = turret.rotation.eulerAngles;
            
            if (newRotation.z > 360) 
            {
                newRotation -= new Vector3(0, 180, 360);
            }
            else if (newRotation.z < 0) 
            {
                newRotation += new Vector3(0, 180, 360); 
            }

            GameObject liveBullet = (GameObject)Instantiate(bullet, turret.position, Quaternion.Euler(newRotation));
            bullets.Add(liveBullet);
        }
    }

    void DestroyAllBullets()
    {
        foreach (GameObject liveBullet in bullets)
        {
            Destroy(liveBullet);
        }
    }
}
