using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameClearUI gameClearUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameClearUI.ShowGameClearUI();
        }
    }
}
