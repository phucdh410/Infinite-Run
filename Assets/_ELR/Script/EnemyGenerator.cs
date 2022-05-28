using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public bool isOver;

    public float SpeedMultiplier;
    // Start is called before the first frame update
    void Awake()
    {
        isOver = false;
        currentSpeed = MinSpeed;
        generatorEnemy();
    }

    public void setIsOver()
    {
        isOver = true;
    }

    public void GenerateNextEnemyWithGap()
    {
        if (!isOver)
        {
            float randomWait = Random.Range(0.1f,1.2f);
            Invoke("generatorEnemy", randomWait);
        }
    }


    void generatorEnemy()
    {
        GameObject EnemyIns = Instantiate(enemy, transform.position, transform.rotation);

        EnemyIns.GetComponent<EnemyScript>().enemyGenerator = this;
    }

    void Update()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier;
        }
    }
}
