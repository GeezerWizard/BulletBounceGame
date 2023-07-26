using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Rigidbody2D rb;
    private float speed = 1f;

    public float SetSpeed{ set {speed = value;} }

    private void Start() {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        this.transform.position += this.transform.up * speed * Time.deltaTime;
        Vector2 lookDir = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Untagged" || other.tag == "Bullet")
        {
            gameObject.SetActive(false);
        }
    }
}
