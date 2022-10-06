using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float timeToDestroy;

    Rigidbody2D m_rb;
    GameController m_gc;

    AudioSource m_aus;
    public AudioClip hitSound;
    public GameObject hitVFX;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        m_aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            if (m_aus && hitSound)
            {
                m_aus.PlayOneShot(hitSound);
            }
            if (hitVFX)
            {
                Instantiate(hitVFX, col.transform.position, Quaternion.identity);
            }
            m_gc.IncrementScore();
            Destroy(gameObject);
        }
    }
}
