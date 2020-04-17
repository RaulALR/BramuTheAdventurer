using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsGeneratorController : MonoBehaviour
{
    // Clouds sprites
    public GameObject cloud1;
    public GameObject cloud2;
    public GameObject cloud3;
    public GameObject cloud4;
    public GameObject cloud5;
    public GameObject cloud6;

    // State
    private enum EGeneratorState { On, Off };
    private EGeneratorState generatorState;

    void Start()
    {
        generatorState = EGeneratorState.Off;
    }

    private void Update()
    {
        if(GameController.GetGameState() != GameController.EGameState.Playing)
        {
            StopGenerator();
        }    
    }

    private void CreateCloud()
    {
        InstantiateArray(Random.Range(1, 6));
    }

    public void StartGenerator()
    {
        generatorState = EGeneratorState.On;
        RandomCloudInvokation();
    }

    public void StopGenerator()
    {
        generatorState = EGeneratorState.Off;
    }

    private EGeneratorState GetGeneratorState()
    {
        return generatorState;
    }
    private void RandomCloudInvokation()
    {
        float randomTime = Random.Range(8, 20);
        if (GetGeneratorState() == EGeneratorState.On)
        {
            CreateCloud();
            Invoke("RandomCloudInvokation", randomTime);
        }
    }

    private void InstantiateArray(int selectedCloud = 0)
    {
        switch (selectedCloud)
        {
            default:
            case 1:
                Instantiate(cloud1, GenerateHeigth(), Quaternion.identity);
                break;
            case 2:
                Instantiate(cloud2, GenerateHeigth(), Quaternion.identity);
                break;
            case 3:
                Instantiate(cloud3, GenerateHeigth(), Quaternion.identity);
                break;
            case 4:
                Instantiate(cloud4, GenerateHeigth(), Quaternion.identity);
                break;
            case 5:
                Instantiate(cloud5, GenerateHeigth(), Quaternion.identity);
                break;
            case 6:
                Instantiate(cloud6, GenerateHeigth(), Quaternion.identity);
                break;
        }
    }

    private Vector3 GenerateHeigth()
    {
        Vector3 vector = transform.position;
        float heigthModification = Random.Range(1, 3);
        float operationOption = Random.Range(0, 2);
        if(operationOption == 0)
        {
            vector.y = vector.y + heigthModification;
        } else
        {
            vector.y = vector.y - heigthModification;
        }

        vector.z = -0.5f;
        vector.x += 3;

        return vector;
    }
}