using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
   
    public void NextLevel()
    {
       
        ManagerSenece.instance.checkLevelCurrent = 1;
        ManagerSenece.instance.level1 = true;
        ManagerSenece.instance.Level1();
    }
}
