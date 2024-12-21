using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    private string animBoolName;
    protected Rigidbody2D rb;
    public int facingDirection = 0;
    public bool jump = false;
    public bool triggerCall = false; 

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _name )
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _name;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
    }
    public virtual void Update()
    {
        player.anim.SetFloat("Yvelocity",rb.velocity.y);
        facingDirection = player.controlLeftRight;
        jump = player.jumpControll;
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
    public virtual void animationTrigger()
    {
        triggerCall = true;
    }
}
