using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class UI_HealthEnemy : MonoBehaviour
{
    public float currentHealth;
    public Enemy enemy;
    [SerializeField] private Image _healthBarFill;
    [SerializeField] private Gradient _colorGradient;
    public float fiilSpeed;
    void Start()
    {
        currentHealth = enemy.maxHealth;
    }
    private void Update()
    {
        if (enemy.facingDir == 1)
        {
            _healthBarFill.fillOrigin = (int)Image.OriginHorizontal.Left;
        }
        if (enemy.facingDir == -1)
        {
            _healthBarFill.fillOrigin = (int)Image.OriginHorizontal.Right;
        }
        UpdateHealthBar();
    }
    public void UpdateHealth(float amount)
    {
        currentHealth += amount;
    }

    private void UpdateHealthBar()
    {
        //currentHealth = Mathf.Clamp(player.maxHealth,0f,currentHealth);
        float targetFillAmount = enemy.maxHealth / currentHealth;
     
        //_healthBarFill.fillAmount = targetFillAmount;
        _healthBarFill.DOFillAmount(targetFillAmount, fiilSpeed);
        _healthBarFill.color = _colorGradient.Evaluate(targetFillAmount);
    }
}
