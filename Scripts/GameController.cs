using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // States
    public enum EGameState { Idle, Playing, Ended, Ready }
    static private EGameState gameState = EGameState.Idle;

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
    }

    static public int GetPoints()
    {
        return actualPoints;
    }

    // Scenes
    public void LoadLevel1()
    {
        SceneManager.LoadScene("HillLevelScene");
    }
}
