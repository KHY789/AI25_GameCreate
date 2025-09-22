using UnityEngine;
using System.Collections;

public class SpikeSpawner : MonoBehaviour
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

            for (int i = 0; i < spikeCount; i++)
            {
                Vector3 spawnPos = transform.position + new Vector3(i * spikeSpacing, 0f, 0f);
                Instantiate(SpikePrefab, spawnPos, SpikePrefab.transform.rotation);///
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}