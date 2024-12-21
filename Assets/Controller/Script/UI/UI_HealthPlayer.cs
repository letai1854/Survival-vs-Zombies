using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI_HealthPlayer : MonoBehaviour
{
    public float currentHealth;
    public Player player;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Gradient _colorGradient;
    public float fiilSpeed;
    void Start()
    {
        currentHealth = player.maxHealth;
    }
    private void Update()
    {
        UpdateHealthBar();
    }
    public void UpdateHealth(int amount)
    {
        player.maxHealth += amount;
        if (player.maxHealth > currentHealth)
        {
            player.maxHealth = (int)currentHealth;
        }
        player.healthEffect.Play();
        UpdateHealthBar();


    }

    private void UpdateHealthBar()
    {
        //currentHealth = Mathf.Clamp(player.maxHealth,0f,currentHealth);
        float targetFillAmount = player.maxHealth/currentHealth ;
        //_healthBarFill.fillAmount = targetFillAmount;
        _healthBarFill.DOFillAmount(targetFillAmount,fiilSpeed);
        _healthBarFill.color = _colorGradient.Evaluate(targetFillAmount);
    }
    
 
}
