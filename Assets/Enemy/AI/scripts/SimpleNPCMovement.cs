using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNPCMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // �������� �������� NPC
    private float distanceToMove = 3f; // ���������� ��� ��������

    private Vector3 initialPosition; // ��������� ������� NPC
    private bool isMoving = false; // ����, �����������, ��������� �� NPC � ������ ������

    private float delayBeforeStart = 5f; // �������� ����� ������� ��������
    [SerializeField] private float timer = 0f; // ������ ��� �������� �������

    void Start()
    {
        initialPosition = transform.position; // ���������� ��������� ������� NPC
    }

    void Update()
    {
        // ��������� ������
        timer += Time.deltaTime;

        // ���������, ������ �� ������ ����������� ��������
        if (timer >= delayBeforeStart && !isMoving)
        {
            // ���� ������ �������� � NPC ��� �� ��������, �������� ��������
            isMoving = true;
        }

        if (isMoving)
        {
            // ���� NPC ��������, ���������� ��� ��������
            float moveDistance = moveSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveDistance);

            // ���������, ������ �� NPC ������������ ����������
            float currentDistance = Vector3.Distance(transform.position, initialPosition);
            if (currentDistance >= distanceToMove)
            {
                // ���� NPC ������ ������������ ����������, ������������� ���
                isMoving = false;
                transform.position = initialPosition + transform.forward * distanceToMove; // ������������� ������ �������, ����� �������� �����������
            }
        }
    }
}
