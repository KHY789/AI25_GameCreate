using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;

    bool a = true;

    void Start()
    {

    }

    void Update()
    {
        if (a)
        {
            GameObject spike = Instantiate(SpikePrefab);
            spike.transform.position = transform.position;
            a = false;
        }
    }
}
