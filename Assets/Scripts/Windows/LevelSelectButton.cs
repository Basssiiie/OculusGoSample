using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButton : MonoBehaviour
{
    // Name of the level
    [SerializeField] string levelName = string.Empty;


    /// <summary>
    /// If this method is called and the player presses the Fire1 button, load
    /// the level specified in levelName.
    /// </summary>
    public void OnHoverButton()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
