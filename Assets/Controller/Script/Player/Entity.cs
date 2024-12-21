using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]public int maxHealth;
    public int minDamge;
    public int maxDamage;

    System.Random rand = new System.Random();

    public GameObject bloodObject;
    int damage;

    [Header ("Colider info")]
    [SerializeField] private Transform groundPosition;
    [SerializeField] private float groundCheckDistance;

    [SerializeField] private Transform attackPosition;
    [SerializeField] private float groundAttackDistance;

    [SerializeField] private Transform headerPosition;
    [SerializeField] private float groundHeaderDistance;

    [SerializeField] private Transform bitPosition;
    [SerializeField] private float groundBitDistance;

    [SerializeField] private Transform flipPosition;
    [SerializeField] private float flipDistance;

    [SerializeField] public Transform defeatPosition;
    [SerializeField] public float defeatDistance;

    [SerializeField] public Transform decPosition;
    [SerializeField] public float decDistance;

    [SerializeField] public Transform preventFPosition;
    [SerializeField] public float preventFDistance;

    [SerializeField] protected float timeDashDuration;
    [SerializeField] public float timeDashLeft;

    [SerializeField] LayerMask isGround;
    [SerializeField] LayerMask isPlayer;

    public int countToSlip = 0;
    public bool checkSlip = false;
    private bool facingRight = true;
    public int facingDir=1;
    public Rigidbody2D rb;
    public Animator anim;


    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
    protected virtual void Update()
    {
        timeDashLeft -= Time.deltaTime;
    }
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")&& collision.gameObject.layer != LayerMask.NameToLayer("Item") && collision.gameObject.layer != LayerMask.NameToLayer("Star") && collision.gameObject.layer != LayerMask.NameToLayer("Door"))
        {
            countToSlip++;
            checkSlip = true;
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Item")&& collision.gameObject.layer != LayerMask.NameToLayer("Star") && collision.gameObject.layer != LayerMask.NameToLayer("Door"))
        {
            checkSlip = false;
            countToSlip--;
            if (countToSlip == -3||countToSlip==-1)
            {
                countToSlip = 0;
            }
        }
    
      

    }

    public virtual bool isGroundDetected()
    {
        return  Physics2D.Raycast(groundPosition.position, Vector2.down, groundCheckDistance, isGround);
    }
    public virtual bool isFlipDetected()
    {
        return Physics2D.Raycast(headerPosition.position, Vector2.right * facingDir, groundHeaderDistance,isGround);
    }
    public virtual bool isAttackDetected()
    {
        return Physics2D.Raycast(attackPosition.position,Vector2.right*facingDir,groundAttackDistance,isPlayer);
    }
    public virtual bool isBitDetected()
    {
        return Physics2D.Raycast(bitPosition.position, Vector2.right * facingDir, groundBitDistance, isPlayer);
    }
    public virtual bool isFlipAttackDetected()
    {
        return Physics2D.Raycast(flipPosition.position, Vector2.left * facingDir, flipDistance, isPlayer);
    }

    public virtual bool IsCheckDerDetected()
    {
        return Physics2D.Raycast(decPosition.position, Vector2.right * facingDir,decDistance, isGround);
    }
    public virtual bool IspreventFDetected()
    {
        return Physics2D.Raycast(preventFPosition.position, Vector2.left* facingDir, preventFDistance, isGround);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundPosition.position, new Vector3(groundPosition.position.x,groundPosition.position.y-groundCheckDistance));
        Gizmos.DrawLine(headerPosition.position, new Vector3(headerPosition.position.x+groundHeaderDistance * facingDir, headerPosition.position.y));
        Gizmos.DrawLine(attackPosition.position, new Vector3(attackPosition.position.x+groundAttackDistance*facingDir,attackPosition.position.y));
        Gizmos.DrawLine(bitPosition.position, new Vector3(bitPosition.position.x + groundBitDistance * facingDir, bitPosition.position.y));
        Gizmos.DrawLine(flipPosition.position, new Vector3(flipPosition.position.x - flipDistance * facingDir, flipPosition.position.y));
        Gizmos.DrawLine(decPosition.position, new Vector3(decPosition.position.x+decDistance*facingDir,decPosition.position.y));
        Gizmos.DrawLine(preventFPosition.position, new Vector3(preventFPosition.position.x - preventFDistance * facingDir, preventFPosition.position.y));
        Gizmos.DrawWireSphere(defeatPosition.position,defeatDistance);
    }

    public virtual void FlipController(int _x)
    {
        if(_x>0 && !facingRight)
        {
            Flip();
        }
        else if(_x <0 && facingRight)
        {
            Flip();
        }
    }
    public int DamageValue()
    {
        return rand.Next(minDamge,maxDamage);
    }
    public void TakeDamage(int damageValue)
    {
        if (maxHealth < 0)
        {
            return;
        }
        maxHealth = maxHealth - damageValue;
    }
    public int DoDamage(Entity entity)
    {
        damage = DamageValue();
        entity.TakeDamage(damage);
        return damage;
    }

 


    public void SetUpPoints(Entity entity)
    {
        GameObject gameObject = Instantiate(bloodObject, entity.transform.position + new Vector3(0,1f,0), Quaternion.identity);
        gameObject.SetActive(true);
      
        TextMesh textMesh = gameObject.GetComponentInChildren<TextMesh>();
        MeshRenderer textMeshRenderer = textMesh.GetComponentInChildren<MeshRenderer>();
        textMeshRenderer.sortingLayerName = "Kunai2";
        textMeshRenderer.sortingOrder = 10;
        textMesh.text = damage.ToString();
        StartCoroutine(DestroyPoints(gameObject, 0.8f));
    }
    private IEnumerator DestroyPoints(GameObject gameObject, float timePoints)
    {
        yield return new WaitForSeconds(timePoints);

        Destroy(gameObject);
    }

}
