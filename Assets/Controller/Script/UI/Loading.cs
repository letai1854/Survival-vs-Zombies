using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Loading : MonoBehaviour
{
    [SerializeField] private Image _loadingFill;
    public float currentLoad = 0f;
    public float speedLoad ;
    public float fillSpeed = 0.5f;

    void Start()
    {
       
        DOTween.Init();
    }

    void Update()
    {
        
        currentLoad += Time.deltaTime * speedLoad;
        currentLoad = Mathf.Clamp01(currentLoad); 

        
        _loadingFill.DOFillAmount(currentLoad, fillSpeed);

        if (currentLoad >= 1f)
        {
            ManagerSenece.instance.Menu();
            return;
        }
    }
}
