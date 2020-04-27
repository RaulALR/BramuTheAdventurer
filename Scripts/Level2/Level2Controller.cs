using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Controller : MonoBehaviour
{
    // Background rawImage
    public RawImage trees1;
    public RawImage trees2;
    public RawImage trees3;
    public RawImage trees4;
    public RawImage ground;

    // Background velocity
    private float trees1Velocity = 0.02f;
    private float trees2Velocity = 0.04f;
    private float trees3Velocity = 0.06f;
    private float trees4Velocity = 0.08f;
    private float groundVelocity = 0.1f;

    // Generators
    public GameObject birdGenerator;
    public GameObject enemiesGenerator;

    public GameObject UIGameOver;
    public GameObject UIPoints;

    public Text pointText;
    public Text currentPoints;
    public Text bestScore;

    //General audio
    private AudioSource audioTheme;


    void Start()
    {
        GameController.SetCurrentLevel("JungleLevelScene");
        birdGenerator.GetComponent<BirdGeneratorController>().StartGenerator();
        enemiesGenerator.GetComponent<Level2EnemiesGeneratorController>().StartGenerator();
        GameController.SetGameState(GameController.EGameState.Playing);
        audioTheme = GetComponent<AudioSource>();
        audioTheme.Play();
    }

    void Update()
    {
        if (GameController.GetGameState() == GameController.EGameState.Playing)
        {
            UpdateParallax();
            pointText.text = GameController.GetPoints().ToString();
        }
        else if (GameController.GetGameState() == GameController.EGameState.Ended)
        {
            UIGameOver.SetActive(true);
            UIPoints.SetActive(false);
            currentPoints.text = "Current points: " + pointText.text.ToString();
            bestScore.text = "Best score: " + PlayerPrefs.GetInt("Level1").ToString();
            GameController.RestartPoint();
        }

        audioTheme.volume = SoundController.GetVolume();
    }

    private void UpdateParallax()
    {
        float speed = trees1Velocity * Time.deltaTime;
        trees1.uvRect = new Rect(trees1.uvRect.x + speed, 0f, 1f, 1f);

        speed = trees2Velocity * Time.deltaTime;
        trees2.uvRect = new Rect(trees2.uvRect.x + speed, 0f, 1f, 1f);

        speed = trees3Velocity * Time.deltaTime;
        trees3.uvRect = new Rect(trees3.uvRect.x + speed, 0f, 1f, 1f);

        speed = trees4Velocity * Time.deltaTime;
        trees4.uvRect = new Rect(trees4.uvRect.x + speed, 0f, 1f, 1f);

        speed = groundVelocity * Time.deltaTime;
        ground.uvRect = new Rect(ground.uvRect.x + speed, 0f, 1f, 1f);
    }

    public GameController.EGameState GetLevelState()
    {
        return GameController.GetGameState();
    }
}
