using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_victory : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public Transform star1;
    public Transform star2;
    public Transform star3;

    private void Start()
    {
 
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0.5f;
        rectTransform.transform.localPosition = new Vector3(0, -1000f, 0);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);

    }


}

