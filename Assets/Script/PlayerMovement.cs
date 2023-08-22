using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private bool invincible;
    private bool initialPlayerTouched = false;
    [SerializeField] private BounceBullet bb;
    private float xBounds;
    private float yBounds;

    Vector3 mousePos;

    Vector3 movementDir = Vector3.zero;
    
    void Start() 
    {
        xBounds = bb.arenaX/2;
        yBounds = bb.arenaY/2;
    }

    void Update()
    {
        //Looking at mouse
        float distance = rb.transform.position.z - Camera.main.transform.position.z; 
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));        
        Vector2 lookDir = mousePos - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;

        print(this.transform.position.x + " and " + xBounds);
        if (Input.anyKey)
        {
            movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            if (this.transform.position.x >= xBounds && movementDir.x > 0)
            {
                movementDir.x = 0;
                print("out of bounds X");
            }
            else if (this.transform.position.x <= -xBounds && movementDir.x < 0)
            {
                movementDir.x = 0;
                print("out of bounds -X");
            }
            if (this.transform.position.y >= yBounds && movementDir.y > 0)
            {
                movementDir.y = 0;
                print("out of bounds Y");
            }
            else if (this.transform.position.y <= -yBounds && movementDir.y < 0)
            {
                movementDir.y = 0;
                print("out of bounds -Y");
            }

            this.transform.position += movementDir * speed * Time.deltaTime;
        }


        

        //Movement
        //this.transform.position += Vector3.up * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        //this.transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (invincible == false)
        {
            if (other.tag == "Bullet" || other.tag == "Enemy")
            {
                gameOverMenu.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
