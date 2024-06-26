using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject hpText;
    public float time = 60.0f;
    int point = 0;
    public float hp = 3;

    public void GetAcorn()
    {
        this.point += 1;
    }

    public void GetCake()
    {
        this.hp -= 0.5f;
    }

    public void Dead()
    {
        this.hp = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.hpText = GameObject.Find("hp");

    }

    // Update is called once per frame
    void Update()
    {
        if (hp ==0)
        {
            time = 0;
        }
        if (time > 0)
        {
            this.time -= Time.deltaTime;
        }
        else if (time == 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            this.time = 0;
        }
        this.timerText.GetComponent<TextMeshProUGUI>().text = this.time.ToString("F1");
        this.pointText.GetComponent<TextMeshProUGUI>().text = this.point.ToString() + " point";
        this.hpText.GetComponent<TextMeshProUGUI>().text = this.hp.ToString() + " hp";

        if (point == 5)
        {
            Debug.Log("Game Clear");
            SceneManager.LoadScene("GameClearScene");
        }
    }
}
