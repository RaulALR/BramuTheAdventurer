using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfGeneratorController : MonoBehaviour
{
    public GameObject enemyPrefab;

    // State
    private enum EGeneratorState { On, Off };
    private EGeneratorState generatorState;

    void Start()
    {
        generatorState = EGeneratorState.Off;
    }

    private void Update()
    {
        if (GameController.GetGameState() != GameController.EGameState.Playing)
        {
            StopGenerator();
        }
    }

    public void StartGenerator()
    {
        generatorState = EGeneratorState.On;
        RandomWolfInvokation();
    }

    public void StopGenerator()
    {
        generatorState = EGeneratorState.Off;
    }

    private void RandomWolfInvokation()
    {
        float randomTime = Random.Range(1.5f, 3.5f);
        if (GetGeneratorState() == EGeneratorState.On)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Invoke("RandomWolfInvokation", randomTime);
        }
    }

    private EGeneratorState GetGeneratorState()
    {
        return generatorState;
    }
}
