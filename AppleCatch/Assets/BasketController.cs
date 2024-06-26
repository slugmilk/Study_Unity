using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            // Debug.Log("Tag=Apple");
        }
        else
        {
            this.aud.PlayOneShot(this.bombSE);
            // Debug.Log("Tag=Bomb");
        }
        // Debug.Log("¿‚æ“¥Ÿ!");
        Destroy(other.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                this.transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
