using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private int i = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")&& i==1)
        {
            ManagerSkill.instance.player.countStar++;
            ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.item);
            i++;
            gameObject.SetActive(false);
        }
        
    }
}
