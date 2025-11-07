using UnityEngine;

public class MoveSquare_AddForce : MonoBehaviour
{
    public float speed = 5.0f;      // Inspector에서 조정할 속도 (가속 크기)
    public float drag = 3.0f;       // 감속(마찰) 계수
    private Vector2 velocity;       // 현재 속도 벡터

    void Update()
    {
        // 입력 감지
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

        // AddForce처럼: 힘(가속)을 더해 속도 증가
        Vector2 force = new Vector2(moveX, moveY) * speed;
        velocity += force * Time.deltaTime;

        // 마찰 효과 (속도 서서히 감소)
        velocity = Vector2.Lerp(velocity, Vector2.zero, drag * Time.deltaTime);

        // 위치 이동
        transform.position += (Vector3)(velocity * Time.deltaTime);
    }
}
