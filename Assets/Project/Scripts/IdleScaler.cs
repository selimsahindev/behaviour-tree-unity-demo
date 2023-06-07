using UnityEngine;

public class IdleScaler : MonoBehaviour
{
    public float scaleFactor = 0.25f;
    public float frequency = 1f;

    private float timer = 0f;
    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void Update()
    {
        float multiplier = 1f + (scaleFactor * Mathf.Sin(timer));
        transform.localScale = multiplier * originalScale;
        timer += Time.deltaTime * frequency;
    }
}
