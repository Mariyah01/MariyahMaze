using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float volume;

    private void Update()
    {
        transform.Rotate(0f, 0f, 200*Time.deltaTime, Space.Self);
    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent<FPController>(out var playerMovement))
        {
            AudioSource.PlayClipAtPoint(_audioClip, transform.position,volume);
            Destroy(gameObject);
            playerMovement.wallet += 1;
            Debug.Log($"Wallet coins{playerMovement.wallet}");
        }
        
    }
    
    
}
