using System.Collections;

using UnityEngine;


public class ListStarLevel1 : MonoBehaviour
{
    [SerializeField] public GameObject star1;
    [SerializeField] public GameObject star2;
    [SerializeField] public GameObject star3;
    private void Start()
    {

    }

    public void AddStar()
    {
        if (ManagerSenece.instance.listStar1.Count < 4 && ManagerSenece.instance.listStar1.Count != 3)
        {
            if(star1 != null)
            {
            ManagerSenece.instance.listStar1.Add(star1);

            }

            if (star2 != null)
            {
            ManagerSenece.instance.listStar1.Add(star2);

            }

            if (star3 != null)
            {
            ManagerSenece.instance.listStar1.Add(star3);

            }
        }
    }
}
