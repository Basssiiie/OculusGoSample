using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastListener : MonoBehaviour
{
    // A UnityEvent which will trigger when a RaycastPointer hits this Listener.
    [SerializeField] UnityEvent onHoverEvent = null;


    /// <summary>
    /// If something is hovering over this object, it will call all functions 
    /// attached to this UnityEvent.
    /// 
    /// Note: This function will only be called from RaycastPointer.cs if the 
    /// pointer is directly aiming at this object. It is not a default Unity 
    /// function.
    /// </summary>
    public void OnHover()
    {
        onHoverEvent.Invoke();
    }
}
