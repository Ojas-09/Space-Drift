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
                Debug.Log("yayyy reached the location");
                break;
            default:
                SceneManager.LoadScene(0);
                break;

        }
    }
}
