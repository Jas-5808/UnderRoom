using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 360f;
    public static int coinCount = 0; // Статическая переменная для учета всех собранных монет
    public Text coinText; // Ссылка на UI Text компонент

    void Start()
    {
        // Инициализация текста количества монет
        coinText.text = "Монеты: " + coinCount.ToString();
    }

    void Update()
    {
        // Вращение монеты
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверка на столкновение с игроком
        {
            coinCount++; // Увеличиваем количество монет
            coinText.text = "Монеты: " + coinCount.ToString(); // Обновляем текст в UI

            Destroy(PirateCoin); // Уничтожаем монету
        }
    }
}
