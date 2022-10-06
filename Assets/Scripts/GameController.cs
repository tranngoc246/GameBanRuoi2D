using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    UIManager m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_ui.IsShowReplayPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }

    void SpawnEnemy()
    {
        if (enemy)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-5, 5), 5.5f, 0);
            Instantiate(enemy, enemyPos, Quaternion.identity);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public int GetScore()
    {
        return m_score;
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public void IncrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void SetIsGameOverState(bool state)
    {
        m_isGameOver = state;
    }
}
