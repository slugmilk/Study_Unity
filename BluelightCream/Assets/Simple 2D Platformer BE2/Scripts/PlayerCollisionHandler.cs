using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public HealthBar healthBar;  // HealthBar ��ũ��Ʈ�� �����մϴ�
    public float healthIncreaseAmount = 10f;  // Silver�� �浹 �� ������ ü�·�
    public float healthDecreaseAmount = 20f;  // Enemy�� �浹 �� ������ ü�·�
    private GameManager gameManager;  // GameManager ��ũ��Ʈ ����
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();  // GameManager ã��
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹 ����: " + collision.name);

        if (collision.CompareTag("Silver"))
        {
            Debug.Log("Silver�� �浹");
            healthBar.IncreaseHealth(healthIncreaseAmount);
            Destroy(collision.gameObject);  // Silver ��ü�� �����մϴ�
        }
    }
}

