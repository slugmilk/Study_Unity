using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 dir) //dir�̶�� �̸��� ����3�� ���ڷ� ����
    {
        GetComponent<Rigidbody>().AddForce(dir); //dir��ŭ�� ���� ����
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
        // Shoot(new Vector3(0, 200, 2000)); //x�������δ� ��x ���� 300 ��ŭ ���� �������� 2000��ŭ ��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
