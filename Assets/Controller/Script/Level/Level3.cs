using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3 : MonoBehaviour
{
    [SerializeField] Image image;
    public void Update()
    {
        if (ManagerSenece.instance.levelPass != null)
        {
            foreach (int key in ManagerSenece.instance.levelPass.Keys)
            {
                if (key == 3)
                {
                    ManagerSenece.instance.passLevel3 = ManagerSenece.instance.levelPass[key];
                }
            }
        }
        if (ManagerSenece.instance.passLevel3 == true /*anagerSenece.instance.passPoints == 3 || ManagerSenece.instance.passPoints == 4*/)
        {
            image.color = Color.white;
        }
    }   
    public void NextLevel()
    {
        ButtonSound.instance.PlaySFX();
        ManagerSenece.instance.checkLevelCurrent = 3;
        if (ManagerSenece.instance.passLevel3 == true)
        {
            ManagerSenece.instance.level3 = true;
            ManagerSenece.instance.Level3();
        }
    }
}
