using UnityEngine;

public class RedWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ÇÃ·¹ÀÌ¾î°¡ »¡°£ º®(Collision)¿¡ ºÎµúÈû!");
        }
    }
}
