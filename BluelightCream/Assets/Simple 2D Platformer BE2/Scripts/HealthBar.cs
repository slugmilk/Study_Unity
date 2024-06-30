using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;  // ü�¹� �̹���
    public float maxHealth = 100f;  // �ִ� ü��
    private float currentHealth;  // ���� ü��
    public float healthDecreaseRate = 5f;  // �ʴ� ü�� ���ҷ�

    // ���� ü���� ��ȯ�ϴ� public ������Ƽ
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
