using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;

    public GameObject WinCanvas;

    void Update()
    {
        if (Player.GetComponent<PlayerMovement>().Finished)
            WinCanvas.SetActive(true);
    }

    public void Reset()
    {
        WinCanvas.SetActive(false);
        Player.GetComponent<PlayerMovement>().Restart();     
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
