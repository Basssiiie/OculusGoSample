using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class NodeDebugWindow  : MonoBehaviour
{
    [SerializeField] Text deviceName = null;
    [SerializeField] GameObject nodePanelPrefab = null;
    [SerializeField] RectTransform panelContainer = null;
    [SerializeField] float nodePanelDistance = 100f;

    List<Text> nodePanels = new List<Text>();

    
    /// <summary>
    /// Update all the node panels every frame.
    /// </summary>
    void Update()
    {
        // Update the device name, refresh rate and state
        StringBuilder builder = new StringBuilder("Device: ", 32);
        builder.AppendLine(XRDevice.model);

        builder.Append("Refresh rate: ");
        builder.Append(XRDevice.refreshRate);
        builder.AppendLine(" Hz.");


        builder.Append("User state: ");
        builder.AppendLine(XRDevice.userPresence.ToString());

        deviceName.text = builder.ToString();

        // Get all the XR nodes
        List<XRNodeState> currentNodes = new List<XRNodeState>();
        InputTracking.GetNodeStates(currentNodes);

        int nodeCount = currentNodes.Count;
        int panelCount = nodePanels.Count;

        // Create amount of panels matching amount of nodes
        if (panelCount < nodeCount)
        {
            for (int i = panelCount; i < nodeCount; i++)
            {
                CreatePanel(i);
            }
        }

        // Updating info for nodes
        int index = 0;
        for (; index < nodeCount; index++)
        {
            UpdateInfo(nodePanels[index], currentNodes[index]);
        }

        // Set the rest of the panels to unavailable
        for (; index < panelCount; index++)
        {
            nodePanels[index].text = "Unavailabe";
        }
    }


    /// <summary>
    /// Creates a panel at this index.
    /// </summary>
    /// <param name="index">The index determines the local X position of this panel.</param>
    void CreatePanel(int index)
    {
        GameObject panelObj = Instantiate(nodePanelPrefab, panelContainer);
        panelObj.transform.localPosition = new Vector3(nodePanelDistance * index, 0);

        Text textPanel = panelObj.GetComponentInChildren<Text>();

        if (textPanel != null)
            nodePanels.Add(textPanel);
    }


    /// <summary>
    /// Updates the information on this TextPanel according to the information 
    /// in the XRNodeState.
    /// </summary>
    /// <param name="textPanel">The Text Component which to update.</param>
    /// <param name="node">The XRNodeState containing the information.</param>
    void UpdateInfo(Text textPanel, XRNodeState node)
    {
        StringBuilder builder = new StringBuilder(128);

        // Base node information
        builder.Append("Node type: ");
        builder.AppendLine(node.nodeType.ToString());

        builder.Append("ID: ");
        builder.AppendLine(node.uniqueID.ToString());

        builder.Append("Is tracked: ");
        builder.AppendLine(node.tracked.ToString());

        // Position
        builder.Append("Pos: ");
        if (node.TryGetPosition(out Vector3 position))
        {
            builder.AppendLine(position.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Rotation
        builder.Append("Rot: ");
        if (node.TryGetRotation(out Quaternion rotation))
        {
            builder.AppendLine(rotation.eulerAngles.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Velocity
        builder.Append("Vel: ");
        if (node.TryGetVelocity(out Vector3 velocity))
        {
            builder.AppendLine(velocity.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Acceleration
        builder.Append("Acc: ");
        if (node.TryGetAcceleration(out Vector3 acceleration))
        {
            builder.AppendLine(acceleration.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Angular velocity
        builder.Append("Ang. Vel: ");
        if (node.TryGetAngularVelocity(out Vector3 angVelocity))
        {
            builder.AppendLine(angVelocity.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Angular acceleration
        builder.Append("Ang. Acc: ");
        if (node.TryGetAngularAcceleration(out Vector3 angAcceleration))
        {
            builder.AppendLine(angAcceleration.ToString());
        }
        else
        {
            builder.AppendLine("unknown");
        }

        // Apply the string to the text panel
        textPanel.text = builder.ToString();
    }
}
