using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public SpriteRenderer characterRender, weaponRender;
    public Animator animator;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {   
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);    

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Shooting");
        }
       

        if (!canFire)
        {   
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            animator.SetBool("Shooting", false); 
        }
    
        Vector3 direction = (mousePos - (Vector3)transform.position).normalized;

        Vector3 scale = transform.localScale;
        if(direction.x < 0){
            scale.y = -1;
        }
        else if (direction.x > 0)
        {
            scale.y = 1;
        }
        transform.localScale = scale;

        if(transform.eulerAngles.z > 0 && transform.eulerAngles.z < 180)
        {
            weaponRender.sortingOrder = characterRender.sortingOrder - 1;
        }
        else
        {
            weaponRender.sortingOrder = characterRender.sortingOrder + 1;
        }
    }


}