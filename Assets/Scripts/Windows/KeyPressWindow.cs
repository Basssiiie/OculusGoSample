using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressWindow : MonoBehaviour
{
    // The Text Component which to update with all the key names.
    [SerializeField] Text currentKeysText = null;

    // This array store all KeyCode values.
    Array keyCodes = null;


    /// <summary>
    /// Save all possible KeyCode values to a reusable array to improve performance.
    /// </summary>
    void Start()
    {
        keyCodes = Enum.GetValues(typeof(KeyCode));
    }


    /// <summary>
    /// Every update, go through all available KeyCodes and check whether it 
    /// is pressed. If it is currently pressed, add the name of the key to the 
    /// Text panel.
    /// </summary>
    void Update()
    {
        StringBuilder builder = new StringBuilder("<b>Keys:</b>\n", 32);

        foreach (KeyCode kcode in keyCodes)
        {
            if (Input.GetKey(kcode))
                builder.AppendLine(kcode.ToString());
        }

        currentKeysText.text = builder.ToString();
    }
}
