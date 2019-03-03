using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    // The colors for the different actions.
    [SerializeField] Color colorHover = Color.yellow;
    [SerializeField] Color colorTrigger = Color.red;
    [SerializeField] Color colorReturn = Color.white;

    // The mesh renderer of which the color will change.
    MeshRenderer meshRenderer = null;
    

    /// <summary>
    /// This Component requires a MeshRenderer, so retrieve it.
    /// </summary>
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    /// <summary>
    /// If this function is called, it will change colors depending on which 
    /// buttons are held.
    /// </summary>
    public void OnChangeColor()
    {
        // Both the Trigger and Touchpad Button trigger a 'mouse 0' key event.
        if (Input.GetButton("Fire1"))
        {
            meshRenderer.material.color = colorTrigger;
        }
        // The Back button trigger an 'escape' key event.
        else if (Input.GetButton("Cancel"))
        {
            meshRenderer.material.color = colorReturn;
        }
        else
        {
            meshRenderer.material.color = colorHover;
        }
    }
}
