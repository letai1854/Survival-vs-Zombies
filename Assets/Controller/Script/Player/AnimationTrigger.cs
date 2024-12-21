using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 

public class AnimationTrigger : MonoBehaviour
{
    Player player => GetComponentInParent<Player>();
    
    private void Animationtrigger()
    {
        player.AnimationTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(player.defeatPosition.position,player.defeatDistance);
        foreach(var hit in collider2Ds)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Enemy enemy = hit.GetComponent<Enemy>();
                player.DoDamage(enemy);
                //enemy.rb.velocity = new Vector2(enemy.facingDir*-0.3f,enemy.rb.velocity.y);
                enemy.transform.position = new Vector2(enemy.transform.position.x-enemy.facingDir*0.5f,enemy.transform.position.y);
                enemy.blood.Play();
                player.SetUpPoints(enemy);
                
            }
        }
    }
}
