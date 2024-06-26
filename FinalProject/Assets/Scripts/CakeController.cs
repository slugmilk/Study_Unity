using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeController : MonoBehaviour
{
    GameObject director;

    // Start is called before the first frame update
    void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hamster"))
        {
            Destroy(gameObject);
            this.director.GetComponent<GameDirector>().GetCake();
        }
    }
}
