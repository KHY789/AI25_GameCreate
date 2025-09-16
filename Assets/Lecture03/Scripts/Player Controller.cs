using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    bool isJumping = true;
    public float JumpPower = 10.0f;

    public GameObject text;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isJumping = true;
        Debug.Log("Player : isJumping = true");
        text.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : Floor on Landed");
            isJumping = false;
            Debug.Log("Player : isJumping = false");
        }
        else if (collision.gameObject.CompareTag("Spike"))////
        {
            Debug.Log("Player : Player Collision! GameOver!");////
            text.SetActive(true);////
            Time.timeScale = 0;////
        }
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            Debug.Log("Player : Jump(Space Bar Pressed)");
            rb.linearVelocity = new Vector2(0.0f, JumpPower);
            isJumping = true;
            Debug.Log("Player : isJumping = true");
        }
    }
}