using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] XRBaseInteractable grabbedObject;
    private Pose _originPoint;
    private Rigidbody rb;
    private void OnEnable() => grabbedObject.selectExited.AddListener(ObjectReleased);
     
    private void OnDisable() => grabbedObject.selectExited.RemoveListener(ObjectReleased);
      
    private void Awake()
    {
        _originPoint.position = this.transform.position;
        _originPoint.rotation = this.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    private void ObjectReleased(SelectExitEventArgs arg0)
    {
        //        Turn off the rigidbody
        rb.Sleep();

        //        Turn off collider
        GetComponent<Collider>().enabled = false;

        //        Return object to origin
        Debug.Log("Object released");
        this.transform.position = _originPoint.position;
        this.transform.rotation = _originPoint.rotation;

        //        Turn on the rigidbody
        /*rb.WakeUp();*/

        //        Turn on collider
        GetComponent<Collider>().enabled = true;
    }
}
