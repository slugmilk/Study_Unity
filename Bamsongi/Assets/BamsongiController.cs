using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 dir) //dir이라는 이름의 벡터3을 인자로 받음
    {
        GetComponent<Rigidbody>().AddForce(dir); //dir만큼의 힘을 가함
    }

    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // Shoot(new Vector3(0, 200, 2000)); //x방향으로는 힘x 위로 300 만큼 과녁 방향으로 2000만큼 힘
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
