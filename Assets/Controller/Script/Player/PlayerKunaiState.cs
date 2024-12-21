using System.Collections;
using UnityEngine;

public class PlayerKunaiState : PlayerState
{
    private bool delaySkill = false;
    private float delayTime = 0;
    public PlayerKunaiState(Player _player, PlayerStateMachine _stateMachine, string _name) : base(_player, _stateMachine, _name)
    {
    }

    public override void Enter()
    {

        if (ManagerSkill.instance.poolKunai.CheckCountPool())
        {
            ManagerSkill.instance.poolKunai.GetKunai();
        }
        player.DoPower(player.swordPower);
        base.Enter();
        ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.gun);
        rb.velocity = new Vector2(0, rb.velocity.y);
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
            if (facingDirection == 0 && player.isGroundDetected())
            {
                stateMachine.ChangeState(player.playerIdle);
            }
            else if (facingDirection != 0 && player.isGroundDetected())
            {
                stateMachine.ChangeState(player.playerMove);
            }
            else if (rb.velocity.y < 0)
            {
                stateMachine.ChangeState(player.playerFall);
            }
        }
        
    }

}
