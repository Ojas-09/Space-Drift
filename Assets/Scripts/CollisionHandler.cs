using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip collide;
    [SerializeField] AudioClip win;
    [SerializeField] ParticleSystem crash;
    [SerializeField] ParticleSystem success;
    AudioSource AudioSource;

    bool iscontrollable = true;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (!iscontrollable){return;}
        switch(other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this is okay");
                break;
            case "Finish":
                nextlevelsequence();
                break;
            default:
                Destructionsequence();
                break;

        }
    }

    private void Destructionsequence()
    {
        iscontrollable = false;
        AudioSource.Stop();
        crash.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Reloadscene", delay);
        AudioSource.PlayOneShot(collide);

    }
    private void nextlevelsequence()
    {
        iscontrollable = false;
        AudioSource.Stop();
        success.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("Nextlevel", delay);
        AudioSource.PlayOneShot(win);

    }

    private void Reloadscene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
    private void Nextlevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        int nextscene = currentscene +1;
        if (nextscene == SceneManager.sceneCountInBuildSettings)
        {
            nextscene = 0;
        }
        SceneManager.LoadScene(nextscene);
    }
}
