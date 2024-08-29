using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // �������� ��������

    void Update()
    {
        // ������� ������ ������ ��� Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                // ������� ������� ����� AddCoin()
                CoinManager.instance.AddCoin();
            }
            catch (System.Exception e)
            {
                // �������� ������, ���� ���������
                Debug.LogError("������ ��� ���������� ������: " + e.Message);
            }
            finally
            {
                // ���������� ������ � ����� ������
                Destroy(gameObject);
            }
        }
    }
}
