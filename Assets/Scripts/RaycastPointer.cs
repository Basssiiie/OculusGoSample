using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPointer : MonoBehaviour
{
    // The pointer will update this line renderer to match the raycast hitpoint.
    [SerializeField] LineRenderer lineRenderer = null;


    /// <summary>
    /// On the Go controller GameObject is this RaycastPointer script. It will 
    /// shoot a raycast forwards every update and extends the LineRenderer to 
    /// the point it hits.
    /// 
    /// It also checks if the hit object has a component called RaycastListener,
    /// and if that is the case it will call OnHover on this component.
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
            Vector3 hitPosition = new Vector3(0, 0, 1000);
            lineRenderer.SetPosition(0, hitPosition);
        }
    }
}
