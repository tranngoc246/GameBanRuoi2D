using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    float m_speed;

    Rigidbody2D m_rg;
    GameController m_gc;

    // Start is called before the first frame update
    void Start()
    {
        m_rg = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_speed = speed;
        if (m_gc.IsGameOver())
        {
            speed = 0;
        }
        m_rg.velocity = Vector2.down * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone") || col.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
