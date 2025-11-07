using UnityEngine;

public class GreenWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("플레이어가 녹색 벽(Trigger)에 들어옴!");
        }
    }
}
