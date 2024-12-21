using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemyFinish : MonoBehaviour
{
    public Enemy_ZombieMale zombieMale;
    void Start()
    {
       
    }

    // Update is called once per frame
    public void checkAttackFinish()
    {
        zombieMale.AnimationAttackFinish();
    }
    private void AttackTrigger()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(zombieMale.defeatPosition.position,zombieMale.defeatDistance);
        foreach (var hit in collider2Ds)
        {
            if (hit.GetComponent<Player>() != null)
            {
                Player player = hit.GetComponent<Player>();
                zombieMale.DoDamage(player);
                player.blood.Play();
                player.ChangeColor();
                zombieMale.SetUpPoints(player);
            }
        }
    }
}
