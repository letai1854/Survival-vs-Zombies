using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_lose : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
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
