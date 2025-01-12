using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLightAttacks : MonoBehaviour
{
    InputAction attack;
    InputAction attack2;

    public Animator playerAnim;

    void Start()
    {
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            attack = InputSystem.actions.FindAction("Attack");
            attack2 = InputSystem.actions.FindAction("Attack2");
        }
    }

    private void Update() {
        
        if(attack.IsPressed() && playerAnim.GetBool("hasStop")){
            PlayAttackAnimation("LeftHandAttack");
        }
        if(attack2.IsPressed() && playerAnim.GetBool("hasStop")){
            PlayAttackAnimation("RightHandAttack");
        }
    }

    private void PlayAttackAnimation(string animation){
        playerAnim.SetBool("hasStop",false);
        playerAnim.Play(animation);
    }

    public void SetBooltrue(){
        playerAnim.SetBool("hasStop",true);
    }

}
