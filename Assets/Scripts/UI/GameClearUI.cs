using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClearUI : MonoBehaviour
{
    public GameObject gameClearUI;

    public PlayerController playerController;
    
    public void ShowGameClearUI()
    {
        gameClearUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (playerController != null)
        {
            playerController.canLook = false;
        }
        
        Time.timeScale = 0;
    }
}
