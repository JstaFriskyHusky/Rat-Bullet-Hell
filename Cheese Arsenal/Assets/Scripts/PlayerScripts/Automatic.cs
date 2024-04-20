using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimAutomatic : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    
    public GameObject bullet;
    public Transform gunPoint;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring, spread;




    public SpriteRenderer characterRender, weaponRender;
    public Animator animator;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

        if (Input.GetMouseButton(0) && canFire)
        {
            
            Instantiate(bullet, gunPoint.position, Quaternion.identity);
            canFire = false;
            animator.SetBool("Shooting", true);
        }

    
    }



}