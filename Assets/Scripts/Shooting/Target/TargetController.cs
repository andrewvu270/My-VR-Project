using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour, ITargetInterface
{
    [SerializeField] float targetScoreValue;

    public void TargetShot()
    {
        /*Destroy(gameObject);*/
        Playanimation();
        Playaudio();
        GameManager.Instance.PlayerScored(targetScoreValue);
    }

    public void Playanimation()
    {
        
    }

    public void Playaudio()
    {
        
    }

}
