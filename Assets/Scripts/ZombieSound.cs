using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
     public Transform player; 
    public AudioSource audioSource; 
    public float detectionRadius = 10f; // Радиус, в котором звук начинает воспроизводиться
    [Range(0f, 1f)]
    public float maxVolume = 1f; // Максимальная громкость звука
    public float maxPitch = 2f; // Максимальная высота звука
    [Range(0f, 1f)]
    public float minVolume = 0.1f; // Минимальная громкость звука
    public float minPitch = 1f; // Минимальная высота звука

    private bool isPlayerInRange = false;

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from this game object.");
        }

        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned.");
        }

        audioSource.volume = minVolume;
        audioSource.pitch = minPitch;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        float volumeFactor = Mathf.Clamp01(1 - (distanceToPlayer / detectionRadius));
        float pitchFactor = Mathf.Clamp(1 + (1 - (distanceToPlayer / detectionRadius)), minPitch, maxPitch);

        if (distanceToPlayer <= detectionRadius)
        {
            if (!isPlayerInRange)
            {
                audioSource.Play();
                isPlayerInRange = true;
            }

            audioSource.volume = Mathf.Lerp(minVolume, maxVolume, volumeFactor);
            audioSource.pitch = pitchFactor;
        }
        else
        {
            if (isPlayerInRange)
            {
                audioSource.Stop();
                isPlayerInRange = false;
            }
        }
    }

    void OnDrawGizmos()// Visually show the detection radius
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.blue;
        Vector3 minVolumePos = transform.position + Vector3.forward * detectionRadius;
        Gizmos.DrawLine(transform.position, minVolumePos);

        Gizmos.color = Color.green;
        Vector3 maxVolumePos = transform.position + Vector3.forward * detectionRadius * (maxVolume - minVolume) / (maxVolume + minVolume);
        Gizmos.DrawLine(transform.position, maxVolumePos);
    }
}
