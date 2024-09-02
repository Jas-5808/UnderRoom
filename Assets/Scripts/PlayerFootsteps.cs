using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Аудиоисточник для звуков шагов
    public AudioClip[] footstepClips; // Массив звуков шагов для выбора
    public float stepInterval = 0.5f; // Интервал между шагами
    private float stepTimer = 0f; // Таймер для отслеживания времени между шагами

    private CharacterController characterController; // Компонент CharacterController для отслеживания движения
    private int currentFootstepClipIndex = 0; // Индекс текущего выбранного звука

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Убедитесь, что footstepAudioSource настроен
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Установите начальный звук
        if (footstepClips.Length > 0)
        {
            footstepAudioSource.clip = footstepClips[currentFootstepClipIndex];
        }
    }

    void Update()
    {
        // Переключение звуков при нажатии на клавишу (например, клавиша "C" для смены звука)
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeFootstepSound();
        }

        // Воспроизведение шагов при движении
        if (characterController.isGrounded && characterController.velocity.magnitude > 0.1f)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer > stepInterval)
            {
                PlayFootstepSound();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f; // Сброс таймера, если игрок не двигается
        }
    }

    void PlayFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            footstepAudioSource.Play();
        }
    }

    void ChangeFootstepSound()
    {
        if (footstepClips.Length > 0)
        {
            // Переключаемся на следующий звуковой клип
            currentFootstepClipIndex = (currentFootstepClipIndex + 1) % footstepClips.Length;
            footstepAudioSource.clip = footstepClips[currentFootstepClipIndex];
            Debug.Log("Footstep sound changed to: " + footstepClips[currentFootstepClipIndex].name);
        }
    }
}
