using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnWallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource _audioSource;
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         _audioSource = GetComponent<AudioSource>();
    //         _audioSource.Play();
    //     }
    // }

    private void OnCollisionEnter(Collision other)
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }
    }
    
}
