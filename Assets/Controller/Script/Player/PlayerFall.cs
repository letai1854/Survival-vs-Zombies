using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : PlayerState
{
    public PlayerFall(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
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
        if (player.checkKunai && player.maxPower > 0 && player.maxPower >= player.swordPower)
        {
            stateMachine.ChangeState(player.playerKunai);
        }
        if (player.isGroundDetected())
        {
            stateMachine.ChangeState(player.playerIdle);    
        }
      
    }
}
