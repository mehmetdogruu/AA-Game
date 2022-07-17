
using UnityEngine;

public class LittleCircle : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity;
    bool moveControl = false;
    GameObject gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void FixedUpdate()
    {
        if (!moveControl)
        {
            rb.MovePosition(rb.position + Vector2.up * velocity * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="Circle")
        {
            transform.SetParent(col.transform);
            moveControl = true;

        }
        if (col.tag=="Kunai")
        {
            gameManager.GetComponent<GameManager>().GameOver();
      
        }
    }
}
