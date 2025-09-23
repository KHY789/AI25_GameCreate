using UnityEngine;
using System.Collections;

public class L4_1SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;
    [SerializeField]
    float spawnInterval = 1.5f;
    [SerializeField]
    float spikeSpacing = 1.0f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int spikeCount = Random.Range(1, 4);
            Debug.Log("이번 패턴 가시 수: " + spikeCount);

            float currentScore = Time.timeSinceLevelLoad; ///
            float blinkInterval = 0f; ///

            if (currentScore >= 30f)///
            {
                blinkInterval = 5f;
                Debug.Log($"스코어 {currentScore:F1}초 이상, 5초 깜빡임 적용");
            }
            else if (currentScore >= 25f)///
            {
                blinkInterval = 3f;
                Debug.Log($"스코어 {currentScore:F1}초 이상, 3초 깜빡임 적용");
            }
            else if (currentScore >= 15f)///
            {
                blinkInterval = 1f;
                Debug.Log($"스코어 {currentScore:F1}초 이상, 1초 깜빡임 적용");
            }

            for (int i = 0; i < spikeCount; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(i * spikeSpacing, 0f, 0f);
                ///Instantiate(SpikePrefab, spawnPos, SpikePrefab.transform.rotation);///
                GameObject newSpike = Instantiate(SpikePrefab, spawnPos, SpikePrefab.transform.rotation);

                L4_1SpikeAction spikeAction = newSpike.GetComponent<L4_1SpikeAction>();///
                if (spikeAction != null)///
                {
                    spikeAction.SetBlinkInterval(blinkInterval);
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}