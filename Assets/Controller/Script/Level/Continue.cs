using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class Continue : MonoBehaviour
{
    public void ReturnMenu()
    {
        ManagerSenece.instance.checkReturn = true;

        if (ManagerSenece.instance.checkWin)
        {
            if(ManagerSenece.instance.checkLevelCurrent ==1 && ManagerSenece.instance.level == 1)
            {
                ManagerSenece.instance.level++;
                ManagerSenece.instance.passPoints=1;
                ManagerSenece.instance.passLevel2 = true;


            }
            if (ManagerSenece.instance.checkLevelCurrent == 2 && ManagerSenece.instance.level == 2)
            {
                ManagerSenece.instance.level++;
                ManagerSenece.instance.passPoints=2;
                ManagerSenece.instance.passLevel3 = true;

 
            }
            if (ManagerSenece.instance.checkLevelCurrent == 3 && ManagerSenece.instance.level == 3)
            {
                ManagerSenece.instance.level++;
                ManagerSenece.instance.passPoints=3;


            }
            if (!ManagerSenece.instance.levelPass.ContainsKey(2))
            {
                ManagerSenece.instance.levelPass.Add(2, ManagerSenece.instance.passLevel2);
            }
            else
            {

                    ManagerSenece.instance.levelPass[2] = ManagerSenece.instance.passLevel2;

            }

            if (!ManagerSenece.instance.levelPass.ContainsKey(3))
            {
                ManagerSenece.instance.levelPass.Add(3, ManagerSenece.instance.passLevel3);
            }
            else
            {

                 ManagerSenece.instance.levelPass[3] = ManagerSenece.instance.passLevel3;
              
            }


            if (!ManagerSenece.instance.levelStar.ContainsKey(ManagerSenece.instance.passPoints))
            {
                ManagerSenece.instance.levelStar.Add(ManagerSenece.instance.passPoints, ManagerSenece.instance.accountStar);
            }
            else
            {
                foreach (int level in ManagerSenece.instance.levelStar.Keys)
                {

                   
                    if (level == ManagerSenece.instance.passPoints)
                    {
                        
                        if(ManagerSenece.instance.levelStar[level] < ManagerSenece.instance.accountStar)
                        {
                            ManagerSenece.instance.levelStar[level] = ManagerSenece.instance.accountStar;
                           
                        }
                        
                       
                    }
                    
                    break;
                }
            }

            if (ManagerSenece.instance.level1 && ManagerSenece.instance.levelStar.ContainsKey(1))
            {
                if (ManagerSenece.instance.levelStar[1] < ManagerSenece.instance.accountStar)
                {
                    ManagerSenece.instance.levelStar[1] = ManagerSenece.instance.accountStar;

                }
            }
            if (ManagerSenece.instance.level2 && ManagerSenece.instance.levelStar.ContainsKey(2))
            {
                if (ManagerSenece.instance.levelStar[2] < ManagerSenece.instance.accountStar)
                {
                    ManagerSenece.instance.levelStar[2] = ManagerSenece.instance.accountStar;

                }
            }
            if (ManagerSenece.instance.level3 && ManagerSenece.instance.levelStar.ContainsKey(3))
            {
                if (ManagerSenece.instance.levelStar[3] < ManagerSenece.instance.accountStar)
                {
                    ManagerSenece.instance.levelStar[3] = ManagerSenece.instance.accountStar;

                }
            }
            SaveSystem.SaveLevel(ManagerSenece.instance.levelStar);
            SaveSystem.SaveLevelPass(ManagerSenece.instance.levelPass);
            SaveSystem.SaveIndex(ManagerSenece.instance.level);
        }



        ManagerSenece.instance.checkStop = false;
        ManagerSenece.instance.level1 = false;
        ManagerSenece.instance.level2 = false;
        ManagerSenece.instance.level3 = false;
        ManagerSenece.instance.checkWin = false;
        ManagerSenece.instance.ReTurnMenu();
    }
}
