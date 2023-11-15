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
    [SerializeField] private ScoreManager scoreManager;
    private float xBounds;
    private float yBounds;

    Vector3 mousePos;

    Vector3 movementDir = Vector3.zero;
    
    void Start() 
    {
        GameEvents.current.onGameStart += NewGame;

        xBounds = bb.arenaX/2;
        yBounds = bb.arenaY/2;
    }

    void Update()
    {
        //Looking at mouse
        float distance = rb.transform.position.y - Camera.main.transform.position.y; 
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));        
        Vector2 lookDir = mousePos - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;

        if (Input.anyKey)
        {
            movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            if (this.transform.position.x >= xBounds && movementDir.x > 0)
            {
                movementDir.x = 0;
            }
            else if (this.transform.position.x <= -xBounds && movementDir.x < 0)
            {
                movementDir.x = 0;
            }
            if (this.transform.position.z >= yBounds && movementDir.y > 0)
            {
                movementDir.y = 0;
            }
            else if (this.transform.position.z <= -yBounds && movementDir.y < 0)
            {
                movementDir.y = 0;
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
                scoreManager.SetEndGameText(other.tag);
                GameEvents.current.PlayerDeath();
                gameOverMenu.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void NewGame()
    {
        gameObject.transform.position = Vector3.zero;
        gameObject.SetActive(true);
    }
}
