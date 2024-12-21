using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
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
       
        player.FlipController(player.controlLeftRight);
        player.SetVelocity(player.controlLeftRight, player.speed);
        if ( facingDirection != 0 &&(player.countToSlip ==1 || player.countToSlip ==2)&& !player.IsCheckDerDetected() &&!player.IspreventFDetected())
        {
            player.colliderPlayer1.enabled = false;
            stateMachine.ChangeState(player.playerSlip);
        }
        if (player.checkKunai && player.maxPower > 0 && player.maxPower>=player.swordPower)
        {
            stateMachine.ChangeState(player.playerKunai);
        }
        if (player.checkFight && player.maxPower > 0 && player.maxPower >= player.attackPower)
        {
            stateMachine.ChangeState(player.playerFight);
        }
        if (jump && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.playerJump);
        }
    
        if ((facingDirection == 0 && player.isGroundDetected()))
        {
            stateMachine.ChangeState(player.playerIdle);
        }
    }
}
