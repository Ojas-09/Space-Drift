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
    [SerializeField] ParticleSystem main_booster;
    [SerializeField] ParticleSystem left_booster;
    [SerializeField] ParticleSystem right_booster;
    

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
            if (!main_booster.isPlaying)
            {
                main_booster.Play();
            }
        }
        else
        {
            AudiSrc.Stop();
            main_booster.Stop();
        }
    }
    void rotating()
    {
        float rotationinput = rotater.ReadValue<float>();
        if (rotationinput < 0)
        {
            angled(rotating_power);
            if (!right_booster.isPlaying)
            {
                right_booster.Play();
            }
        }
        else if (rotationinput > 0)
        {
            angled(-rotating_power);
            if (!left_booster.isPlaying)
            {
                left_booster.Play();
            }
        }
        else
        {
            left_booster.Stop();
            right_booster.Stop();
        }
    }

    private void angled(float power)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * power * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }
}
