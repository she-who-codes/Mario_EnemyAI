using UnityEngine;
/// <summary>
/// Script to manange getting hit by the player and chasing the player.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float AlertSpeed = 4f;

    private float m_CurrentSpeed;
    private int m_Direction = 1;
    
    void Start()
    {
        m_CurrentSpeed = MoveSpeed;        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocityX = m_CurrentSpeed * m_Direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            m_CurrentSpeed = AlertSpeed;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            m_CurrentSpeed = MoveSpeed;

            if (collision.gameObject.transform.position.x < gameObject.transform.position.x)
            {
                m_Direction = -1;
            }
            if (collision.gameObject.transform.position.x > gameObject.transform.position.x)
            {
                m_Direction = 1;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallLeft") == true) 
        {
            m_Direction = 1;
        }
        if (collision.gameObject.CompareTag("WallRight") == true)
        {
            m_Direction = -1;
        }
    }

}
