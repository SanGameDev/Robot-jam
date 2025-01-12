using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float Health = 100f;

    public void TakeDamage(float Damage){
        Health -= Damage;
        if(Health <= 0){
            PlayerDeath();
        }
    }

    public void PlayerDeath(){
        print("dead");
    }
}
