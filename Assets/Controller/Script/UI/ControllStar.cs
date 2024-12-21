using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControllStar : MonoBehaviour
{
    private void Update()
    {
        if (ManagerSkill.instance.player.countStar > 0)
        {
            ManagerInventory.instance.star.gameObject.SetActive(true);
            ManagerInventory.instance.star.UpdateTextPoint(ManagerSkill.instance.player.countStar);
           

        }
        else if (ManagerSkill.instance.player.countStar == 0)
        {
             ManagerInventory.instance.star.gameObject.SetActive(false);
        }
    }
}
