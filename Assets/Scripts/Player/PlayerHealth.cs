using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public GameManager gameManager;
    public float Health = 100f;
    public Image HealthBar;
    public GameObject deathPanel;
    public GameObject playerHud;
    public bool isDead = false;

    private PlayerSpecialAttacks SA;

    private void Start() {
        SA = GetComponent<PlayerSpecialAttacks>();
    }

    public void TakeDamage(float Damage){
        Health -= Damage;
        HealthBar.fillAmount = Health/100f;

        SA.CheckIfUnlock(Health);
        
        if(Health <= 0){
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        deathPanel.SetActive(true);
        playerHud.SetActive(false);
        gameManager.GameOver();
        Cursor.lockState = CursorLockMode.Confined;
        isDead = true;
    }
}
