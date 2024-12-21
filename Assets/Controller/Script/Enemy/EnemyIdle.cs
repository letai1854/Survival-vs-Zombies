using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    Enemy_ZombieMale zombieMale;
    public EnemyIdle(Enemy _enemy, EnemyStateMachine _currentState, string _animName, Enemy_ZombieMale zombieMale) : base(_enemy, _currentState, _animName)
    {
        this.zombieMale = zombieMale;
    }

    public override void Enter()
    {
        base.Enter();
        zombieMale.timeIdle = zombieMale.timeIdleDuration;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (zombieMale.timeIdle < 0|| enemy.isAttackDetected())
        {
            stateMachine.changeState(zombieMale.enemyMove);
        }
         
    }
}
