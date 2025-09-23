using UnityEngine;
using System.Collections;

public class L4_1SpikeAction : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;
    private float _currentBlinkInterval = 0f;

    ///void Start(){}

    void Awake()///
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_spriteRenderer == null)
        {
            Debug.LogWarning("SpikeAction: SpriteRenderer가 " + gameObject.name + "에 없습니다.");
        }
        _collider = GetComponent<Collider2D>();
        if (_collider == null)
        {
            Debug.LogWarning("SpikeAction: Collider2D가 " + gameObject.name + "에 없습니다.");
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Spike가 충돌했습니다: " + collision.gameObject.name + ", 태그: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            Destroy(gameObject);
            Debug.Log("Spike : destroyed!");
        }
    }

    public void SetBlinkInterval(float interval)///
    {
        _currentBlinkInterval = interval;
        if (_currentBlinkInterval > 0f)
        {
            if (_spriteRenderer == null) _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_collider == null) _collider = GetComponent<Collider2D>();

            StartCoroutine(BlinkRoutine());
        }
    }

    IEnumerator BlinkRoutine()////
    {
        while (true)
        {
            if (_spriteRenderer != null) _spriteRenderer.enabled = false;
            if (_collider != null) _collider.enabled = false;
            yield return new WaitForSeconds(_currentBlinkInterval / 2f);

            if (_spriteRenderer != null) _spriteRenderer.enabled = true;
            if (_collider != null) _collider.enabled = true;
            yield return new WaitForSeconds(_currentBlinkInterval / 2f);
        }
    }

}