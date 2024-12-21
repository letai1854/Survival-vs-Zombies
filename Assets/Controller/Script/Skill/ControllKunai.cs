using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEngine;

public class ControllKunai : MonoBehaviour
{
    public GameObject kunai;
    public float speedSword;
    void Start()
    {
          
    }

    public Kunai CreateKunai()
    {
        GameObject newKunai = Instantiate(kunai, ManagerSkill.instance.player.transform.position + 
        new Vector3(ManagerSkill.instance.player.dashLeftRight*2f,0,0), Quaternion.identity);
        newKunai.SetActive(true);
        Kunai newKunaiSword = newKunai.GetComponent<Kunai>();
        newKunaiSword.SetUpKunai(speedSword,ManagerSkill.instance.player.dashLeftRight);
        return newKunaiSword;      
    }
    
    void Update()
    {
        
    }
}
