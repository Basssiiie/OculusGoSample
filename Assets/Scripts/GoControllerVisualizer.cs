using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class GoControllerVisualizer : MonoBehaviour
{
    // These are the default Joystick Buttons for the Right Handed Go Controller.
    const KeyCode GoTouchpadPress = KeyCode.JoystickButton9;
    const KeyCode GoTouchpadTouch = KeyCode.JoystickButton17;
    const KeyCode GoTrigger = KeyCode.JoystickButton15;
    const KeyCode GoBack = KeyCode.Escape;

    [SerializeField] XRNode nodeType = XRNode.RightHand;

    // The Components of the different buttons on the controller, used for 
    // showing the button presses.
    [SerializeField] MeshRenderer buttonTouchpad = null;
    [SerializeField] MeshRenderer buttonTrigger = null;
    [SerializeField] MeshRenderer buttonBack = null;
    [SerializeField] Transform touchpadPointer = null;
    [SerializeField] float pointerMultiplier = 0.4f;
    
    // Colors for pressing and not pressing a button.
    [SerializeField] Color colorPressed = Color.blue;
    [SerializeField] Color colorNotPressed = Color.white;


    /// <summary>
    /// Update the Go Controller's position, rotation and the visual states
    /// of the buttons and touchpad.
    /// </summary>
    void Update()
    {
        // Position and rotation
        transform.localPosition = InputTracking.GetLocalPosition(nodeType);
        transform.localRotation = InputTracking.GetLocalRotation(nodeType);

        // Visual state of each button
        UpdateButton(buttonTouchpad, GoTouchpadPress);
        UpdateButton(buttonTrigger, GoTrigger);
        UpdateButton(buttonBack, GoBack);

        // Touchpad press location
        Vector2 padAxis = GetTouchpadAxis();
        UpdateTouchpadPointer(touchpadPointer, padAxis);
    }


    /// <summary>
    /// Updates the color of a MeshRenderer based on the state of the button.
    /// </summary>
    /// <param name="mesh">MeshRenderer of the button object.</param>
    /// <param name="button">The KeyCode to check whether the button is pressed or not.</param>
    void UpdateButton(MeshRenderer mesh, KeyCode button)
    {
        mesh.material.color = (Input.GetKey(button)) ? colorPressed : colorNotPressed;
    }


    /// <summary>
    /// Updates the local postion of the pointer Transform according to the controller axis.
    /// </summary>
    /// <param name="pointer">Movable Transform of the Pointer object.</param>
    /// <param name="axis">X and Y of the touchpad axis.</param>
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