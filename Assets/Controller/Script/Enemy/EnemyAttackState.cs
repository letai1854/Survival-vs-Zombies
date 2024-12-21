using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    Enemy_ZombieMale zombieMale;
    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _currentState, string _animName, Enemy_ZombieMale zombieMale) : base(_enemy, _currentState, _animName)
    {
        this.zombieMale = zombieMale;
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(0,rb.velocity.y);
        ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.zombieBite);

    }

    public override void Exit()
    {
        base.Exit();
        checkAttack = false;
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(checkAttack);
        if (checkAttack == true)
        {
            stateMachine.changeState(zombieMale.enemyMove);
        }
        if ( enemy.isFlipAttackDetected())
        {

            enemy.enemyFlip *= -1;
            enemy.FlipController(enemy.enemyFlip);
        }
    }
}
