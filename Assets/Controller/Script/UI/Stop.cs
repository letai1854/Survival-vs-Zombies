using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stop : MonoBehaviour
{

    public Image image;
    public Image ImageButton;
    public Sprite defaultSprite; 
    public Sprite pressedSprite;
    public void StopGame()
    {
        if (!ManagerSenece.instance.checkStop)
        {
            image.gameObject.SetActive(true);
            Time.timeScale = 0f;
            ChangeButtonImage(pressedSprite);
        }
    }
    public void ResumeGame()
    {

        image.gameObject.SetActive(false);
        Time.timeScale = 1f;
        ChangeButtonImage(defaultSprite);
    }
    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        ManagerSenece.instance.ReTurnMenu();
    }
    private void ChangeButtonImage(Sprite newSprite)
    {
        ImageButton.sprite = newSprite; 
    }
}
