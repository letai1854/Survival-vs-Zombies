using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public float jumpSpeed;
    public float speed;
    public int controlLeftRight = 0;
    public bool checkFight;
    public bool checkKunai;
    public float dashSpeed;
    public float dashDuration;
    public float dashTimeLeft;
    public int dashLeftRight;
    public float kunaiTimeLeft;
    public float kunaiDuration;
    public int maxPower;
    public int dashPower;
    public int swordPower;
    public int attackPower;
    public bool jumpControll { get; private set; }
    public TrailRenderer trail;

    public ParticleSystem blood;
    public ParticleSystem healthEffect;
    public ParticleSystem powerEffect;
    [Header("Button")]
    public Jump jump;
    public Left left;
    public Right right;
    public Fight fight;
    public Dash dash;
    public Sword sword;

    public GameObject kunai;

    public CapsuleCollider2D colliderPlayer1;
    public CapsuleCollider2D colliderPlayer2;
    public BoxCollider2D boxColliderPlayer1;



    public SpriteRenderer spritePlayer;


    public float timecolor;
    private bool checkColorTime = false;

    public int countStar;
    public bool checkControl=true;
    #region PlayerState
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdle playerIdle { get; private set; }
    public PlayerMoveState playerMove { get; private set; }
    public PlayerJump playerJump { get; private set; }
    public PlayerFall playerFall { get; private set; }


    public PlayerSlipState playerSlip { get; private set; }

    public PlayerFightState playerFight { get; private set; }

    public PlayerDashState playerDash { get; private set; }

    public PlayerKunaiState playerKunai { get; private set; }

    public PlayerDie playerDie { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();
        blood.Stop();
        healthEffect.Stop();
        powerEffect.Stop();
        stateMachine = new PlayerStateMachine();

        playerIdle = new PlayerIdle(this, stateMachine, "Idle");
        playerMove = new PlayerMoveState(this, stateMachine, "Move");
        playerJump = new PlayerJump(this, stateMachine, "Jump");
        playerFall = new PlayerFall(this, stateMachine, "Jump");
        playerSlip = new PlayerSlipState(this, stateMachine, "Slip");
        playerFight = new PlayerFightState(this, stateMachine, "Fight");
        playerDash = new PlayerDashState(this, stateMachine, "Dash");
        playerKunai = new PlayerKunaiState(this, stateMachine, "Kunai");
        playerDie = new PlayerDie(this, stateMachine, "Die");

    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(playerIdle);
        trail = GetComponent<TrailRenderer>();
        spritePlayer = GetComponentInChildren<SpriteRenderer>();
        


    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        if (checkControl)
        {
            ControllJoystick();
            SKillDash();
            SkillKunai();
            if (maxHealth < 0)
            {
                stateMachine.ChangeState(playerDie);
            }
        }
        ManagerSkill.instance.exit.UI_Defeat();
    }

    private void SKillDash()
    {
        dashTimeLeft -= Time.deltaTime;
        if (dash.checkDash && timeDashLeft < 0 && maxPower > 0 && maxPower >= dashPower)
        {
            stateMachine.ChangeState(playerDash);
            timeDashLeft = timeDashDuration;
        }
    }

    private void ControllJoystick()
    {

        if (fight.checkFight)
        {
            checkFight = true;
        }
        else if (!fight.checkFight)
        {
            checkFight = false;
        }
        if (!jump.checkJump)
        {
            jumpControll = false;
        }
        else if (jump.checkJump)
        {
            jumpControll = true;
        }
        if (left.checkLeftRight == -1)
        {
            controlLeftRight = -1;
            dashLeftRight = -1;
        }
        else if (right.checkLeftRight == 1)
        {
            controlLeftRight = 1;
            dashLeftRight = 1;
        }
        else if (left.checkLeftRight == 0 && right.checkLeftRight == 0)
        {
            controlLeftRight = 0;
        }
    }

    private void SkillKunai()
    {
        kunaiTimeLeft -= Time.deltaTime;
        if (ManagerSkill.instance.poolKunai.pool.Count == 0)
        {
            kunaiTimeLeft = kunaiDuration;
        }
        if (sword.checkSword && kunaiTimeLeft < 0)
        {
            checkKunai = true;
        }
        else if (!sword.checkSword)
        {
            checkKunai = false;
        }
    }

    public void SetVelocity(int controlLeftRight, float _playerSpeed)

    {
        rb.velocity = new Vector2(controlLeftRight * _playerSpeed, rb.velocity.y);
    }
    public void AnimationTrigger() => stateMachine.currentState.animationTrigger();

    public void DoPower(int power)
    {
        if (maxPower < 0)
        {
            return;
        }
        maxPower -= power;
    }
    public bool CheckPower()
    {
        if (maxPower <= 0)
        {
            return false;
        }
        return true;
    }
    public void ChangeColor()
    {
      
        StartCoroutine(TimeChangeColor(timecolor));

    }
    public void VolumeAttack()
    {
        StartCoroutine(AudioAttack(0.3f));
    }

    public IEnumerator AudioAttack(float time)
    {
        yield return new WaitForSeconds(time);
        ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.sword);
    }
    public IEnumerator TimeChangeColor(float time) 
    {
        float elapsedTime = 0f;
        float cycleInterval = 0.4f; 
        Color pink = new Color(1.0f, 0.75f, 0.8f, 1.0f);
        while (elapsedTime < time)
        {
            spritePlayer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spritePlayer.color = pink;
            yield return new WaitForSeconds(0.2f);


            elapsedTime += 2 * cycleInterval; 
        }

        spritePlayer.color = Color.white;
        checkColorTime = true;
    }
    public void HidePlayer()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(ActiveFalse(0.3f));
        }

    }

    public IEnumerator ActiveFalse(float time)
    {
       
        yield return new WaitForSeconds(0.5f);
        Color color = spritePlayer.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime / 2f;
            spritePlayer.color = color;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
