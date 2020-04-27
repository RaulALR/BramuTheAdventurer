using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2EnemiesGeneratorController : MonoBehaviour
{
    public GameObject spiderPrefab;
    public GameObject trollPrefab;
    public GameObject tigerPrefab;

    // State
    private enum EGeneratorState { On, Off };
    private EGeneratorState generatorState;

    // Spawn time
    float randomSpiderTime;
    float randomTrollTime;
    float randomTigerTime;

    void Start()
    {
        generatorState = EGeneratorState.Off;
        randomSpiderTime = Random.Range(1.5f, 3.5f);
        randomTrollTime = Random.Range(4f, 7f); 
        randomTigerTime = Random.Range(8f, 12f);
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
        RandomSpiderInvokation();
        RandomTrollInvokation();
        RandomTigerInvokation();
    }

    public void StopGenerator()
    {
        generatorState = EGeneratorState.Off;
    }

    private void RandomSpiderInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            Instantiate(spiderPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            Invoke("RandomSpiderInvokation", randomSpiderTime);
        }
    }

    private void RandomTrollInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            if (GameController.GetPoints() > 5)
            {
                Instantiate(trollPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            }
            Invoke("RandomTrollInvokation", randomTrollTime);
        }
    }
    private void RandomTigerInvokation()
    {
        if (GetGeneratorState() == EGeneratorState.On)
        {
            if (GameController.GetPoints() > 15)
            {
                Instantiate(tigerPrefab, CalculateXPosition(transform.position), Quaternion.identity);
            }
            Invoke("RandomTigerInvokation", randomTigerTime);
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
            randomSpiderTime = Random.Range(1.5f, 2.5f);
        } else if(GameController.GetPoints() > 5)
        {
            randomTrollTime = Random.Range(3f, 6f);
            randomSpiderTime = Random.Range(2f, 4.5f);
        } else if (GameController.GetPoints() > 15)
        {
            randomTrollTime = Random.Range(4f, 7f);
            randomSpiderTime = Random.Range(3f, 5.5f);
            randomTigerTime = Random.Range(7f, 11f);
        }
    }
}
