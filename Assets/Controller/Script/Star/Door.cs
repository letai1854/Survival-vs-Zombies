using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (ManagerSkill.instance.player.countStar == 3)
            {
                gameObject.SetActive(false);
                ManagerSkill.instance.player.countStar = 0;
            }
        }
    }
}
