using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.dashTimeLeft = player.dashDuration;
        player.trail.emitting = true;
        player.DoPower(player.dashPower);
        ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.dash);
        if (player.dashLeftRight == 0)
        {
            player.dashLeftRight = 1;
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.trail.emitting = false;

        if (player.isGroundDetected())
        {
            rb.velocity = new Vector2(0, 0);
    
        }

    }

    public override void Update()
    {
        base.Update();
        player.FlipController(player.controlLeftRight);
        rb.velocity = new Vector2(player.dashLeftRight*player.dashSpeed,0);
        if (player.dashTimeLeft < 0)
        {           
            if (facingDirection == 0 && player.isGroundDetected())
            {
                rb.velocity = new Vector2(0, 0);
                stateMachine.ChangeState(player.playerIdle);
            }            
            else if (player.dashTimeLeft < 0)
            {
                stateMachine.ChangeState(player.playerFall);
            }
        }
    }
    
}
