using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    [Range(0.01f, 2.0f)] // Inspector에서 슬라이더로 조절하기 편리하게
    public float slowMotionScale = 0.2f; // 슬로우 모션 시 시간 스케일

    private float normalTimeScale = 1.0f; // 기본 시간 스케일

    void Update()
    {
        // 'T' 키를 눌렀을 때 Time.timeScale 전환
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Time.timeScale == normalTimeScale)
            {
                Time.timeScale = slowMotionScale;
                Debug.Log($"슬로우 모션 발동! Time.timeScale = {Time.timeScale}");
            }
            else
            {
                Time.timeScale = normalTimeScale;
                Debug.Log($"시간 정상화! Time.timeScale = {Time.timeScale}");
            }
        }
    }
}