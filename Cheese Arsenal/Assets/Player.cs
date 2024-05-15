using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public static int currentHealth;
    //float curTime = 0;
    //float nextDamage = 1;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Debug.Log("Starting health: " + maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //collision with enemies that have "Enemy" tag will cause player dmg
        if(collision.tag == "Enemy" || collision.tag == "Projectile")
        {
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            Debug.Log("Player lost 20 health. Current Health = " + currentHealth);
        }
        if(currentHealth <= 0)
        {
            Die();
            Debug.Log("Player has died");
        }

        //script for potion and getting more health
        if(collision.tag == "Cheese")
        {
            Debug.Log("Picked up potion.");
            if(currentHealth < 100)
            {
                currentHealth += 20;
                healthBar.SetHealth(currentHealth);
                Debug.Log("+20 health. Current health: " + currentHealth);
                Destroy(collision.gameObject);
                Debug.Log("Potion destroyed.");
            }
        }
    }




        //do
        //{
            //if(potion_collision.gameObject.name == "Potion")
            //{
                //currentHealth += 20;
                //healthBar.SetHealth(currentHealth);
                //Destroy(gameObject);
            //}

        //}
        //while(currentHealth != 100);
    //}


    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.name == "slime")
    //    {
    //        currentHealth -= 20;
    //        //Debug.Log("Player lost 20 health");
    //    }
    //    if(currentHealth <= 0)
    //    {
    //        Die();
    //        //Debug.Log("Player has died");
    //    }

    //}


    void Die()
    {
        //Instantiate(deathScreen);
        Destroy(gameObject);
    }


}


