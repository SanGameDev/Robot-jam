using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    InputAction look;
    public Camera FPCamera;
    public float speed;
    private Vector3 rotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            look = InputSystem.actions.FindAction("Look");
        }
    }

    private void Update() {
        
        if(look.IsInProgress()){
            print("Move Camera"); 
            rotate += new Vector3(0.0f, -look.ReadValue<Vector2>().x * speed, 0.0f);
            FPCamera.transform.eulerAngles = transform.eulerAngles - rotate;
        }
    }
}
