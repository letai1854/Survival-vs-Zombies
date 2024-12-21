using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();



        if (player.checkKunai && player.maxPower > 0 && player.maxPower >= player.swordPower)
        {
            stateMachine.ChangeState(player.playerKunai);
        }
        if (jump && player.isGroundDetected())
        {
            stateMachine.ChangeState(player.playerJump);
        }
        if (player.checkFight && player.maxPower > 0 && player.maxPower >= player.attackPower)
        {
            stateMachine.ChangeState(player.playerFight);
        }        

    }

    public override void Exit()
    {
        base.Exit();
    }

}
