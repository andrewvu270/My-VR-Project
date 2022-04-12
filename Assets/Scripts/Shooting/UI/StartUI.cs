using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartUI : MonoBehaviour, ITargetInterface
{
    [SerializeField] TextMeshProUGUI uiText;
    [SerializeField] GameObject[] controlGameObjects;

    public void TargetShot()
    {
        uiText.text = "GET READY!!";
        /*Invoke("StartGame", 2f);*/
        StartCoroutine("GameStartDelay");
    }

    IEnumerator GameStartDelay()
    {
        yield return new WaitForSeconds(1);
        uiText.text = "3";
        yield return new WaitForSeconds(1);
        uiText.text = "2";
        yield return new WaitForSeconds(1);
        uiText.text = "1";
        yield return new WaitForSeconds(1);
        uiText.text = "GO";
        yield return new WaitForSeconds(1);

        StartGame();
    }

    public void Playanimation()
    {
        
    }

    public void Playaudio()
    {
        
    }

    void StartGame()
    {
        GameManager.Instance.GameStart();
        
        foreach(GameObject currentGameObject in controlGameObjects)
        {
            currentGameObject.SetActive(false);
        }

/*        this.gameObject.SetActive(false);*/
    }

}
