using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semi : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    
    public GameObject bullet;
    public Transform gunPoint;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring, spread;
    public AudioSource src;
    public AudioClip shotSound; 




    public SpriteRenderer characterRender, weaponRender;
    public Animator animator;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   


        
        if (!canFire)
        {   
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
                animator.SetBool("Shooting", false);
            }
            
        }

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            
            Instantiate(bullet, gunPoint.position, Quaternion.identity);
            animator.SetBool("Shooting", true);
            canFire = false;
            src.clip = shotSound;
            src.Play();
        }

    

       

       

    
    }

}
