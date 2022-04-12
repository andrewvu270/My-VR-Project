using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStartTarget : MonoBehaviour, ITargetInterface
{

    public UnityEvent onTargetShot;
/*    public AudioClip targetHitSFX;
*/
    private Collider col;
/*    private AudioSource targetAudioSource;
    private Animator animator;
*/
    private void Awake()
    {
/*        targetAudioSource = GetComponent<AudioSource>();*/
        col = GetComponent<Collider>();
        /*animator = GetComponent<Animator>();*/
    }

    public void Shot()
    {
        col.enabled = false;
        onTargetShot.Invoke();
/*        Playaudio();*/
/*        Playanimation();*/    }

    public void Playanimation()
    {
/*        animator.Play("StartTargetAnim");*/
    }

    public void Playaudio()
    {
/*        targetAudioSource.PlayOneShot(targetHitSFX);*/
    }

    public void TargetShot()
    {
        this.gameObject.SetActive(false);
    }

}
