using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // SceneManager�� ����ϱ� ���� �߰�

public class ChangeSceneOnAnyKey : MonoBehaviour
{
    public string sceneName = "Demo";  // ��ȯ�� �� �̸�

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

