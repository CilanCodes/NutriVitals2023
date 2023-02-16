using UnityEngine;

public class ScaleUp : MonoBehaviour
{
    public float scaleAmount = 1.1f;

    private float elapsedTime = 0;

    void Update()
    {
        if (elapsedTime < 10)
        {
            elapsedTime += Time.deltaTime;
            float yScale = scaleAmount * (1 + 0.1f * Mathf.Sin(2 * Mathf.PI * elapsedTime / 2));
            transform.localScale = new Vector3(transform.localScale.x, yScale, transform.localScale.z);
        }
    }
}