using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 0f; // ����, �� ������� ����� �����������
    public float closeAngle = 90f; // ����, �� ������� ����� �����������
    public float rotationSpeed = 2f; // �������� �������� �����
    private bool isOpen = false; // ��������� �����
    private bool isRotating = false; // ���������, ��������� �� �����

    private Quaternion targetRotation; // ������� ��������

    void Update()
    {
        // ���������, ������ �� ������� E
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            isOpen = !isOpen; // ������ ��������� �����
            targetRotation = Quaternion.Euler(0, isOpen ? openAngle : closeAngle, 0);
            isRotating = true; // �������� ��������
        }

        // ������ ������������ ����� � �������� ����
        if (isRotating)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);

            // ���� ����� �������� �������� ����, ������������� ��������
            if (Quaternion.Angle(transform.localRotation, targetRotation) < 0.1f)
            {
                transform.localRotation = targetRotation; // ������������� ������ ����
                isRotating = false; // ������������� ��������
            }
        }
    }
}
