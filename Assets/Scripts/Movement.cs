using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField]float thruststrength = 100f;
    [SerializeField] InputAction rotater;
    [SerializeField]float rotating_power = 10f;
    [SerializeField] AudioClip mainengine;

    Rigidbody rb;

    AudioSource AudiSrc;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        AudiSrc = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        thrust.Enable();
        rotater.Enable();
    }

    void Update()
    {
        booster();
        rotating();
    }

    private void booster()
    {
        if (thrust.IsPressed())
        {
            
            rb.AddRelativeForce(Vector3.up * thruststrength * Time.fixedDeltaTime);
            if (!AudiSrc.isPlaying)
            {
                AudiSrc.PlayOneShot(mainengine);
            }
        }
        else
        {
            AudiSrc.Stop();
        }
    }
    void rotating()
    {
        float rotationinput = rotater.ReadValue<float>();
        if (rotationinput < 0)
        {
            angled(rotating_power);
        }
        else if (rotationinput > 0)
        {
            angled(-rotating_power);
        }
    }

    private void angled(float power)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * power * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
