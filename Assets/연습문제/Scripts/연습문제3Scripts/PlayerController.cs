using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ===== 이동 관련 설정 =====
    [Header("이동 관련 설정")]
    public float moveAcceleration = 5f; // 이동 가속도 (키를 누를 때 얼마나 빨리 속도가 붙는지)
    public float maxMovePower = 5f;     // 이동 최대 속도 (너무 빨라지는 것 방지)

    // ===== 점프 관련 설정 =====
    [Header("점프 관련 설정")]
    public float jumpAcceleration = 8f; // 점프 시 위로 가하는 힘의 크기
    public float maxJumpPower = 10f;    // 점프 최대 힘 (현재 코드에서는 직접 사용 안 함)

    // ===== 내부 변수 =====
    private Rigidbody2D rb;         // Rigidbody2D 컴포넌트 (물리 제어용)
    private bool isGrounded = false; // 땅에 닿아 있는지 여부
    private Vector2 moveVelocity;   // 이동 속도 계산용 변수

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 가져오기
        rb.gravityScale = 1.5f;           // 중력 세기 조절 (조금 더 빠르게 떨어지게)
    }

    void Update()
    {
        // ---- 이동 입력 받기 ----
        float moveInput = Input.GetAxisRaw("Horizontal"); // 왼쪽(-1), 오른쪽(1), 없음(0)

        // ---- 이동 가속도 적용 ----
        moveVelocity.x += moveInput * moveAcceleration * Time.deltaTime;

        // ---- 최대 속도 제한 ----
        moveVelocity.x = Mathf.Clamp(moveVelocity.x, -maxMovePower, maxMovePower);

        // ---- 키를 떼면 천천히 멈춤 (마찰 효과) ----
        if (moveInput == 0)
            moveVelocity.x = Mathf.Lerp(moveVelocity.x, 0, 3f * Time.deltaTime);

        // ---- 점프 입력 ----
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 현재 Y속도를 0으로 초기화해서 점프할 때 깔끔하게 상승하도록
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // 위 방향으로 점프 힘 가하기 (즉시적인 힘)
            rb.AddForce(Vector2.up * jumpAcceleration, ForceMode2D.Impulse);

            // 점프 중 상태로 변경
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // ---- 물리 업데이트에서 X속도 반영 ----
        // moveVelocity.x는 우리가 계산한 이동 속도
        // rb.linearVelocity.y는 점프/낙하 속도 (유지)
        rb.linearVelocity = new Vector2(moveVelocity.x, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ---- Ground 태그가 붙은 오브젝트와 닿으면 ----
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true; // 땅에 닿았다고 판단 → 다시 점프 가능
    }
}
