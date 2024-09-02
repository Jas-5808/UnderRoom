using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource; // ������������� ��� ������ �����
    public AudioClip[] footstepClips; // ������ ������ ����� ��� ������
    public float stepInterval = 0.5f; // �������� ����� ������
    private float stepTimer = 0f; // ������ ��� ������������ ������� ����� ������

    private CharacterController characterController; // ��������� CharacterController ��� ������������ ��������
    private int currentFootstepClipIndex = 0; // ������ �������� ���������� �����

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // ���������, ��� footstepAudioSource ��������
        if (footstepAudioSource == null)
        {
            footstepAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // ���������� ��������� ����
        if (footstepClips.Length > 0)
        {
            footstepAudioSource.clip = footstepClips[currentFootstepClipIndex];
        }
    }

    void Update()
    {
        // ������������ ������ ��� ������� �� ������� (��������, ������� "C" ��� ����� �����)
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeFootstepSound();
        }

        // ��������������� ����� ��� ��������
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
            stepTimer = 0f; // ����� �������, ���� ����� �� ���������
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
            // ������������� �� ��������� �������� ����
            currentFootstepClipIndex = (currentFootstepClipIndex + 1) % footstepClips.Length;
            footstepAudioSource.clip = footstepClips[currentFootstepClipIndex];
            Debug.Log("Footstep sound changed to: " + footstepClips[currentFootstepClipIndex].name);
        }
    }
}
