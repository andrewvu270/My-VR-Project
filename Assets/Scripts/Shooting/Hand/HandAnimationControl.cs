using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationControl : MonoBehaviour
{
    [SerializeField] Animator handAnimator;
    [SerializeField] InputActionReference gripAction;
    [SerializeField] InputActionReference pinchAction;

    private void OnEnable()
    {
        //Creating listeners for input actions

        //Fire off method 'GripAnimation' after grip action is performed
        gripAction.action.performed += GripAnimation;
        pinchAction.action.performed += PinchAction;
    }

    private void PinchAction(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripAnimation(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }
}
