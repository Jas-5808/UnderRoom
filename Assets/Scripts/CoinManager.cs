using UnityEngine;
using TMPro; // ���������� TextMeshPro

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // �������� ��� ����������� �������
    public int coinCount = 0; // ���������� ��������� �����
    public TMP_Text coinText; // TextMeshPro UI-����� ��� ����������� ���������� �����

    void Awake()
    {
        // ������������� ��������
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ������ ��� �������� ����� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ����� ��� ���������� ���������� �����
    public void AddCoin()
    {
        coinCount++;
        UpdateCoinText(); // ��������� ����� � ����������� �����
    }

    // ����� ��� ���������� UI
    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }
}
