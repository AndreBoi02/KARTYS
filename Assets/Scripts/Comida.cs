using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{
    SnakeMovement snakeScriptP1;
    SnakeMovementP2 snakeScriptP2;
    Growth crecer;

    [SerializeField] private int numeroDelValorDeLaComida;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<SnakeMovement>().m_snakeBodySize += numeroDelValorDeLaComida;
            collision.GetComponent<Growth>().GrowBody(numeroDelValorDeLaComida);
        }
        if (collision.CompareTag("Player2"))
        {
            gameObject.SetActive(false);
            collision.GetComponent<SnakeMovementP2>().m_snakeBodySize += numeroDelValorDeLaComida;
            collision.GetComponent<Growth>().GrowBody(numeroDelValorDeLaComida);
        }
    }
}
