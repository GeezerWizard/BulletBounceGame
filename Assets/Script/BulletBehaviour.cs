using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    BounceBullet bounceBullet;
    private Vector3 bounceAngle = new Vector3(0, 0, 90);

    float bulletSpeed = 3f;

    private float boundsX;
    private float boundsY;

    private void Start() {
        bounceBullet = FindObjectOfType<BounceBullet>();
        boundsX = bounceBullet.arenaX/2;
        boundsY = bounceBullet.arenaY/2;
    }
    void Update()
    {
        // Forward movement
        this.transform.position += this.transform.up * bulletSpeed * Time.deltaTime;

        // Recording position
        float posX = transform.position.x;
        float posY = transform.position.y;

        float zAngle = transform.eulerAngles.z;

        if (zAngle > 180) 
        {
            transform.eulerAngles -= new Vector3(0, 0, 360);
        }
        else if (zAngle < -180) 
        {
            transform.eulerAngles += new Vector3(0, 0, 360); 
        }


        if (posX > boundsX)
        {
            transform.rotation = Quaternion.Euler(0, 0, AdjustedAngle(zAngle, -90));
            FixPositions(posX, boundsX, transform.position.y);
        }
        else if (posX < -boundsX)
        {
            transform.rotation = Quaternion.Euler(0, 0, AdjustedAngle(zAngle, 90));
            FixPositions(posX, -boundsX, transform.position.y);
        }
        else if (posY > boundsY)
        {
            transform.rotation = Quaternion.Euler(0, 0, AdjustedAngle(zAngle, 0));
            FixPositions(posY, transform.position.x, boundsY);
        }
        else if (posY < -boundsY)
        {
            transform.rotation = Quaternion.Euler(0, 0, AdjustedAngle(zAngle, 180));
            FixPositions(posY, transform.position.x, -boundsY);
        }
    }

    void CheckTag()
    {
        if (gameObject.tag == "Untagged")
        {
            gameObject.tag = "Bullet";
        }
    }

    float AdjustedAngle(float currentAngle, float testAngle)
    {
        if (currentAngle >= testAngle)
        {
            currentAngle += 90;
            print(currentAngle);
        }
        else
        {
            currentAngle -= 90;
            print(currentAngle);
        }
        return currentAngle;
    }

    void FixPositions(float pos, float adjustX, float adjustY)
    {
        Vector3 adjustPos = new Vector3();
        if (pos > 0) { adjustPos = new Vector3(adjustX, adjustY, 0); }
        if (pos < 0) { adjustPos = new Vector3(adjustX, adjustY, 0); }
        transform.position = adjustPos;
    }
}
