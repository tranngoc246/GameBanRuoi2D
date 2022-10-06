using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Transform ShootingPoint;
    public GameObject projectile;
    public float spawnTime;

    public AudioSource aus;
    public AudioClip shootingSound;

    float m_spawnTime;
    GameController m_gc;

    float projectileCount;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_gc = FindObjectOfType<GameController>();
        projectileCount = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameOver())
        {
            return;
        }
        float xDir = Input.GetAxisRaw("Horizontal");
        float moveStep = xDir * Time.deltaTime * moveSpeed;
        if ((xDir < 0 && transform.position.x <= -5) || (xDir > 0 && transform.position.x >= 5))
        {
            return;
        }
        transform.position += Vector3.right * moveStep;

        projectileCount += 0.025f;

        if (Input.GetKey(KeyCode.Space) && projectileCount>0)
        {
            m_spawnTime -= Time.deltaTime;
            if (m_spawnTime <= 0)
            {
                Shoot();
                m_spawnTime = spawnTime;
                projectileCount--;
            }
        }
    }
    void Shoot()
    {
        if (projectile && ShootingPoint)
        {
            Instantiate(projectile, ShootingPoint.position, Quaternion.identity);
            if (aus && shootingSound)
            {
                aus.PlayOneShot(shootingSound);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.SetIsGameOverState(true);
        }
    }
}
