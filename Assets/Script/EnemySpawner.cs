using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private BounceBullet bounceBullet;
    private Vector2 spawnBounds;
    float boundsX;
    float boundsY;
    float spawnBorderPad = 1;

    [SerializeField] private GameObject enemyPrefab;
    private float enemySpeed;
    private float spawnAmount;

    private float scoreTimer;
    private float spawnTimer;
    private float spawnTime = 2;
    private bool spawnEnemy = false;
    private List<GameObject> enemies = new List<GameObject>();

    private void Start() 
    {
        GameEvents.current.onPlayerDeath += StopSpawning;
        GameEvents.current.onGameStart += RestartSpawning;

        bounceBullet = FindObjectOfType<BounceBullet>();
        spawnBounds = new Vector2(bounceBullet.arenaX + spawnBorderPad, bounceBullet.arenaY + spawnBorderPad);
        boundsX = spawnBounds.x/2;
        boundsY = spawnBounds.y/2;

        StartSpawning();
    }

    void StartSpawning()
    {
        spawnEnemy = true;
    }

    void StopSpawning()
    {
        spawnEnemy = false;
        spawnAmount = 1;
        spawnTime = 3;
        spawnTimer = 0;
    }
    
    void RestartSpawning()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies = new List<GameObject>();
        StartSpawning();
    }

    private void Update() 
    {
        scoreTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnTime && spawnEnemy == true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, SetSpawnPosition(), Quaternion.identity);
                enemies.Add(newEnemy);
            }
            spawnAmount++;
            spawnTime++;
            print(spawnTime);
            spawnTimer = 0;
        }
    }

    int invertValue = 1;
    bool toggleXY;
    bool invertPosNeg;
    bool swap = false;
    int swapCountdown = 3;
    int swapCount = 0;
    Vector2 SetSpawnPosition()
    {
        Vector2 pos = Vector2.zero;
        if(swapCount != swapCountdown)
        {
            swapCount++;
        }
        else
        {
            invertPosNeg = !invertPosNeg;
            swapCount = 0;
        }
        toggleXY = !toggleXY;
        invertPosNeg = !invertPosNeg;

        if (toggleXY)
        {
            pos.x = Random.Range(-boundsX, boundsX);
            if (invertPosNeg)
            {
                pos.y = -boundsY;
            }
            if (!invertPosNeg)
            {
                pos.y = boundsY;
            }
        }
        else if (!toggleXY)
        {
            pos.y = Random.Range(-boundsY, boundsY);
            if (invertPosNeg)
            {
                pos.x = -boundsX;
            }
            if (!invertPosNeg)
            {
                pos.x = boundsX;
            }
        }
        return pos;
    }
}
