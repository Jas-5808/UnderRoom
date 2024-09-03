using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepSound : MonoBehaviour
{
    private AudioSource audioSource;
    private CharacterController characterController;
    private bool isMoving = false;

    public float moveThreshold = 0.1f; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
        
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this game object");
        }

        if (characterController == null)
        {
            Debug.LogError("CharacterController component is missing from this game object");
        }
    }

    void Update()
    {
        Vector3 velocity = characterController.velocity;

        if (velocity.magnitude > moveThreshold)
        {
            if (!isMoving)
            {
                audioSource.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                audioSource.Stop();
                isMoving = false;
            }
        }
    }
}
