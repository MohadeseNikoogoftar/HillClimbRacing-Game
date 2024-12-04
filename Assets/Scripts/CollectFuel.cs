using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    private AudioSource audioSource; 

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FuelController.instance.FillFuel();
            if (audioSource != null)
            {
                audioSource.Play(); 
            }
            Destroy(gameObject);
        }
    }
}
