using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornController : MonoBehaviour
{
    GameObject director;

    void Start()
    {
        //Application.targetFrameRate = 60;
        this.director = GameObject.Find("GameDirector");
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hamster"))
        {
            Destroy(gameObject);
            this.director.GetComponent<GameDirector>().GetAcorn();
        }
    }
}

