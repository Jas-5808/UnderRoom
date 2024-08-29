using UnityEngine;
using TMPro; // Подключаем TextMeshPro

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Синглтон для глобального доступа
    public int coinCount = 0; // Количество собранных монет
    public TMP_Text coinText; // TextMeshPro UI-текст для отображения количества монет

    void Awake()
    {
        // Устанавливаем синглтон
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при переходе между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Метод для увеличения количества монет
    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText(); // Обновляем текст с количеством монет
    }

    // Метод для обновления UI
    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
