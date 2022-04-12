using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject target;
    private void OnEnable() => GameManager.EndGame += ActivateGameOverUI;
    private void OnDisable() => GameManager.EndGame -= ActivateGameOverUI;

    private void ActivateGameOverUI()
    {
        gameOverCanvas.SetActive(true);
        target.SetActive(true);
    }
}
