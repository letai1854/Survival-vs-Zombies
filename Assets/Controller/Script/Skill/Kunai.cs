using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    private float speedSword;
    private Rigidbody2D rb;
    private CapsuleCollider2D cp;
    public Player player;
    public Enemy enemy;
    private int slipKunai;
    private bool canRotate = true;
    private void Awake()
    {
        player = ManagerSkill.instance.player;
        rb = GetComponentInParent<Rigidbody2D>();   
        cp = GetComponentInParent<CapsuleCollider2D>();
        enemy = GetComponent<Enemy>();  
    }

    private void Update()
    {
        if (canRotate)
        {
            rb.velocity = new Vector2(speedSword*slipKunai,0);
            transform.right = rb.velocity;
        }
    }
    public void SetUpKunai(float speedSword,int kunaidirec)
    {
        this.speedSword = speedSword;
        slipKunai = kunaidirec;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Player")&& collision.gameObject.layer != LayerMask.NameToLayer("UI"))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().kunaiFlip = true;

            }

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            canRotate = false;
            cp.enabled = false;
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.parent = collision.transform;
            transform.position = new Vector3 (transform.position.x+0.2f,transform.position.y,transform.position.z);
            if (enemy != null)
            {
                player.DoDamage(enemy);
                enemy.transform.position = new Vector2(enemy.transform.position.x - enemy.facingDir * 0.5f, enemy.transform.position.y);
                enemy.blood.Play();
                player.SetUpPoints(enemy);

            }
            StartCoroutine(SetKunai(collision,this, 1.0f));

        }
    }
    private IEnumerator SetKunai(Collider2D collision, Kunai kunaiObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetAtributeKunai(collision);
        kunaiObject.gameObject.SetActive(false);
        ManagerSkill.instance.poolKunai.pool.Enqueue(kunaiObject);

    }
    private void ResetAtributeKunai(Collider2D collision )
    {
        
        canRotate = true;
        cp.enabled = true;
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.None;
        transform.parent = null;
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<Enemy>().kunaiFlip = false;
            }

        }
    }
}
