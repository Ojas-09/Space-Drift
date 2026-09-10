using UnityEngine;

public class menurocket : MonoBehaviour
{
    Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float Y_offset = Mathf.Sin(Time.time) * 0.5f;
        float X_offset = Mathf.Sin(Time.time * 0.5f) * 0.3f;
        transform.position = startPosition + new Vector3(X_offset, Y_offset, 0);
        transform.Rotate(0,10 * Time.deltaTime,0);
    }
}
