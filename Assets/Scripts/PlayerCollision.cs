using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called with: " + other.gameObject.tag);

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy collided with player");
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
    }

}
