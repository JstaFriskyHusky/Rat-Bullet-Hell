using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    
    public GameObject bullet;
    public Transform gunPoint, aimTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring, spread;


    public SpriteRenderer characterRender, weaponRender;
    public Animator animator;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }

    void Awake() 
    {
        aimTransform = transform.Find("Aim");
    }

    void Update()
    {   
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);    

        
    

    

       

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