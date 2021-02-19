using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Health : MonoBehaviour
{
    public float current_health = 100;
    public GameObject DieEffect;
    // Start is called before the first frame update
    void Start()
    {

        
    }
    public void TakeDamage(float amt)
    {
        current_health -= amt;

        if(current_health <= 0)
        {
            current_health = 0;
            Die();
        }
    }

    void Die()
    {

        if(gameObject.tag == "Chicken")
        {
            Destroy(gameObject);
        }
    }

    
    
}
