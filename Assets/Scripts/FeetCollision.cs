using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FeetCollision : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int m_Score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            GameObject.Destroy(collision.gameObject);
            m_Score++;
            text.text = "Player Score: " + m_Score;
            
        }
    }
}
