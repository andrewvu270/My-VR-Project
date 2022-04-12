using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public delegate void OnGameStart();
    public static event OnGameStart StartGame;

    public delegate void OnGameEnd();
    public static event OnGameEnd EndGame;

    private float score;

    public float Score { get { return score; } }

    private bool shouldCreateHitGraphic = false;

    public bool ShouldCreateHitGraphic { get { return shouldCreateHitGraphic; } }

    public void PlayerScored(float targetValue)
    {
        score = score + targetValue;

        Debug.Log(score);
    }

    public void GameStart()
    {
        Debug.Log("Game Started!");

        //Fire the start game event (used by: ActivateTarget.cs)
        StartGame();
        shouldCreateHitGraphic = true;
    }

    public void GameOver()
    {
        EndGame();
    }

}
