using UnityEngine;

public class oscillator : MonoBehaviour
{
    [SerializeField]float speed;
    [SerializeField]Vector3 movementVector;
    Vector3 startpos;
    Vector3 endpos;
    float Movementfactor;

    void Start()
    {
        startpos = transform.position;
        endpos = startpos + movementVector;
    }
    void Update()
    {
        Movementfactor = Mathf.PingPong(Time.time * speed,1f);
        transform.position = Vector3.Lerp(startpos,endpos,Movementfactor);
        
    }
}
