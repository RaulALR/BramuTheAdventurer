using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    // State
    public enum EAudioState { On, Off };
    static private EAudioState audioState = EAudioState.On;

    // Images 
    public Sprite soundOnImg;
    public Sprite soundOffImg;

    public Image soundImg;
    private bool imgState = false;

    private void Start()
    {
        imgState = GetVolume() == 0 ? false : true;
        SetImage();
    }

    private void Update()
    {
    }

    public void SetImage()
    {
        if(imgState)
        {
            SetAudioState(EAudioState.On);
            soundImg.sprite = soundOnImg;
            SetVolume();
        } else
        {
            SetAudioState(EAudioState.Off);
            soundImg.sprite = soundOffImg;
            SetVolume();
        }

        imgState = !imgState;
    }

    static public EAudioState GetAudioState()
    {
        return audioState;
    }
    static public void SetAudioState(EAudioState state = EAudioState.Off)
    {
        audioState = state;
    }
    static public void SetVolume()
    {
        if (GetAudioState() == EAudioState.On)
        {
            PlayerPrefs.SetInt("Volume", 100);
        }
        else
        {
            PlayerPrefs.SetInt("Volume", 0);
        }
    }

    static public int GetVolume()
    {
        return PlayerPrefs.GetInt("Volume");
    }
}
