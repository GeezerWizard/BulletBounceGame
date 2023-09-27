using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootBullet : MonoBehaviour
{
    private int bulletAmount;
    public int BulletAmount
    {
        get {return bulletAmount;}
        set {bulletAmount = value;             
            bulletAmountText.text = bulletAmount.ToString();}
    }
    private int startingBulletAmount = 1;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform turret;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private List<GameObject> bullets = new List<GameObject>();

    [SerializeField] TMP_Text bulletAmountText;


    private void Start() {
        GameEvents.current.onPlayerDeath += DestroyAllBullets;
        GameEvents.current.onGameStart += SetBullets;
        bulletAmount = startingBulletAmount;
        bulletAmountText.text = bulletAmount.ToString();
    }

    void Update()
    {
        //Shooting
        if (Input.GetKeyDown(KeyCode.Mouse0) & bulletAmount > 0)
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
            bulletAmount--;
            bulletAmountText.text = bulletAmount.ToString();
        }
    }

    void DestroyAllBullets()
    {
        foreach (GameObject liveBullet in bullets)
        {
            Destroy(liveBullet);
            bulletAmount = 0;
        }
    }

    void SetBullets()
    {
        bulletAmount = startingBulletAmount;
    }
}
