using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSound : MonoBehaviour
{
    [SerializeField] private AudioSource environmentSound;

    void Start()
    {
        environmentSound.Play();
    }

    void Update()
    {
        
    }
}
