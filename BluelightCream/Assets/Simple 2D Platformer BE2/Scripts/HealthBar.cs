using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;  // 체력바 이미지
    public float maxHealth = 100f;  // 최대 체력
    private float currentHealth;  // 현재 체력
    public float healthDecreaseRate = 5f;  // 초당 체력 감소량

    // 현재 체력을 반환하는 public 프로퍼티
    public float CurrentHealth => currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (currentHealth > 0)
        {
            currentHealth -= healthDecreaseRate * Time.deltaTime;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            UpdateHealthBar();
        }
    }

    void UpdateHealthBar()
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }
}
