using UnityEngine;

public class CubeB_Movement : MonoBehaviour
{
    public float speed = 5.0f; // Inspector에서 조절 가능

    void Update()
    {
        // "DeltaTime의 수치에 따라 움직이는 Speed로 지정" (프레임 속도에 독립적)
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}