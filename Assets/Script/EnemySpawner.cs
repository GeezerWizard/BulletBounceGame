using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private BounceBullet bounceBullet;
    private Vector2 spawnBounds;
    float boundsX;
    float boundsY;

    private GameObject enemyPrefab;
    private float enemySpeed;
    private float spawnRate = 1;

    private float timer;
    private float spawnTimer;

    private void Start() {
        bounceBullet = FindObjectOfType<BounceBullet>();
        spawnBounds = new Vector2(bounceBullet.arenaX + 1, bounceBullet.arenaY + 1);
        boundsX = spawnBounds.x/2;
        boundsY = spawnBounds.y/2;
    }

    private void Update() {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;


        if (spawnTimer > spawnRate)
        {
            //Instantiate(enemyPrefab)
        }
    }

    void SetRange()
    {
        float spawnX = Random.Range(-boundsX, boundsX);
        //float spawny = get either top or bottom
    }
}
