using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Power : MonoBehaviour
{
    public float currentPower;
    public Player player;
    [SerializeField] private Image powerBarFill;
    [SerializeField] private Gradient _colorGradient;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    public float fiilSpeed;
    void Start()
    {
        currentPower = player.maxPower;
        _textMeshPro.text = "100%";
    }
    private void Update()
    {
        UpdatePowerBar();
    }
    public void UpdatePower(int amount)
    {

            player.maxPower += amount;
            if (player.maxPower > currentPower)
            {
                player.maxPower = (int)currentPower;
            }
            player.powerEffect.Play();
            UpdatePowerBar();  
    }

    private void UpdatePowerBar()
    {
        //currentHealth = Mathf.Clamp(player.maxHealth,0f,currentHealth);
        float targetFillAmount = player.maxPower / currentPower;
        //_healthBarFill.fillAmount = targetFillAmount;
        powerBarFill.DOFillAmount(targetFillAmount, fiilSpeed);
        powerBarFill.color = _colorGradient.Evaluate(targetFillAmount);
        if (player.maxPower < 0)
        {
            _textMeshPro.text = "0"+"%";
        }
        else
        {
            _textMeshPro.text = player.maxPower.ToString() + "%";
        }
        
    }
}
