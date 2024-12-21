using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
    public void SelfActive(GameObject gameButton)
    {
        ButtonSound.instance.PlaySFX();
        gameButton.SetActive(true);
    }
    public void SelfActiveNone(GameObject gameButton)
    {
        gameButton.SetActive(false);
    }
    public void QuitGame()
    {
        ButtonSound.instance.PlaySFX();
        Application.Quit();
    }
}
