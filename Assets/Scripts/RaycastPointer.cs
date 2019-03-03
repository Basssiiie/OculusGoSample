using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointer : MonoBehaviour
{
    // The pointer will update this line renderer to match the raycast hitpoint.
    [SerializeField] LineRenderer lineRenderer = null;


    /// <summary>
    /// This RaycastPointer script should be on the Go controller GameObject. 
    /// It will shoot a raycast forwards every update and extends the 
    /// LineRenderer to the point it hits.
    /// 
    /// It also checks if the hit object has a component called RaycastListener.
    /// If it has a RaycastListener component, it will call OnHover on this 
    /// component EVERY LateUpdate.
    /// 
    /// Note: I recommend building a OnHoverEnter/OnHoverExit system instead of 
    /// this system here. This one is purely for exemplary purposes.
    /// </summary>
    void LateUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo))
        {
            Vector3 hitPosition = new Vector3(0, 0, hitInfo.distance);
            lineRenderer.SetPosition(0, hitPosition);

            // Look for any listener and call OnHover if it was found.
            RaycastListener listener = hitInfo.transform.GetComponent<RaycastListener>();
            if (listener != null)
            {
                listener.OnHover();
            }
        }
        else
        {
            // Set the LineRenderer to render towards the horizon.
            // 1000m in front of the Go Controller.
            Vector3 hitPosition = new Vector3(0, 0, 1000);
            lineRenderer.SetPosition(0, hitPosition);
        }
    }
}
