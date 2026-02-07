using UnityEngine;
using UnityEngine.InputSystem;
public class Size : MonoBehaviour
{
    [Header("Size")]
    public Vector3 minScale = new Vector3(0.5f, 1f, 0.5f); 
    public Vector3 maxScale = new Vector3(2f, 1f, 2f);     
    public float sizeStep = 0.1f;                           

    [Header("Control Keys")]
    public Key growKey = Key.E;    
    public Key shrinkKey = Key.Q; 

    void Update()
    {
        Vector3 scale = transform.localScale;

        if (Keyboard.current[growKey].wasPressedThisFrame)
        {
            scale += new Vector3(sizeStep, 0f, sizeStep);
        }
        if (Keyboard.current[shrinkKey].wasPressedThisFrame)
        {
            scale -= new Vector3(sizeStep, 0f, sizeStep);
        }

        scale.x = Mathf.Clamp(scale.x, minScale.x, maxScale.x);
        scale.y = Mathf.Clamp(scale.y, minScale.y, maxScale.y);
        scale.z = Mathf.Clamp(scale.z, minScale.z, maxScale.z);

        transform.localScale = scale;
    }
}