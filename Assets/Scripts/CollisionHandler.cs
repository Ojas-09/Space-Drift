using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delay = 2f;
    [SerializeField] AudioClip collide;
    [SerializeField] AudioClip win;
    AudioSource AudioSource;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("this is okay");
                break;
            case "fuel":
                Debug.Log("yum yum yumm");
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
        GetComponent<Movement>().enabled = false;
        Invoke("Reloadscene", delay);
        AudioSource.PlayOneShot(collide);

    }
    private void nextlevelsequence()
    {
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
