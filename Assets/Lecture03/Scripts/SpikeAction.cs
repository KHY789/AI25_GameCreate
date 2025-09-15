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
        Debug.Log("¹Ú¾Ò¿ò!!!!");

        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            Destroy(gameObject);
        }
    }
}
