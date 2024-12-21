using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlipState : PlayerState
{
    public PlayerSlipState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.colliderPlayer1.enabled = false;
        player.dash.enabled= false;
    }

    public override void Exit()
    {
        base.Exit();
        player.colliderPlayer1.enabled = true;
        player.dash.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        player.FlipController(player.controlLeftRight);
        player.SetVelocity(player.controlLeftRight, player.speed);
        if (player.countToSlip == 0)
        {
            if (facingDirection != 0)
            {
                stateMachine.ChangeState(player.playerMove);
            }
            else if (facingDirection == 0 && player.IsCheckDerDetected())
            {
                stateMachine.ChangeState(player.playerIdle);
            }
        }

    }
}
