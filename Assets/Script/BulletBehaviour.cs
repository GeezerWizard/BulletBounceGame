using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    BounceBullet bounceBullet;
    int debugBounceMax = 10;
    int debugBounceAmount = 0;
    private Vector3 bounceAngle = new Vector3(0, 0, 90);

    float bulletSpeed = 10f;

    private float boundsX;
    private float boundsY;

    float zAngle;

    bool initialPlayerTouched = false;

    private void Start() {
        bounceBullet = FindObjectOfType<BounceBullet>();
        boundsX = bounceBullet.arenaX/2;
        boundsY = bounceBullet.arenaY/2;

        zAngle = transform.eulerAngles.z;
        print(zAngle);
        gameObject.tag = "Untagged";
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            initialPlayerTouched = true;
            gameObject.tag = "Bullet";
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Enemy")
        {
            //Destroy(this.gameObject);
        }
    }

    void Update()
    {
        // Forward movement
        this.transform.position += this.transform.up * bulletSpeed * Time.deltaTime;

        // Recording position
        float posX = transform.position.x;
        float posY = transform.position.y;

        zAngle = transform.eulerAngles.z;

        if (posX > boundsX)
        {
            AdjustAngle(zAngle, 270, false);
            transform.position = FixPosition(posX, boundsX, transform.position.y);
        }

        else if (posX < -boundsX)
        {
            AdjustAngle(zAngle, 90, false);
            transform.position = FixPosition(posX, -boundsX, transform.position.y);
        }

        else if (posY > boundsY)
        {
            AdjustAngle(zAngle, 360, true);
            transform.position = FixPosition(posY, transform.position.x, boundsY);
        }

        else if (posY < -boundsY)
        {
            AdjustAngle(zAngle, 180, false);
            transform.position = FixPosition(posY, transform.position.x, -boundsY);
        }
    }

    void AdjustAngle(float currentAngle, float testAngle, bool overZero)
    {
        if (overZero)
        {
            if (currentAngle > 270) transform.eulerAngles -= bounceAngle;
            else transform.eulerAngles += bounceAngle;
        }
        else if (currentAngle < testAngle)
        {
            transform.eulerAngles -= bounceAngle;
        }
        else
        {
            transform.eulerAngles += bounceAngle;
        }
    }

    Vector3 FixPosition(float pos, float adjustX, float adjustY)
    {
        Vector3 adjustPos = new Vector3();
        if (pos > 0) { adjustPos = new Vector3(adjustX, adjustY, 0); }
        if (pos < 0) { adjustPos = new Vector3(adjustX, adjustY, 0); }
        return adjustPos;
    }
}
