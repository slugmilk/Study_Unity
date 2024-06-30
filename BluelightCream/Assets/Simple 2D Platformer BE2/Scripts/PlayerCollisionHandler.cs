using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public HealthBar healthBar;  // HealthBar 스크립트를 연결합니다
    public float healthIncreaseAmount = 10f;  // Silver와 충돌 시 증가할 체력량
    public float healthDecreaseAmount = 20f;  // Enemy와 충돌 시 감소할 체력량
    private GameManager gameManager;  // GameManager 스크립트 참조
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();  // GameManager 찾기
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 감지: " + collision.name);

        if (collision.CompareTag("Silver"))
        {
            Debug.Log("Silver와 충돌");
            healthBar.IncreaseHealth(healthIncreaseAmount);
            Destroy(collision.gameObject);  // Silver 객체를 제거합니다
        }
    }
}

