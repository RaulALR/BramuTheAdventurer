using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvasController : MonoBehaviour
{
    //General audio
    private AudioSource audioTheme;

    public GameObject IUActionButtons;
    public GameObject IULevelsButtons;

    private string selectedLevel = "HillLevelScene";

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
        SceneManager.LoadScene(selectedLevel);
    }

    public void OnClickSelectLevelButton()
    {
        IUActionButtons.SetActive(false);
        IULevelsButtons.SetActive(true);
        Button[] buttons = IULevelsButtons.GetComponentsInChildren<Button>();
        if (!GameController.GetLockLevel(2))
        {
            buttons[1].interactable = false;
            buttons[1].GetComponentsInChildren<Text>()[0].color = Color.grey;
            buttons[1].GetComponentsInChildren<Text>()[0].text = "Level 2 - Jungle (Unlocks with 50 points at level 1)";
        } else
        {
            buttons[1].GetComponentsInChildren<Text>()[0].text = "Level 2 - Jungle";
        }

        if (!GameController.GetLockLevel(3))
        {
            buttons[2].interactable = false;
            buttons[2].GetComponentsInChildren<Text>()[0].color = Color.grey;
            buttons[2].GetComponentsInChildren<Text>()[0].text = "Level 3 - Sky IN DEV";
        }
        else
        {
            buttons[2].GetComponentsInChildren<Text>()[0].text = "Level 3 - Sky";
        }
    }

    public void OnClickSelectLevel(string level)
    {
        selectedLevel = level;
        IULevelsButtons.SetActive(false);
        IUActionButtons.SetActive(true);
    }
}