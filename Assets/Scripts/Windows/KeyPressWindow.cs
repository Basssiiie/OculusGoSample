using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressWindow : MonoBehaviour
{
    [SerializeField] Text currentKeysText = null;

    Array keyCodes = null;


    void Start()
    {
        keyCodes = Enum.GetValues(typeof(KeyCode));
    }


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
