using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameoverUI;

    public PlayerController playerController;

    public void ShowGameOverUI()
    {
        gameoverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
        {
            playerController.canLook = false;
        }
        
        Time.timeScale = 0f;
    }

    public void HideGameOverUI()
    {
        gameoverUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (playerController != null)
        {
            playerController.canLook = true;
        }
        
        Time.timeScale = 1f;
    }
}
