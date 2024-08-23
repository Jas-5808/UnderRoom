using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public static int coinCount = 0; // ����������� ���������� ��� ����� ���� ��������� �����
    public Text coinText; // ������ �� UI Text ���������

    void Start()
    {
        // ������������� ������ ���������� �����
        coinText.text = "������: " + coinCount.ToString();
    }

    void Update()
    {
        // �������� ������
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �������� �� ������������ � �������
        {
            coinCount++; // ����������� ���������� �����
            coinText.text = "������: " + coinCount.ToString(); // ��������� ����� � UI

            Destroy(PirateCoin); // ���������� ������
        }
    }
}
