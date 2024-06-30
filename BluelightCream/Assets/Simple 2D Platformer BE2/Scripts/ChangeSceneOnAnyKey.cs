using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager를 사용하기 위해 추가

public class ChangeSceneOnAnyKey : MonoBehaviour
{
    public string sceneName = "Demo";  // 전환할 씬 이름

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

