using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteSwitch : MonoBehaviour
{

    public Sprite newSprite; 

    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    
}
