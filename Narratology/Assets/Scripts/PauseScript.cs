using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseScript : MonoBehaviour
{
    public static bool pauseGame;
    public static bool ableToPause;
    public GameObject pauseMenu;
    

    private void Start()
    {
        ableToPause = true; 
        pauseGame = false; 
        pauseMethod(false);
    }

    public void OnPause()
    {
        if (ableToPause)
        {
            pauseGame = !pauseGame;
            pauseMethod(pauseGame);
        }
    }

    public void pauseMethod(bool pause)
    {
        
        if (pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}