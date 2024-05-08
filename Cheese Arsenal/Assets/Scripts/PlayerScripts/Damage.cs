using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private Material flash;
    [SerializeField] private float duration;
    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals ("Zombie") && Player.currentHealth > 0)
        StartCoroutine ("FlashRoutine");
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flash;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
        flashRoutine = null;
    }

    public void Flash()
    {
        if (flashRoutine != null)
        {
        StopCoroutine (flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
    
}
