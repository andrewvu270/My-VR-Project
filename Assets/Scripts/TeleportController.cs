using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportController : MonoBehaviour
{
    public GameObject baseControllerGameObject;
    public GameObject teleportationControllerGameObject;

    public InputActionReference teleportActivationReference;
    [Space]//Add some space in Unity inspector
    public UnityEvent onTeleportActivate;
    public UnityEvent onTeleportCancel;
    
    private void Start()
    {
        //Assign methods (events) to action performed 
        teleportActivationReference.action.performed += TeleportModeActivate;
        teleportActivationReference.action.canceled += TeleportModeCancel;
    }

    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        //Call deactivate method after an amount of time (0.1 second)
        //Purpose: after player remove their finger from joystick, we need to give them time to teleport so we shouldnt invoke deactivate right away
        Invoke("DeactivateTeleporter", .1f);//1st argument is name of the method        
    }

    void DeactivateTeleporter() => onTeleportCancel.Invoke();

    private void TeleportModeActivate(InputAction.CallbackContext obj) => onTeleportActivate.Invoke();//Used expression body to make function tidy
}
