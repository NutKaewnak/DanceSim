using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    public void LoadClicked()
    {
        this.StartCoroutine(this.OpenLoadScreen());        
    }

    private IEnumerator OpenLoadScreen()
    {
        ScreenManager.Instance.OpenLoadScreen();

        Player.Instance.MovementController.enabled = false;

        while (ScreenManager.Instance.SaveGameScreen.gameObject.activeInHierarchy)
            yield return null;

        Player.Instance.MovementController.enabled = true;
    }
}