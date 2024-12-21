using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyState
{
    Enemy_ZombieMale zombieMale;
    public EnemyMove(Enemy _enemy, EnemyStateMachine _currentState, string _animName, Enemy_ZombieMale zombieMale) : base(_enemy, _currentState, _animName)
    {
        this.zombieMale = zombieMale;
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(zombieMale.enemySpeed*enemy.enemyFlip,rb.velocity.y);
        if (enemy.isAttackDetected())
        {
            
            rb.velocity = new Vector2(zombieMale.enemySpeed * enemy.enemyFlip*1.5f, rb.velocity.y);
        }
        if (!enemy.isGroundDetected())
        {

            enemy.enemyFlip *= -1;
            enemy.FlipController(enemy.enemyFlip);
        }
        if (enemy.isFlipDetected() || enemy.isFlipAttackDetected())
        {

            enemy.enemyFlip *= -1;
            enemy.FlipController(enemy.enemyFlip);
        }
        if (enemy.isBitDetected())
        {
           
            stateMachine.changeState(zombieMale.enemyAttack);
        }

        if (ManagerSkill.instance.player.transform.position.x < zombieMale.transform.position.x && enemy.facingDir == 1 && enemy.kunaiFlip)
        {
            enemy.enemyFlip *= -1;
            enemy.FlipController(enemy.enemyFlip);
        }
        if (ManagerSkill.instance.player.transform.position.x > zombieMale.transform.position.x && enemy.facingDir == -1 && enemy.kunaiFlip)
        {
            enemy.enemyFlip *= -1;
            enemy.FlipController(enemy.enemyFlip);
        }
    }
}
