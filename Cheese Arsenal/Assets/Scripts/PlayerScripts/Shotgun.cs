using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public int pelletCount;
    public float spreadAngle;
    public GameObject pellet;
    public Transform gunPoint;
    List<Quaternion> pellets;

    void Start()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++){
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }

    }



    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shoot();
        }

    }

    void shoot()
    {
        int i = 0;
        foreach(Quaternion quat in pellets)
        pellets[i] = Random.rotation;
        GameObject p = Instantiate(pellet, gunPoint.position, Quaternion.identity);
        p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);        
        i++;
    }

}
