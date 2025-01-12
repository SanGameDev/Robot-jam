using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLightAttacks : MonoBehaviour
{
    InputAction attack;
    InputAction attack2;

//test
    //public PlayerHealth ph;

    private CameraMovement cameraScript;
    public Animator playerAnim;

    void Start()
    {
        cameraScript = GetComponent<CameraMovement>();
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            attack = InputSystem.actions.FindAction("Attack");
            attack2 = InputSystem.actions.FindAction("Attack2");
        }
    }

    private void Update() {
        //Attack inputs
        if(attack.IsPressed() && playerAnim.GetBool("hasStop")){
            PlayAttackAnimation("LeftHandAttack");
            // testing to debug damage unlocks ph.TakeDamage(10f);
            cameraScript.SetCameraSpeed(0.01f);
        }
        if(attack2.IsPressed() && playerAnim.GetBool("hasStop")){
            PlayAttackAnimation("RightHandAttack");
            cameraScript.SetCameraSpeed(0.01f);
        }
    }

    //Function to call an attack --cleaner code
    private void PlayAttackAnimation(string animation){
        playerAnim.SetBool("hasStop",false);
        playerAnim.Play(animation);
    }

    //Called in animation clips to be able to call another attack again
    public void SetBooltrue(){
        playerAnim.SetBool("hasStop",true);
    }

}
