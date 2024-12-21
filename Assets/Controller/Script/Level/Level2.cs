using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2 : MonoBehaviour
{
    [SerializeField] Image image;
    public void Update()
    {
        if (ManagerSenece.instance.levelPass != null)
        {
            foreach(int key in ManagerSenece.instance.levelPass.Keys)
            {
                if (key == 2)
                {
                    ManagerSenece.instance.passLevel2 = ManagerSenece.instance.levelPass[key];
                }
            }
        }

        if (ManagerSenece.instance.passLevel2 == true)
        {
            image.color = Color.white;
        }
        Debug.Log(ManagerSenece.instance.passPoints);
    }
    public void NextLevel()
    {
        ButtonSound.instance.PlaySFX();
        ManagerSenece.instance.checkLevelCurrent = 2;
        if (ManagerSenece.instance.passLevel2 == true)
        {
            ManagerSenece.instance.level2 = true;
            ManagerSenece.instance.Level2();
        }
    }
}