using UnityEngine;

public class MoveTriangle : MonoBehaviour
{
    // 이동 속도 (Inspector에서 조정)
    public float speed = 5.0f;

    // Rigidbody2D 참조
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D 가져오기
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // 입력값 받기
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
            moveY = 1f;
        if (Input.GetKey(KeyCode.DownArrow))
            moveY = -1f;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;
        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;

        // 이동 방향 계산
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        // Rigidbody2D의 위치 갱신 (MovePosition)
        rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
    }
}
