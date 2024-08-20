using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // ������ �� ������ ������
    public GameObject coinPrefab;

    // ���������� ����� ��� ������
    public int numberOfCoins = 30;

    // �������� ��������� ��� ������ �����
    public float xMin = -10f;
    public float xMax = 10f;
    public float zMin = -10f;
    public float zMax = 10f;
    public float yPosition = 1f; // ������, �� ������� ����� ���������� ������

    void Start()
    {
        SpawnCoins();
    } 
    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            // ��������� ��������� ������� � �������� ���������� ���������
            Vector3 randomPosition = new Vector3(
                Random.Range(xMin, xMax),
                yPosition,
                Random.Range(zMin, zMax)
            );

            // �������� ������ �� ��������� �������
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }
}
