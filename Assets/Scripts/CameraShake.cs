using UnityEngine;

using System.Collections;


public class CameraShake : MonoBehaviour
{
    [Header("Shake Settings")]
    public float duration = 0.2f;    
    public float magnitude = 0.2f;   
    private Vector3 originalPos;
    void Awake()
    {
        originalPos = transform.localPosition;
    }

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(DoShake());
    }

    
    
    
    
    private IEnumerator DoShake()
    {
        
        
        float elapsed = 0f;
        

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            
            
            transform.localPosition = originalPos + new Vector3(x, y, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPos;
    }
}
