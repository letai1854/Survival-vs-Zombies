using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightState : PlayerState
{
    public PlayerFightState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
        rb.velocity = new Vector2(0,rb.velocity.y);
        player.DoPower(player.attackPower);
        player.VolumeAttack();
    }

    public override void Exit()
    {
        base.Exit();
        triggerCall = false;
    }

    public override void Update()
    {
        base.Update();
        if (triggerCall)
        {
            stateMachine.ChangeState(player.playerIdle);
        }
    }
}
