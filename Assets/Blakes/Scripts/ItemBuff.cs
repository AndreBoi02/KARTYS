using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemBuff : MonoBehaviour
{
    int numeroDelValorDeLaComida = 1;
    Growth growthScript;
    SnakeMovement snakeMov;
    SnakeMovementP2 snakeMov2;
    ObjectPooling objectPooling;

    // Start is called before the first frame update
    void Start()
    {
        growthScript = GetComponent<Growth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SnakeMovement player = other.GetComponent<SnakeMovement>();
            ObjectPooling objectPool = FindObjectOfType<ObjectPooling>();
            GameObject pooledObject = objectPool.RequestObject(); // obj pooling
            if (pooledObject != null)
            {
                pooledObject.SetActive(true);
                pooledObject.transform.position = transform.position;
            }
            gameObject.SetActive(false);
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("PLayer"))
    //        {
    //            //other.GetComponent<SnakeMovement>().m_snakeBodySize += numeroDelValorDeLaComida; //serialized field en vars PRIVATE
    //        }
    //    if (other.CompareTag("PLayer2"))
    //        {
    //            other.GetComponent<SnakeMovementP2>().m_snakeBodySize += numeroDelValorDeLaComida;
    //        }
    //    //if (other.CompareTag("Buff"))
    //    //{
    //    //    growthScript.GrowBody(1);
    //    //}
    //    //else if (other.CompareTag("Obstacle"))
    //    //{
    //    //    //growthScript.RemoveBodyPart();
    //    //}
    //}

}
