using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour
{
    public AudioClip acornSE;
    public AudioClip cakeSE;
    public AudioClip deadSE;
    AudioSource aud;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    bool grounded = false;


    Rigidbody rb;
    Animator anim;

    GameObject director;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        this.rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector");
    }

    void Update()
    {
        Move();
        CheckGround();
        Jump();
    }

    void Move()
    {
        // 움직임 처리
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향에 따라 햄스터를 움직임
        Vector3 moveDirection = new Vector3(h, 0f, v).normalized;
        rb.velocity = moveDirection * moveSpeed;

        // 햄스터의 전방을 움직임 방향으로 맞춤
        if (moveDirection != Vector3.zero)
        {
            transform.LookAt(transform.position + moveDirection);
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            if (hit.transform.tag != null)
            {
                grounded = true;
                return;
            }
        }
        grounded = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("acorn"))
        {
            this.aud.PlayOneShot(this.acornSE);
        }
        else if (other.CompareTag("cake"))
        {
            this.aud.PlayOneShot(this.cakeSE); 
        }
        else if (other.CompareTag("dead"))
        {
            this.director.GetComponent<GameDirector>().Dead();
            this.aud.PlayOneShot(this.deadSE);
        }
    }
}



