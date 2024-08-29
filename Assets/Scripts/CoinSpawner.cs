using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // Ссылка на префаб монеты
    public GameObject coinPrefab;

    // Количество монет для спавна
    public int numberOfCoins = 30;

    // Диапазон координат для спавна монет
    public float xMin = -10f;
    public float xMax = 10f;
    public float zMin = -10f;
    public float zMax = 10f;
    public float yPosition = 1f; // Высота, на которой будут появляться монеты

    void Start()
    {
        SpawnCoins();
    } 
    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            // Генерация случайной позиции в пределах указанного диапазона
            Vector3 randomPosition = new Vector3(
                Random.Range(xMin, xMax),
                yPosition,
                Random.Range(zMin, zMax)
            );

            // Создание монеты на случайной позиции
            Instantiate(coinPrefab, randomPosition, Quaternion.identity);
        }
    }
}
