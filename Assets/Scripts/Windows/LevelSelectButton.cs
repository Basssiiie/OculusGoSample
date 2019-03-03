using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] string levelName = string.Empty;


    public void OnHoverButton()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
