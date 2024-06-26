using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f;
    float walkForce = 60.0f;
    float maxWalkSpeed = 5.0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        int key = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        if (key != 0) // key 값이 가질 수 있는 값은 0, 1, -1 총 3개
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        this.animator.speed = speedx / 3.0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("골");
        SceneManager.LoadScene("ClearScene");
    }
}
