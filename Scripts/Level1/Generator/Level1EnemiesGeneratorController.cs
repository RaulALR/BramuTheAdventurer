using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1EnemiesGeneratorController : MonoBehaviour
{
    public GameObject wolfPrefab;
    public GameObject wildPigPrefab;
    public GameObject bearPrefab;

    // State
    private enum EGeneratorState { On, Off };
    private EGeneratorState generatorState;

    // Spawn time
    float randomWolfTime;
    float randomWildPigTime;
    float randomBearTime;

    void Start()
    {
        generatorState = EGeneratorState.Off;
        randomWolfTime = Random.Range(1.5f, 3.5f);
        randomWildPigTime = Random.Range(4f, 7f); 
        randomBearTime = Random.Range(8f, 12f);
        GetRandomGenerate();
    }

    private void Update()
    {
        if (GameController.GetGameState() != GameController.EGameState.Playing)
        {
            StopGenerator();
        } else
        {
            GetRandomGenerate();
        }
    }

    public void StartGenerator()
    {
        generatorState = EGeneratorState.On;
        RandomWolfInvokation();
        RandomWildPigInvokation();
        RandomBearInvokation();
    }

    public void StopGenerator()
    {
        generatorState = EGeneratorState.Off;
    }

    private void RandomWolfInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            Instantiate(wolfPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            Invoke("RandomWolfInvokation", randomWolfTime);
        }
    }

    private void RandomWildPigInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            if (GameController.GetPoints() > 5)
            {
                Instantiate(wildPigPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            }
            Invoke("RandomWildPigInvokation", randomWildPigTime);
        }
    }
    private void RandomBearInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            if (GameController.GetPoints() > 15)
            {
                Instantiate(bearPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            }
            Invoke("RandomBearInvokation", randomBearTime);
        }
    }

    private EGeneratorState GetGeneratorState()
    {
        return generatorState;
    }

    private Vector3 CalculateXPosition(Vector3 vector)
    {
    GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (allEnemies.Length > 0)
        {
            if (allEnemies[allEnemies.Length - 1].transform.position.x > 3)
            {
                vector.x = allEnemies[allEnemies.Length - 1].transform.position.x + 8f; 
            }
        }

        return vector;
    }

    private void GetRandomGenerate()
    {
        if(GameController.GetPoints() < 5)
        {
            randomWolfTime = Random.Range(1.5f, 3.5f);
        } else if(GameController.GetPoints() > 5)
        {
            randomWildPigTime = Random.Range(4f, 7f);
            randomWolfTime = Random.Range(3f, 5.5f);
        } else if (GameController.GetPoints() > 15)
        {
            randomWildPigTime = Random.Range(5f, 8f);
            randomWolfTime = Random.Range(4f, 6.5f);
            randomBearTime = Random.Range(8f, 12f);
        }
    }
}
