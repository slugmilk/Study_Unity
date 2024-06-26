using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController2 : MonoBehaviour
{
    public float speed = 10f;
    public float jumpPower = 5f;
    bool isJumping;

    Rigidbody rb;
    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            isJumping = true;
    }

    void FixedUpdate()
    {
        Run();
        Jump();
    }

    void Run()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        move.Set(h, 0, v);
        move = move.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + move);
    }
    void Jump()
    {
        if(!isJumping)
            return;

        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        isJumping = false;
    }
}
