using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
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
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }




    // Trigger damage on colliding with enemy
    void OnTriggerEnter2D(Collider2D hitInfo)   
    { 
        //kills enemies with Enemy script
        Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        //kills enemies with Enemies script
        Debug.Log(hitInfo.name);
        Enemies enemies = hitInfo.GetComponent<Enemies>();
        if (enemies != null) {
            enemies.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    // Collide with anything, create an effect and despawn
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("Collectible")) 
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);
        }
    }
}
