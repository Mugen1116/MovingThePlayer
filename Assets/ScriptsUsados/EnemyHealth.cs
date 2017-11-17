using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int health = 50;

    public void TakeDamage(int cant) {

        health -= cant;
        if (health <= 0 ){
            //Enemigo muere
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
