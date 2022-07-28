using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnFireCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FairyFlame"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }
}
