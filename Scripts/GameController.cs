using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // States
    public enum EGameState { Idle, Playing, Ended, Ready }
    static private EGameState gameState = EGameState.Idle;
    static private string currentLevel = "HillLevelScene";

    // Points
    static int actualPoints = 0;

    static public void SetGameState(EGameState gameStateChange = EGameState.Idle)
    {
        gameState = gameStateChange;
    }

    static public EGameState GetGameState()
    {
        return gameState;
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    static public void RestartPoint(string level = "Level1")
    {
        if (actualPoints > PlayerPrefs.GetInt(level))
        {
            PlayerPrefs.SetInt(level, actualPoints);
        }
        actualPoints = 0;
    }

    static public void IncreasePoint(int point = 0)
    {
        actualPoints += point;
        UpdateLevelLock();
    }

    static public int GetPoints()
    {
        return actualPoints;
    }

    static public void SetCurrentLevel(string level)
    {
        currentLevel = level;
    }

    static public string GetCurrentLevel()
    {
        return currentLevel;
    }

    static private void UpdateLevelLock()
    {
        if(GetCurrentLevel() == "HillLevelScene" && GetPoints() > 50 && (PlayerPrefs.GetString("UnlockLevel2").Equals("")))
        {
            PlayerPrefs.SetString("UnlockLevel2", "True");
        }
    }

    static public bool GetLockLevel(int level)
    {
        bool levelState = false;
        switch (level)
        {
            case 2:
                levelState = PlayerPrefs.GetString("UnlockLevel2") == "True" ? true : false;
                break;
        }
        return levelState;
    }

    // Scenes
    public void LoadLevel1()
    {
        SceneManager.LoadScene("HillLevelScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("JungleLevelScene");
    }
}
