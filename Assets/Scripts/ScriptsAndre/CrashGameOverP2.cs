using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGameOverP2 : MonoBehaviour
{
    [SerializeField] private GameObject muelto;
    [SerializeField] private GameObject fondo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("PlayerBody"))
        {
            muelto.SetActive(true);
            fondo.SetActive(false);
            print("Perdiste Brah");
            gameObject.SetActive(false);
            GameObject tempPool = GameObject.Find("ObjectPoolingP2");
            tempPool.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
