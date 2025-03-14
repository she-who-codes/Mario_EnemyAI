using System.Collections;
using TMPro;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    public float WalkSpeed = 7.0f;
    public float JumpHeight = 15.0f;
    public TextMeshProUGUI text;

    private int m_Score;
    private Rigidbody2D rgdBdy;
    private bool isJumping = false;
    private bool isWalking = false;
    private int jumpCount = 0;
    private int MaxJumps = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgdBdy = GetComponent<Rigidbody2D>();
        rgdBdy.angularDamping = 200;
        rgdBdy.gravityScale = 4;
        rgdBdy.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Walk left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rgdBdy.linearVelocityX = -WalkSpeed;
            isWalking = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //Walk Right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rgdBdy.linearVelocityX = WalkSpeed;
            isWalking = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            isWalking = false;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            isJumping = true;
            jumpCount++;
            if (jumpCount <= MaxJumps) 
            { 
                rgdBdy.AddForceY(JumpHeight, ForceMode2D.Impulse); 
            }
        }

        if (rgdBdy.linearVelocityY != 0)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
            jumpCount = 0;
        }
        
        if (isJumping == true) 
        {
            isWalking = false;
        }
        
        //Animation Controls
        GetComponent<Animator>().SetBool("Walking", isWalking);
        GetComponent<Animator>().SetBool("Jumping", isJumping);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            m_Score++;
            text.text = "Enemy Score: " + m_Score;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(ResetColor());
        }
    }

    IEnumerator ResetColor() 
    {
        yield return new WaitForSeconds(0.35f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
