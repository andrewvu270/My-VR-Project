using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField] GameObject timerComponents;
    [SerializeField] Image timerGraphic;
    [SerializeField] float gameTime;

    float maxGameTime;
    bool canTimerCountdown = false;

    private void Awake() => maxGameTime = gameTime;

    private void OnEnable() => GameManager.StartGame += ActivateTimer;

    private void OnDisable() => GameManager.StartGame -= ActivateTimer;

    private void ActivateTimer()
    {
        timerComponents.SetActive(true);
        canTimerCountdown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canTimerCountdown)
            return;
        UpdateTimer();
        CheckTimer();
    }

    private void UpdateTimer()
    {
        gameTime -= Time.deltaTime;

        var updateTimerGraphicValue = gameTime / maxGameTime;

        timerGraphic.fillAmount = updateTimerGraphicValue;
    }

    private void CheckTimer()
    {
        if (timerGraphic.fillAmount <= 0f)
        {
            GameManager.Instance.GameOver();
            canTimerCountdown = false;
            gameTime = maxGameTime;
        }
    }

}
