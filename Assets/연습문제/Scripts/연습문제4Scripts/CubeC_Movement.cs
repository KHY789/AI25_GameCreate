using UnityEngine;

public class CubeC_Movement : MonoBehaviour
{
    public float speed = 5.0f; // Inspector���� ���� ����
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.right * speed;
    }
}