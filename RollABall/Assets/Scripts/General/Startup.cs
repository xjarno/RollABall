using UnityEngine;
using UnityEngine.InputSystem;

public class Startup : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
