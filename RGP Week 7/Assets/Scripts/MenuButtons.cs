using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
    }

    public void ToMapButton()
    {
        SceneManager.LoadScene(0);
    }
}
