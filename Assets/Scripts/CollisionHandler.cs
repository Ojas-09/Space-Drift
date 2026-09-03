using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                Nextlevel();
                break;
            default:
                Reloadscene();
                break;

        }
    }

    private static void Reloadscene()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
    }
    private static void Nextlevel()
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
