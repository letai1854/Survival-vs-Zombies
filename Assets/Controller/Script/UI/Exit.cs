using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
   // Animator sprite;
    SpriteRenderer sprite;
    [SerializeField] private Transform Targettransform;
    bool checkPlayer=false;
    public bool winLose= false;
    public float moveSpeed;
    public Player player;
    private bool pass = true;
    private int i = 1;
    void Start()
    {
        //sprite = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.transform.Rotate(new Vector3(0, 0, 120f) * Time.deltaTime);
        if (checkPlayer)
        {
            float step = moveSpeed * Time.deltaTime;
            ManagerSkill.instance.player.transform.position = Vector3.MoveTowards(ManagerSkill.instance.player.transform.position, Targettransform.position, moveSpeed);
            ManagerSkill.instance.player.HidePlayer();
            if (pass)
            {
                if (ManagerSkill.instance.uI_Clock.points > 105f)
                {
                    ManagerSkill.instance.uI_Victory.star1.gameObject.SetActive(true);
                    ManagerSkill.instance.uI_Victory.star2.gameObject.SetActive(true);
                    ManagerSkill.instance.uI_Victory.star3.gameObject.SetActive(true);
                    ManagerSenece.instance.accountStar = 3;
                    ManagerSkill.instance.uI_Victory.PanelFadeIn();
              

                }
                else if (ManagerSkill.instance.uI_Clock.points > 60f)
                {
                    ManagerSkill.instance.uI_Victory.star1.gameObject.SetActive(true);
                    ManagerSkill.instance.uI_Victory.star2.gameObject.SetActive(true);
                    ManagerSenece.instance.accountStar = 2;
                    ManagerSkill.instance.uI_Victory.PanelFadeIn();
                }
                else if (ManagerSkill.instance.uI_Clock.points > 15f)
                {
                    ManagerSkill.instance.uI_Victory.star1.gameObject.SetActive(true);
                    ManagerSenece.instance.accountStar = 1;
                    ManagerSkill.instance.uI_Victory.PanelFadeIn();

                }
                ManagerSenece.instance.checkWin = true;
                checkPlayer = false;
                player.checkControl = false;
            }
            ManagerSenece.instance.checkStop = true;

        }

    }

    public void UI_Defeat()
    {
        if (ManagerSkill.instance.uI_Clock.points == 0)
        {
            ShowDefeat();
        }
        return;
    }

    public void ShowDefeat()
    {
        ManagerSkill.instance.uI_Lose.PanelFadeIn();
        ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.lose);
        player.checkControl = false;
        ManagerSenece.instance.checkStop = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")&&i==1)
        {
            ManagerSkill.instance.soundManager.PlaySFX(ManagerSkill.instance.soundManager.victory);
            checkPlayer = true;
            winLose = true;
            i++;
        }
    }
}
