using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleWindow : MonoBehaviour
{
    [SerializeField] GameObject logItemPrefab = null;
    [SerializeField] RectTransform viewPortContent = null;
    [SerializeField] ScrollRect scrollRect = null;

    float localY = -10;


    /// <summary>
    /// Subscribe to the Log event with our method and test it with a Debug.Log().
    /// </summary>
    void Awake()
    {
        Application.logMessageReceived += OnLogMessageAdded;

        Debug.Log("Ingame console initialized!");
    }


    /// <summary>
    /// Unsubscribe from the Log event when this object gets destroyed, to avoid
    /// potential problems.
    /// </summary>
    void OnDestroy()
    {
        Application.logMessageReceived -= OnLogMessageAdded;
    }


    /// <summary>
    /// Whenever a log message is added, this method is called and it adds a new 
    /// GameObject with a Text component to the Ingame log UI.
    /// </summary>
    /// <param name="message">The log message.</param>
    /// <param name="stackTrace">The stack trace is the location from where the message was sent.</param>
    /// <param name="type">Type of log message (warning, error, log item etc.)</param>
    void OnLogMessageAdded(string message, string stackTrace, LogType type)
    {
        GameObject logItem = Instantiate(logItemPrefab, viewPortContent);
        logItem.transform.localPosition = new Vector3(10, localY);
        localY -= 70;

        Text logText = logItem.GetComponentInChildren<Text>();
        logText.text = string.Format("[{0}] {1}", type.ToString(), message);

        scrollRect.verticalNormalizedPosition = 0;
    }
}
