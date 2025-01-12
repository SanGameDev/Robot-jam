using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpecialAttacks : MonoBehaviour
{
    InputAction specialAttack;
    InputAction specialAttack2;
    InputAction specialAttack3;
    
    private CameraMovement cameraScript;

    public Animator playerAnim;
    public GameObject slamAOETrigger;

    void Start()
    {
        cameraScript = GetComponent<CameraMovement>();
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            specialAttack = InputSystem.actions.FindAction("SpecialAttack1");
            specialAttack2 = InputSystem.actions.FindAction("SpecialAttack2");
            specialAttack3 = InputSystem.actions.FindAction("SpecialAttack3");
        }
    }

    private void Update() {
        //Attack inputs
        if(specialAttack.IsPressed() && playerAnim.GetBool("hasStop")){
            PlaySAttackAnimation("SpecialSlamAttack");
            cameraScript.SetCameraSpeed(0.0f);
        }
        if(specialAttack2.IsPressed() && playerAnim.GetBool("hasStop")){
            PlaySAttackAnimation("SpecialOraAttack");
            cameraScript.SetCameraSpeed(0.1f);
        }
        if(specialAttack3.IsPressed() && playerAnim.GetBool("hasStop")){
            PlaySAttackAnimation("SpecialBumpAttack");
            cameraScript.SetCameraSpeed(0.0f);
        }
    }

    //Function to call an attack --cleaner code
    private void PlaySAttackAnimation(string animation){
        playerAnim.SetBool("hasStop",false);
        playerAnim.Play(animation);
    }

    public void SpawnShockWave(){
        slamAOETrigger.SetActive(true); 
    }
    public void DeactivateShockWave(){
        slamAOETrigger.SetActive(false); 
    }

}
