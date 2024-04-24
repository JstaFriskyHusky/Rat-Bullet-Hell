using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Movement Variables
    public float speed;
    public Transform weapon;
    public float offset;
    bool facingRight;

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

    Vector2 lastMoveDirection;
    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        
        ProcessInput();
        Animate();
        
        
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if(mousePos.x > transform.position.x && facingRight)
        {
            flip();
        }
        else if (mousePos.x < transform.position.x && !facingRight)
        {
            flip();
        }

        

        animator.SetFloat("Horizontal", Mathf.Abs(movement.x));
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // [WEAPON ROTATION] -----------------------------------------------------------------
        /// VVV this code allows the weapon to point in the direction of the mouse (BROKEN)
        /*
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        */

        
        
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

    void flip()
    {
        
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    void ProcessInput()
    {
    float Horizontal = Input.GetAxisRaw("Horizontal");
    float Vertical = Input.GetAxisRaw("Vertical");

    if((Horizontal == 0 && Vertical == 0) && (movement.x != 0 || movement.y != 0))
    {
        lastMoveDirection = movement;
    } 
    
    movement.x = Input.GetAxisRaw("Horizontal");
    movement.y = Input.GetAxisRaw("Vertical");

    movement.Normalize();
    }

    void Animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
    }

}
