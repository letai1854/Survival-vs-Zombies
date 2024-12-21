using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSkill : MonoBehaviour
{
    public static ManagerSkill instance;
    public ControllKunai controllKunai;
    public PoolKunai poolKunai;
    public Player player;
    public SoundManager soundManager;
    public UI_victory uI_Victory;
    public UI_lose uI_Lose;
    public UI_Clock uI_Clock;
    public Exit exit;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;    
        }
    }
}
