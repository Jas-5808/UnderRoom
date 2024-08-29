using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Скорость вращения

    void Update()
    {
        // Вращаем монету вокруг оси Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                // Попытка вызвать метод AddCoin()
                CoinManager.instance.AddCoin();
            }
            catch (System.Exception e)
            {
                // Логируем ошибку, если возникнет
                Debug.LogError("Ошибка при добавлении монеты: " + e.Message);
            }
            finally
            {
                // Уничтожаем монету в любом случае
                Destroy(gameObject);
            }
        }
    }
}
