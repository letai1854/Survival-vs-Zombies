using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected string animName;
    public bool checkAttack = false;
    protected Rigidbody2D rb;

    public EnemyState(Enemy _enemy,EnemyStateMachine _currentState, string _animName)
    {
        this.enemy = _enemy;
        this.stateMachine = _currentState;
        this.animName = _animName;
    }

    public virtual void Enter()
    {
        enemy.anim.SetBool(animName, true);
        rb = enemy.rb;
    }
    public virtual void Update()
    {
        enemy.timeIdle -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animName, false);
    }
}
