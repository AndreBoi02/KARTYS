using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Player2Body"))
        {
            print("Perdiste Brah");
            gameObject.SetActive(false);
            GameObject tempPool = GameObject.Find("ObjectPoolingP1");
            tempPool.SetActive(false);
        }
    }
}
