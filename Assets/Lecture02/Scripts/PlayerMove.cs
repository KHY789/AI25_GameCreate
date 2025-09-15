using UnityEngine;
using UnityEngine.UIElements;

public class PlayerContoller : MonoBehaviour
{
    float start_point = 0.0f;
    
    void Start()
    {
        start_point++;
        transform.position = new Vector3(start_point, 0.0f, 0.0f);
    }

    void Update()
    {
        start_point = start_point - 0.005f;
        transform.position = new Vector3(start_point, transform.position.y, transform.position.z);
    }
}
