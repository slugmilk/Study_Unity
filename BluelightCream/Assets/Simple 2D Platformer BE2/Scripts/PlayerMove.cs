using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public HealthBar healthBar;  // HealthBar 스크립트를 연결합니다
    public float healthDecreaseAmount = 20f;  // Enemy와 충돌 시 감소할 체력량

    private GameManager gameManager;  // GameManager 스크립트 참조
    public string gameClearSceneName = "GameClear";  // GameClear 씬 이름

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();  // GameManager 찾기
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }


            // stop speed
            if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);

        }

        // direction sprite
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if(Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // move speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // max speed
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed*(-1))
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);

        // landing platform
        if (rigid.velocity.y <= 0)
        {
            Debug.DrawRay(rigid.position + Vector2.down * 0.1f, Vector3.down * 1f, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position + Vector2.down * 0.1f, Vector3.down, 1f, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.6f)
                    anim.SetBool("isJumping", false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDammaged(collision.transform.position);
            Debug.Log("Enemy와 충돌");
            healthBar.DecreaseHealth(healthDecreaseAmount);
        }
        else if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("Finish 충돌");
            if (gameManager.healthBar.CurrentHealth > 0)
            {
                gameManager.LoadGameClearScene();
            }
        }
    }

    void OnDammaged(Vector2 targetPos)
    {
        gameObject.layer = 8;

        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x-targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1)*10, ForceMode2D.Impulse);

        Invoke("OffDamaged", 3);
    }

    void OffDamaged()
    {
        gameObject.layer = 7;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
