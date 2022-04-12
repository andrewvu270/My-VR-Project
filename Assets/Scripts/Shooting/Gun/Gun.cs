using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    [Header("Grab interactables")]
    [SerializeField] XRGrabInteractable grabInteractable;
    
    [Header("Raycasting Info")]
    [Tooltip("All the features required for raycasting")]
    [SerializeField] Transform raycastOrigin;
    [SerializeField] LayerMask targetLayer;
    
    [Header("SFX")]
    [SerializeField] AudioClip gunClipSFX;
    AudioSource gunAudioSource;

    [Header("Target hit graphic")]
    [SerializeField] GameObject hitGraphic;

    private void Awake()
    {
        if(TryGetComponent(out AudioSource audio))
        {
            gunAudioSource = audio;
        }
        else
        {
            gunAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
    }

    private void OnEnable()
    {
        grabInteractable.activated.AddListener(TriggerPulled);
    }

    private void OnDisable()
    {
        grabInteractable.activated.RemoveListener(TriggerPulled);
    }

    private void TriggerPulled(ActivateEventArgs arg0)
    {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);
        gunAudioSource.PlayOneShot(gunClipSFX);
        FireRaycastIntoScene();
    }

    private void FireRaycastIntoScene()
    {
        RaycastHit hit;

        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
        {
            if(hit.transform.GetComponent<ITargetInterface>() != null)
            {
                Debug.Log($"<color=green> Hit target {hit.transform.name}</color>");
                hit.transform.GetComponent<ITargetInterface>().TargetShot();

                if (!GameManager.Instance.ShouldCreateHitGraphic)
                {
                    return;
                }
                CreatHitGraphicOnTarget(hit.point);
            }
            else
            {
                Debug.Log("Not inheriting from interface");
            }
        }
    }

    private void CreatHitGraphicOnTarget(Vector3 hitLocation)
    {
        GameObject hitMarker = Instantiate(hitGraphic, hitLocation, Quaternion.identity);
    }
}
