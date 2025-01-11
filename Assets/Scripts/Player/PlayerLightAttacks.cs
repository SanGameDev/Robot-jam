using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLightAttacks : MonoBehaviour
{
    InputAction attack;
    public GameObject lhand;
    public GameObject rhand;
    Vector3 rotate;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            attack = InputSystem.actions.FindAction("Attack");
        }
    }

    private void Update() {
        
        if(attack.IsPressed()){
            rotate += new Vector3(0.0f, 180.0f, 0.0f);
            lhand.transform.eulerAngles = transform.eulerAngles - rotate;
            print("Attack");
        }
    }
}
