using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    BounceBullet bounceBullet;
    private Vector3 bounceAngle = new Vector3(0, 0, 90);

    [SerializeField] private float speed = 1f;

    private float boundsX;
    private float boundsY;

    private void Start() {
        bounceBullet = FindObjectOfType<BounceBullet>();
        boundsX = bounceBullet.arenaX/2;
        boundsY = bounceBullet.arenaY/2;
    }
    void Update()
    {
        this.transform.position += this.transform.up * speed * Time.deltaTime;

        float posX = transform.position.x;
        float posY = transform.position.y;

        if (posX >= boundsX || posX < -boundsX)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z * -1);
            CheckTag();
            Vector3 adjustPos = new Vector3();
            if (posX > 0) {adjustPos = new Vector3(boundsX, transform.position.y, 0);}
            if (posX < 0) {adjustPos = new Vector3(-boundsX, transform.position.y, 0);}
            transform.position = adjustPos;
        }
        else if (posY >= boundsY || posY < -boundsY)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.eulerAngles.z * -1 + 180);
            CheckTag();
            Vector3 adjustPos = new Vector3();
            if (posY > 0) {adjustPos = new Vector3(transform.position.x, boundsY, 0);}
            if (posY < 0) {adjustPos = new Vector3(transform.position.x, -boundsY, 0);}
            transform.position = adjustPos;
        }
    }

    void CheckTag()
    {
        if (gameObject.tag == "Untagged")
        {
            gameObject.tag = "Bullet";
        }
    }
}
