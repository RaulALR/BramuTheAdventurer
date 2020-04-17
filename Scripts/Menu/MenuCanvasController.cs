using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasController : MonoBehaviour
{
    //General audio
    private AudioSource audioTheme;

    private void Start()
    {
        audioTheme = GetComponent<AudioSource>();
        audioTheme.Play();
    }

    private void Update()
    {
        audioTheme.volume = SoundController.GetVolume();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("HillLevelScene");
    }
}