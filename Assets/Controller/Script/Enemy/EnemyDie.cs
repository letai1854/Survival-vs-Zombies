using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : EnemyState
{
    Enemy_ZombieMale zombieMale;
    public EnemyDie(Enemy _enemy, EnemyStateMachine _currentState, string _animName, Enemy_ZombieMale zombieMale) : base(_enemy, _currentState, _animName)
    {
        this.zombieMale = zombieMale;
       
    }

    public override void Enter()
    {
        base.Enter();
        zombieMale.boxCollider2DEnemy.enabled = true;
        zombieMale.capCollider2DEnemy.enabled = false;
        rb.velocity = new Vector2(0,0);
        enemy.canvas.enabled = false;
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void Update()
    {
        base.Update();
        zombieMale.DestroyEnemy();
    }
}
