using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    
    public void ChanageValue()
    {
        ManagerSenece.instance.volumeValue = ManagerSenece.slider.value;
        if (ManagerSenece.slider.value < 0.03f)
        {
            ManagerSenece.instance.volumeValue = 0f;
        }
        
    }
}
