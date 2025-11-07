using UnityEngine;

public class MoveCircle_VelocityAddForce : MonoBehaviour
{
    // Inspector���� ���� ������ �̵� �ӵ� (���� ����)
    public float speed = 5.0f;

    // ���ӵ� �ӵ� ������
    private Vector2 velocity;

    // ���� ��� (���� ȿ��)
    public float drag = 2.0f;

    // Rigidbody2D ����
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
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

        // �Է� ���� (����ȭ)
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        // AddForceó�� ? ���� �ӵ��� '��'�� ����
        velocity += moveDir * speed * Time.fixedDeltaTime;

        // ���� (�Է� ���� �� ������ ����)
        velocity = Vector2.Lerp(velocity, Vector2.zero, drag * Time.fixedDeltaTime);

        // Rigidbody2D�� velocity�� ����
        rb.linearVelocity = velocity;
    }
}
