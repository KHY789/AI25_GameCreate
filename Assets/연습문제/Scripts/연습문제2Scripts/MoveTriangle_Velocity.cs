using UnityEngine;

public class MoveTriangle_Velocity : MonoBehaviour
{
    // �̵� �ӵ� (Inspector���� ���� ����)
    public float speed = 5.0f;

    // Rigidbody2D ������Ʈ ����
    private Rigidbody2D rb;

    void Start()
    {
        // Rigidbody2D ��������
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // �Է°� �ޱ�
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

        // �̵� ���� ���� ���
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        // Rigidbody2D�� �ӵ� ���� ����
        rb.linearVelocity = moveDir * speed;
    }
}
