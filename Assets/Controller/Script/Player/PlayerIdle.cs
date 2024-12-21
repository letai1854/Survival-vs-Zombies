using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerGroundedState
{
    public PlayerIdle(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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


        rb.velocity = new Vector2(0, rb.velocity.y);

        if (facingDirection != 0 && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.playerMove);
        }
    }
}
