using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class GoControllerVisualizer : MonoBehaviour
{
    const KeyCode GoTouchpadPress = KeyCode.JoystickButton9;
    const KeyCode GoTouchpadTouch = KeyCode.JoystickButton17;
    const KeyCode GoTrigger = KeyCode.JoystickButton15;
    const KeyCode GoBack = KeyCode.Escape;

    [SerializeField] XRNode nodeType = XRNode.RightHand;
    
    [SerializeField] MeshRenderer buttonTouchpad = null;
    [SerializeField] MeshRenderer buttonTrigger = null;
    [SerializeField] MeshRenderer buttonBack = null;
    [SerializeField] Transform touchpadPointer = null;
    [SerializeField] float pointerMultiplier = 0.4f;
    
    [SerializeField] Color colorPressed = Color.blue;
    [SerializeField] Color colorNotPressed = Color.white;


    void Update()
    {
        transform.localPosition = InputTracking.GetLocalPosition(nodeType);
        transform.localRotation = InputTracking.GetLocalRotation(nodeType);

        UpdateButton(buttonTouchpad, GoTouchpadPress);
        UpdateButton(buttonTrigger, GoTrigger);
        UpdateButton(buttonBack, GoBack);

        Vector2 padAxis = GetTouchpadAxis();
        UpdateTouchpadPointer(touchpadPointer, padAxis);
    }


    void UpdateButton(MeshRenderer mesh, KeyCode button)
    {
        mesh.material.color = (Input.GetKey(button)) ? colorPressed : colorNotPressed;
    }


    void UpdateTouchpadPointer(Transform pointer, Vector2 axis)
    {
        pointer.localPosition = new Vector3(axis.x * pointerMultiplier, 0, axis.y * pointerMultiplier);
    }


    /// <summary>
    /// The touchpad axis use the X and Y axis for joysticks, as set in 
    /// the InputManager.
    /// 
    /// Note: note that the left-handed and right-handed controllers have
    /// different axis. This one is currently set for right-handed.
    /// </summary>
    Vector2 GetTouchpadAxis()
    {
        return new Vector2(Input.GetAxis("GoHorizontal"), Input.GetAxis("GoVertical"));
    }
}