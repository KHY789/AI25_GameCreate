using UnityEngine;

public class SpikeAction : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Spike가 충돌했습니다: " + collision.gameObject.name + ", 태그: " + collision.gameObject.tag); // 임시 추가
        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            Destroy(gameObject);
            Debug.Log("Spike : destroyed!");
        }
    }
}