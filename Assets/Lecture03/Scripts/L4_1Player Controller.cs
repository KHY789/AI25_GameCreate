using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class L4_1PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    ///bool isJumping = true;
    ///public float JumpPower = 10.0f;
    public float normalGravityScale = 1.0f;///
    public float invertedGravityScale = -1.0f;///

    private bool isOnUpperGround = false;///
    private bool isGrounded = false;///

    public GameObject text;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        ///isJumping = true;
        ///Debug.Log("Player : isJumping = true");
        rb.gravityScale = normalGravityScale;///
        isOnUpperGround = false; ///
        isGrounded = false; ///
        Debug.Log("Player: 시작 시 밑의 땅 상태, 일반 중력 적용"); ///

        text.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player : 바닥에 착지");
            ///isJumping = false;
            isGrounded = true;
            ///Debug.Log("Player : isJumping = false");
        }
        else if (collision.gameObject.CompareTag("Spike"))////
        {
            Debug.Log("Player : Player Collision! GameOver!");////
            text.SetActive(true);////
            Time.timeScale = 0;////
        }
    }

    void OnCollisionExit2D(Collision2D collision)///
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Player: 바닥에서 떨어졌습니다.");
            isGrounded = false;
        }
    }

    void Update()
    {
        ///if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            ///Debug.Log("Player : Jump(Space Bar Pressed)");
            ///rb.linearVelocity = new Vector2(0.0f, JumpPower);
            ///isJumping = true;
            ///Debug.Log("Player : isJumping = true");
            Debug.Log("(바닥에 닿음.)점프 애니메이션 재생 시도!");
            animator.Play("Player_Animation", -1, 0f);
            SwitchGravityAndPlatform();
        }
    }

    void SwitchGravityAndPlatform()///
    {
        const float transitionPushValue = 7f;///
        isGrounded = false;///

        if (isOnUpperGround)///
        {
            rb.gravityScale = normalGravityScale;
            isOnUpperGround = false;
            Debug.Log("Player: 밑의 땅으로 전환, 일반 중력 적용.");

            rb.AddForce(Vector2.down * transitionPushValue, ForceMode2D.Impulse);

        }
        else///
        {

            rb.gravityScale = invertedGravityScale;
            isOnUpperGround = true;
            Debug.Log("Player: 위의 땅으로 전환, 뒤집힌 중력 적용.");

            rb.AddForce(Vector2.up * transitionPushValue, ForceMode2D.Impulse);
        }
    }
}