using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force, destroyTime;
    public GameObject hitEffect;
    public int damage = 1;

    // Unused Variables
    /*
    public float speed;
    */

    void Start()
    {

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 0);
    }

    void Update()
    {
        destroyTime -= Time.deltaTime;
        if (destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    // Trigger damage on colliding with enemy
    void OnTriggerEnter2D(Collider2D hitInfo)   
    { 
        //kills enemies with Enemies script
        Debug.Log(hitInfo.name);
        Enemies enemies = hitInfo.GetComponent<Enemies>();
        if (enemies != null) {
            enemies.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }

        if (hitInfo.gameObject.CompareTag("Map"))
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
    }

    // Collide with anything, create an effect and despawn [DOESNT WORK]

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Collectible")) 
    //     {
    //         GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
    //         Destroy(effect, 0.1f);
    //         Destroy(gameObject);
    //     }
    // }


}
