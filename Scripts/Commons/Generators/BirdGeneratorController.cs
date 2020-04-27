using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdGeneratorController : MonoBehaviour
{
    // Clouds sprites
    public GameObject raven;
    public GameObject redBird;
    public GameObject blueBird;

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

    private void CreateBird()
    {
        InstantiateArray(Random.Range(1, 3));
    }

    public void StartGenerator()
    {
        generatorState = EGeneratorState.On;
        RandomBirdInvokation();
    }

    public void StopGenerator()
    {
        generatorState = EGeneratorState.Off;
    }

    private EGeneratorState GetGeneratorState()
    {
        return generatorState;
    }
    private void RandomBirdInvokation()
    {
        float randomTime = Random.Range(8, 20);
        if (GetGeneratorState() == EGeneratorState.On)
        {
            CreateBird();
            Invoke("RandomBirdInvokation", randomTime);
        }
    }

    private void InstantiateArray(int selectedCloud = 0)
    {
        switch (selectedCloud)
        {
            default:
            case 1:
                Instantiate(raven, GenerateHeigth(), Quaternion.identity);
                break;
            case 2:
                Instantiate(redBird, GenerateHeigth(), Quaternion.identity);
                break;
            case 3:
                Instantiate(blueBird, GenerateHeigth(), Quaternion.identity);
                break;
        }
    }

    private Vector3 GenerateHeigth()
    {
        Vector3 vector = transform.position;
        float heigthModification = Random.Range(1f, 3f);
        float operationOption = Random.Range(0, 2);
        if (operationOption == 0)
        {
            vector.y = vector.y + heigthModification;
        }
        else
        {
            vector.y = vector.y - heigthModification;
        }

        vector.z = -0.5f;
        vector.x += 3;

        return vector;
    }
}
