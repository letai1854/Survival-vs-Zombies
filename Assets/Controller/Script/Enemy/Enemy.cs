using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyStateMachine stateMachine;
    public float timeIdle;
    public float timeIdleDuration;
    public float enemySpeed;
    public int enemyFlip = 1;
    public bool kunaiFlip = false;
    public ParticleSystem blood;
    public CapsuleCollider2D capCollider2DEnemy;
    public BoxCollider2D boxCollider2DEnemy;
    public Canvas canvas;
    public SpriteRenderer spriteRenderer;
    protected override void Awake()
    {
        base.Awake();
        blood.Stop();
        stateMachine = new EnemyStateMachine();
        canvas = GetComponentInChildren<Canvas>();  
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        
        stateMachine.currentState.Update();

    }

    public void DestroyEnemy()
    {
        StartCoroutine(ActiveFalse(0.3f));
    }

    public IEnumerator ActiveFalse(float time)
    {
        yield return new WaitForSeconds(4.5f);
        Color color = spriteRenderer.color;
        while (color.a > 0)
        {
            color.a -= Time.deltaTime / 4.5f;  
            spriteRenderer.color = color;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
