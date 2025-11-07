using UnityEngine;

public class CubeA_Movement : MonoBehaviour
{
    public float speed = 5.0f; // Inspector에서 조절 가능

    void Update()
    {
        // "Update마다 움직이는 수치를 Speed로 지정" (프레임 속도에 매우 민감)
        transform.Translate(Vector3.right * speed);
    }
}