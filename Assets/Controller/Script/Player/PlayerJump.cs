using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerJump : PlayerState
{
    public PlayerJump(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(rb.velocity.x, player.jumpSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        rb.velocity = new Vector2(facingDirection*player.speed, rb.velocity.y);
        if (player.checkKunai && player.CheckPower() && player.maxPower >= player.swordPower)
        {
            stateMachine.ChangeState(player.playerKunai);
        }
        if (rb.velocity.y<0)
        {
            stateMachine.ChangeState(player.playerFall);
        }
    }
}
