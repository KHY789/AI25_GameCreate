using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    public float ScrollSpeed = 1.0f;
    Material myMaterial;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float currentOffsetX = myMaterial.mainTextureOffset.x;
        float currentOffsetY = myMaterial.mainTextureOffset.y;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float deltaX = horizontalInput * ScrollSpeed * Time.deltaTime;
        float deltaY = verticalInput * ScrollSpeed * Time.deltaTime;

        float newOffsetX = currentOffsetX + deltaX;
        float newOffsetY = currentOffsetY + deltaY;

        Vector2 newOffset = new Vector2(newOffsetX, newOffsetY);
        myMaterial.mainTextureOffset = newOffset;
    }
}
