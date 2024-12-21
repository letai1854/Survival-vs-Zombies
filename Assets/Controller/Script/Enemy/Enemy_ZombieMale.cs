using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ZombieMale : Enemy
{


    public EnemyIdle enemyIdle { get; private set; }
    public EnemyMove enemyMove { get; private set; }

    public EnemyDie enemyDie { get; private set; }

    public EnemyAttackState enemyAttack { get; private set; }


    protected override void Awake()
    {
        base.Awake();
        enemyIdle = new EnemyIdle(this,stateMachine,"Idle",this);
        enemyMove = new EnemyMove(this,stateMachine,"Move",this);
        enemyAttack = new EnemyAttackState(this, stateMachine, "Attack",this);
        enemyDie = new EnemyDie(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(enemyIdle);
    }

    protected override void Update()
    {
        base.Update();
        if (maxHealth < 0)
        {
            stateMachine.changeState(enemyDie);
        }
        
    }
    public void AnimationAttackFinish()
    {
        stateMachine.currentState.checkAttack = true;
    }

}
