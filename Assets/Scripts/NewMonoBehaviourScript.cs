using UnityEngine;

// 2D ĳ���͸� �¿�� �����̰�, �����̽� Ű�� ������ �� �ְ� ����� ��ũ��Ʈ
// �� ���ӿ�����Ʈ�� Rigidbody2D + Collider2D�� �ݵ�� �ʿ��մϴ�.
public class PlayerController2D : MonoBehaviour
{
    // Inspector(�ν�����)���� ���� ������ �� �ִ� ����
    public float moveSpeed = 5f;   // �¿� �̵� �ӵ�
    public float jumpForce = 7f;   // ���� ��

    // ���� ���� ������ ����ϴ� Rigidbody2D ������Ʈ
    private Rigidbody2D rb;

    // �÷��̾ ���� ����ִ��� Ȯ���ϴ� ����
    // (���� �ߺ� ������)
    private bool isGrounded = true;

    // ���� ���� �� �� �� �����
    void Start()
    {
        // �÷��̾� ������Ʈ�� �پ� �ִ� Rigidbody2D ��������
        rb = GetComponent<Rigidbody2D>();
    }

    // �� �����Ӹ��� �����
    void Update()
    {
        // ---- 1. �¿� �̵� ó�� ----
        // GetAxisRaw("Horizontal"):
        //   - ���� ȭ��ǥ �Ǵ� A Ű �� -1
        //   - �Է� ���� �� 0
        //   - ������ ȭ��ǥ �Ǵ� D Ű �� +1
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Rigidbody2D�� velocity(�ӵ�) ���� ���� �ٲ㼭 �̵���Ŵ
        // X�� �ӵ��� �Է°� * �̵��ӵ�
        // Y�� �ӵ��� ���� �� ���� (����/�߷¿� ���� �� �ֱ� ����)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // ---- 2. ���� ó�� ----
        // �����̽� Ű�� ������, ���� ���� ���� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Rigidbody2D�� ���� �������� ���� ���� (�������� ��: Impulse ���)
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // ���߿� �� �����Ƿ� isGrounded = false �� ����
            isGrounded = false;
        }
    }

    // �浹�� ���۵� �� �ڵ����� ����Ǵ� �Լ�
    // (Collider2D + Rigidbody2D �� �־�� �۵�)
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ������Ʈ�� �±װ� "Ground"�� ���
        // �ٽ� ������ �� �ֵ��� isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
