using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerSpecialAttacks : MonoBehaviour
{

#region private Variables 

    private InputAction specialAttack;
    private InputAction specialAttack2;
    private InputAction specialAttack3;
    private bool hasUnlockedFirst;
    private bool hasUnlockedSecond;
    private CameraMovement cameraScript;
    private float timeRemaining1 = 3f;
    private float timeRemaining2 = 5f;
    private float timeRemaining3 = 12f;
    private bool isOnCoolDown1 = false;
    private bool isOnCoolDown2 = false;
    private bool isOnCoolDown3 = false;

#endregion

#region UI Images

    public Image unlockImage1;
    public Image unlockImage2;

    public Image coolDown1;
    public Image coolDown2;
    public Image coolDown3;

#endregion

    public Animator playerAnim;
    public GameObject slamAOETrigger;
    public PlayerHealth playerHealth;
    public CameraShake cameraShakeComponent;
    public ParticleSystem sparksParticles;
    public GameObject cloudsParticles;
    public GameObject CloudsTransform;



    void Start()
    {
        cameraScript = GetComponent<CameraMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        // Get InputAction references from Project-wide input actions.
        if (InputSystem.actions)
        {
            specialAttack = InputSystem.actions.FindAction("SpecialAttack1");
            specialAttack2 = InputSystem.actions.FindAction("SpecialAttack2");
            specialAttack3 = InputSystem.actions.FindAction("SpecialAttack3");
        }
    }

    private void Update() {
        //Attack 1
        if(specialAttack.IsPressed() && playerAnim.GetBool("hasStop") && !isOnCoolDown1 && !playerHealth.isDead){
            PlaySAttackAnimation("SpecialBumpAttack");
            coolDown1.fillAmount = 1.0f;
            isOnCoolDown1 = true;
            Invoke( "ResetCooldown1", .1f );
            cameraScript.SetCameraSpeed(0.0f);
        }
        //Attack 3
        if(specialAttack2.IsPressed() && playerAnim.GetBool("hasStop") && hasUnlockedSecond && !isOnCoolDown3 && !playerHealth.isDead){
            PlaySAttackAnimation("SpecialOraAttack");
            coolDown3.fillAmount = 1.0f;
            isOnCoolDown3 = true;
            Invoke( "ResetCooldown3", .1f );
            cameraScript.SetCameraSpeed(0.1f);
        }
        //Attack 2
        if(specialAttack3.IsPressed() && playerAnim.GetBool("hasStop") && hasUnlockedFirst && !isOnCoolDown2 && !playerHealth.isDead){
            PlaySAttackAnimation("SpecialSlamAttack");
            coolDown2.fillAmount = 1.0f;
            isOnCoolDown2 = true;
            Invoke("ResetCooldown2", .1f);
            cameraScript.SetCameraSpeed(0.0f);
        }
    }

    
    
#region Attack Control

    //Function to call an attack --cleaner code
    private void PlaySAttackAnimation(string animation){
        playerAnim.SetBool("hasStop",false);
        playerAnim.Play(animation);
    }

    public void SpawnShockWave(){
        slamAOETrigger.SetActive(true); 
        Instantiate(cloudsParticles,CloudsTransform.transform.position,CloudsTransform.transform.rotation);
    }
    public void DeactivateShockWave(){
        slamAOETrigger.SetActive(false); 
    }
    public void CallShake(float time){
        StartCoroutine(cameraShakeComponent.Shake(time,0.4f));
    }
    public void CallParticles(){
        sparksParticles.Play();
    }

    public void BasicCallShake(float magnitude){
        StartCoroutine(cameraShakeComponent.Shake(0.1f, magnitude));
    }
#endregion

#region UI Control

public void CheckIfUnlock(float currentHealth){
        if(currentHealth < 75f && !hasUnlockedFirst){
            //unlock one
            unlockImage1.enabled = false;
            hasUnlockedFirst = true;
        }
        if(currentHealth < 50f && !hasUnlockedSecond){
            //unlock two
            unlockImage2.enabled = false;
            hasUnlockedSecond = true;
        }
    }

private void ResetCooldown1(){
        timeRemaining1 = timeRemaining1 - .1f;
        if(timeRemaining1 > 0) {
            coolDown1.fillAmount -= .033f;
            Invoke ( "ResetCooldown1", .1f );
        } else {
            coolDown1.fillAmount = 0.0f;
            timeRemaining1 = 3.0f;
            isOnCoolDown1 = false;
        }
}

private void ResetCooldown2(){
        timeRemaining2 = timeRemaining2 - .1f;
        if(timeRemaining2 > 0) {
            coolDown2.fillAmount -= .02f;
            Invoke ( "ResetCooldown2", .1f );
        } else {
            coolDown2.fillAmount = 0.0f;
            timeRemaining2 = 5.0f;
            isOnCoolDown2 = false;
        }
}

private void ResetCooldown3(){
        timeRemaining3 = timeRemaining3 - .1f;
        if(timeRemaining3 > 0) {
            coolDown3.fillAmount -= .00833f;
            Invoke ( "ResetCooldown3", .1f );
        } else {
            coolDown3.fillAmount = 0.0f;
            timeRemaining3 = 12.0f;
            isOnCoolDown3 = false;
        }
}
#endregion
    

}
