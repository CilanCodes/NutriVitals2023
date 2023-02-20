using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{

    public Vector3 targetScale;
    public float duration = 1.0f;
    private Vector3 startScale;
    private float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        IncreaseMountainScale();
    }

    void IncreaseMountainScale()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        transform.localScale = Vector3.Lerp(startScale, targetScale, t);
    }
}
