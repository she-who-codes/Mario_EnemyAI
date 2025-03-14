///This is where we import other scripts that we need to use. 
///"UnityEngine" is standard in every script.
using UnityEngine;

/// <summary>
/// This is our vehicle... It tells our Unity Game Object what to do!
/// This script will manange moving back and forth, detecting the player and then chasing the player.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    /// <summary>
    /// Here we delcare our Variables
    /// It's like having directions to where we are going, before we can drive off.
    /// </summary>
    public float MoveSpeed = 1f;
    public float AlertSpeed = 4f;

    private float m_CurrentSpeed;
    private int m_Direction = 1;


    /// <summary>
    /// The Start is like our Car keys:
    /// You need them to start the car and set any parameters, like adjusting your seat.
    /// </summary>
    void Start()
    {
        m_CurrentSpeed = MoveSpeed;        
    }

    /// <summary>
    /// Update is called once per frame, a frame can typically happen 60 times per ONE SECOND! That's a lot!
    /// Things that need to happen constantly, like character movement can go here.
    /// This is our tires to our vehicle...nothing is happening unless they are turning!
    /// </summary>
    void Update()
    {
        GetComponent<Rigidbody2D>().linearVelocityX = m_CurrentSpeed * m_Direction;
    }

    /// <summary>
    /// A trigger is an invisible collision that happens.
    /// Nothing gets bumped or reacts, it just says, "Hey, I see the light turned red" and allows us to act.
    /// This is the enter event, when a trigger is first detected.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            m_CurrentSpeed = AlertSpeed;
        }
    }

    /// <summary>
    /// Same deal as above, but this happens when the trigger no longer detects the event! 
    /// Like you can no longer see the light!
    /// </summary>
    /// <param name="collision"></param>
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

    /// <summary>
    /// This is our collision event, we hit another car!
    /// Physics can take over and we can also make interesting things happen here! 
    /// </summary>
    /// <param name="collision"></param>
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