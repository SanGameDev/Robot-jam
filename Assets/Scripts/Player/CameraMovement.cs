using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    #region Private Variables 
        private Vector3 rotate;
        private Camera FPCamera;
        private InputAction look;
    #endregion

    public float speed;

    void Start()
    {
        FPCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            look = InputSystem.actions.FindAction("Look");
        }
    }

    private void Update() {
        //Camera movement rotates by the base of the parent object// if done with self it will flip out
        if(look.IsInProgress()){
            rotate += new Vector3(0.0f, -look.ReadValue<Vector2>().x * speed, 0.0f);
            FPCamera.transform.eulerAngles = transform.eulerAngles - rotate;
        }
    }

    public void SetCameraSpeed(float newSpeed){
        speed = newSpeed;
    }
}
