using UnityEngine;

public class MouseLock : MonoBehaviour
{

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}