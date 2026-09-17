using UnityEngine;
using UnityEngine.InputSystem;

public class exit : MonoBehaviour
{

    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame){
            Application.Quit();
        }
    }
}
