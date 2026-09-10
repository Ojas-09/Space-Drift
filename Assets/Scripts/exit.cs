using UnityEngine;
using UnityEngine.InputSystem;

public class exit : MonoBehaviour
{

    void Update()
    {
        if(Keyboard.current.escapeKey.IsPressed()) {
            Application.Quit();
            Debug.Log("bhaag");
        }
    }
}
