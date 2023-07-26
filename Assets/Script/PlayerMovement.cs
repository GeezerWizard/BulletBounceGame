using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private bool invincible = false;

    Vector3 mousePos;

    void Update()
    {
        //Looking at mouse
        float distance = rb.transform.position.z - Camera.main.transform.position.z; 
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));        
        Vector2 lookDir = mousePos - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;

        //Movement
        this.transform.position += Vector3.up * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        this.transform.position += Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
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
