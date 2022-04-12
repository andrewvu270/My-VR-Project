using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] GameObject popup;
    private void OnEnable()
    {
        if (Selection.Contains(gameObject))
            Debug.Log("I'm selected!");
    }


}
