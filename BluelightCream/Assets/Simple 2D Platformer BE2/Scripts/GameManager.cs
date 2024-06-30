using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public HealthBar healthBar;  // HealthBar 스크립트를 연결합니다
    public string gameClearSceneName = "GameClear";  // GameClear 씬 이름
    public string gameOverSceneName = "GameOver";  // GameOver 씬 이름

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

