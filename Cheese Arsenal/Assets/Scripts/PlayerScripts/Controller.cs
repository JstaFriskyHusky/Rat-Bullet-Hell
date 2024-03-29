using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Movement Variables
    public float speed;
    public Transform weapon;
    public float offset;

    // Weapon Movement Variables
    public Transform shotPoint;
    public GameObject projectile;

    // Shooting Variables
    public float timeBetweenShots;
    float nextShotTime;

    // Other Variables
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        // [PLAYER MOVEMENT] ----------------------------------------------------------------
        // VVV this code translates the character, likely causes future problems
        /*
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * speed * Time.deltaTime;
        */

        // VVV this theoretically allows movement AND collision
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // [WEAPON ROTATION] -----------------------------------------------------------------
        /// VVV this code allows the weapon to point in the direction of the mouse (BROKEN)
        /*
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        */

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        // SHOT DELAY ------------------------------------------------------------------------
        /*
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Time.time > nextShotTime)
            {
                nextShotTime = Time.time + timeBetweenShots;
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);  
            }
        } 
        */
    }

    void FixedUpdate()
    {
        // Player movement updating
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


    }
}
