using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Controller : MonoBehaviour
{
    // Background rawImage
    public RawImage mountains;
    public RawImage mist;
    public RawImage farTrees;
    public RawImage nearTrees;
    public RawImage ground;
    public RawImage bush;

    // Background velocity
    [Range(0f, 10f)]
    public float mountainsVelocity = 0.02f;
    [Range(0f, 10f)]
    public float mistVelocity = 0.5f;
    [Range(0f, 10f)]
    public float farTreesVelocity = 1f;
    [Range(0f, 10f)]
    public float nearTreesVelocity = 1.5f;
    [Range(0f, 10f)]
    public float groundVelocity = 2f;
    [Range(0f, 10f)]
    public float bushVelocity = 2.5f;

    // Generators
    public GameObject cloudGenerator;
    public GameObject wolfGenerator;

    public GameObject UIGameOver;
    public GameObject UIPoints;

    public Text pointText;
    public Text currentPoints;
    public Text bestScore;

    //General audio
    private AudioSource audioTheme;


    void Start()
    {
        cloudGenerator.GetComponent<CloudsGeneratorController>().StartGenerator();
        wolfGenerator.GetComponent<WolfGeneratorController>().StartGenerator();
        GameController.SetGameState(GameController.EGameState.Playing);
        audioTheme = GetComponent<AudioSource>();
        audioTheme.Play();
    }

    void Update()
    {        
        if(GameController.GetGameState() == GameController.EGameState.Playing)
        {
            UpdateParallax();
            pointText.text = GameController.GetPoints().ToString();
        } else if (GameController.GetGameState() == GameController.EGameState.Ended)
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
        float speed = mountainsVelocity * Time.deltaTime;
        mountains.uvRect = new Rect(mountains.uvRect.x + speed, 0f, 1f, 1f);

        speed = mistVelocity * Time.deltaTime;
        mist.uvRect = new Rect(mist.uvRect.x + speed, 0f, 1f, 1f);

        speed = farTreesVelocity * Time.deltaTime;
        farTrees.uvRect = new Rect(farTrees.uvRect.x + speed, 0f, 1f, 1f);

        speed = nearTreesVelocity * Time.deltaTime;
        nearTrees.uvRect = new Rect(nearTrees.uvRect.x + speed, 0f, 1f, 1f);

        speed = groundVelocity * Time.deltaTime;
        ground.uvRect = new Rect(ground.uvRect.x + speed, 0f, 1f, 1f);

        speed = bushVelocity * Time.deltaTime;
        bush.uvRect = new Rect(bush.uvRect.x + speed, 0f, 1f, 1f);
    }

    public GameController.EGameState GetLevelState()
    {
        return GameController.GetGameState();
    }
}
