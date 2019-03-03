using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsGraphWindow : MonoBehaviour
{
    [SerializeField] GameObject graphLinePrefab = null;
    [SerializeField] Text framePerSecondText = null;
    [SerializeField] RectTransform graphContainer = null;
    [SerializeField] float graphHeightMultiplier = 5f;
    [SerializeField] float graphLineDistance = 5f;

    Queue<RectTransform> graphLines = new Queue<RectTransform>();

    const float fpsCheckRate = 0.25f;
    int currentFrameCount = 0;
    float timeSinceLastCheck = 0f;

    
    void Update()
    {
        // Calculate the frames per second
        currentFrameCount++;
        timeSinceLastCheck += Time.unscaledDeltaTime;
        if (timeSinceLastCheck > fpsCheckRate)
        {
            float currentFPS = currentFrameCount / timeSinceLastCheck;
            currentFrameCount = 0;
            timeSinceLastCheck = 0;

            // Update the window parts
            SetFpsText(currentFPS);
            AddLine(currentFPS * graphHeightMultiplier);
        }
    }


    void SetFpsText(float fps)
    {
        framePerSecondText.text = ("FPS: " + fps);
    }


    void AddLine(float height)
    {
        bool isFull = IsGraphFull();
        RectTransform lineTransform = null;

        if (isFull)
        {
            lineTransform = graphLines.Dequeue();

            MoveGraph();
        }
        else
        {
            lineTransform = CreateLine();
        }

        lineTransform.sizeDelta = new Vector2(lineTransform.sizeDelta.x, height);

        graphLines.Enqueue(lineTransform);
    }

    
    RectTransform CreateLine()
    {
        GameObject lineObject = Instantiate(graphLinePrefab, graphContainer);
        RectTransform lineTransform = lineObject.GetComponent<RectTransform>();

        lineTransform.localPosition = new Vector3(graphLineDistance * graphLines.Count, 0);
        return lineTransform;
    }


    void MoveGraph()
    {
        float currentX = 0;

        foreach (RectTransform line in graphLines)
        {
            line.localPosition = new Vector3(currentX, 0);

            currentX += graphLineDistance;
        }
    }


    bool IsGraphFull()
    {
        return (graphLineDistance * graphLines.Count >= graphContainer.sizeDelta.x);
    }
}
