using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private float bounceForce = 5f; // Ƣ�� ������ ���� ũ��
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        // Rigidbody2D�� Animator ������Ʈ ��������
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // ��ũ��Ʈ�� ���� ������Ʈ�� Animator ������Ʈ�� ���ٸ� ���
        if (animator == null)
        {
            Debug.LogWarning("Animator ������Ʈ�� Ball ������Ʈ�� �����ϴ�!");
        }
    }

    // �ٸ� Collider�� ����� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.Play("BounceAnimation", -1,0f); // Animator�� "OnBounce" Ʈ���Ÿ� Ȱ��ȭ

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // ���� Y �ӵ� �ʱ�ȭ (�浹�� ���� �ӵ��� ���̳ʽ��� �� ����)
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); // �ﰢ���� ���� ���� ����
        }
    }
}
