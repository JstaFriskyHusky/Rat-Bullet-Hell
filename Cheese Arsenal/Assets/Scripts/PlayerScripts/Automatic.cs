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
    private bool canReload;
    private float timer;
    public float timeBetweenFiring, reloadTime;
    public int currentMag, maxMag = 0, currentAmmo, maxAmmo = 0;
    public AudioSource src;
    public AudioClip shotSound; 



    public SpriteRenderer characterRender, weaponRender;
    public Animator animator;
    

    void Start()
    {
        currentAmmo = maxAmmo;
        currentMag = maxMag;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
    }

    

    void Update()
    {   
    
        if (canReload)
        return;
        
        if (!canFire && currentMag > 0)
        {   
            timer += Time.deltaTime;
            if(timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
                animator.SetBool("Shooting", false);

                currentMag--;
            }
            
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            
            Instantiate(bullet, gunPoint.position, Quaternion.identity);
            canFire = false;
            animator.SetBool("Shooting", true);
            src.clip = shotSound;
            src.Play();
        }

        if( Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }
    
    }

    IEnumerator Reload()
        {
            canReload = true;
            animator.SetBool("Reload", true);
            yield return new WaitForSeconds(reloadTime);
            int reloadAmount = maxMag - currentMag;
            reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
            currentMag += reloadAmount;
            currentAmmo -= reloadAmount;
            animator.SetBool("Reload", false);
            canReload = false;
        }

    void AddAmmo(int ammoAmount)
        {
            currentAmmo += ammoAmount;
            if(currentAmmo > maxAmmo)
            {
                currentAmmo = maxAmmo;
            }
        }

}
