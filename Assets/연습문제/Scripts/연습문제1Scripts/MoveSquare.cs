using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Update 메소드가 호출되고 있는지 확인
        Debug.Log("Update method is running!");

        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow pressed!"); // 키 입력 확인
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow pressed!"); // 키 입력 확인
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow pressed!"); // 키 입력 확인
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // *지난번 수정된 부분 확인*
        {
            Debug.Log("Right Arrow pressed!"); // 키 입력 확인
            moveX = 1f; // 이 부분이 moveY가 아닌 moveX인지 다시 확인!
        }

        // 이동 벡터 계산
        Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;

        // transform.position을 직접 수정 (Time.deltaTime 적용)
        transform.position += moveDirection * speed * Time.deltaTime;

        // 최종 위치 변경 확인 (선택 사항이지만 유용함)
        // Debug.Log("Current Position: " + transform.position);
    }
}