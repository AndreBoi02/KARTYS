using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGameOverP2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("PlayerBody"))
        {
            print("Perdiste Brah");
            gameObject.SetActive(false);
            GameObject tempPool = GameObject.Find("ObjectPoolingP2");
            tempPool.SetActive(false);
        }
    }
}
