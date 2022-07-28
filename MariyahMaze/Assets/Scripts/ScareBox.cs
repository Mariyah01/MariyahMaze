using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareBox : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource _audioSource;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
        }
    }
}
