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


    void Awake()
    {
        Application.logMessageReceived += OnLogMessageAdded;

        Debug.Log("Ingame console initialized!");
    }


    void OnDestroy()
    {
        Application.logMessageReceived -= OnLogMessageAdded;
    }


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
