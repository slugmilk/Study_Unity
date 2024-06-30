using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;  // HealthBar ��ũ��Ʈ�� �����մϴ�
    public string gameClearSceneName = "GameClear";  // GameClear �� �̸�
    public string gameOverSceneName = "GameOver";  // GameOver �� �̸�

    void Update()
    {
        if (healthBar.CurrentHealth <= 0)
        {
            LoadGameOverScene();
        }
    }

    public void LoadGameClearScene()
    {
        SceneManager.LoadScene(gameClearSceneName);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverSceneName);
    }
}

