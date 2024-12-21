using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : PlayerState
{
    public PlayerDie(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.colliderPlayer1.enabled = false;
        player.colliderPlayer2.enabled = false;
        player.boxColliderPlayer1.enabled = true;
        rb.gravityScale = 1000;
        rb.velocity = new Vector2(0, 0);
        player.HidePlayer();
        ManagerSkill.instance.exit.ShowDefeat();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
    }
}
