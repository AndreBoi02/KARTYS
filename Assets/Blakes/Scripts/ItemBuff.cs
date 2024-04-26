using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuff : MonoBehaviour
{
    Growth growthScript;

    // Start is called before the first frame update
    void Start()
    {
        growthScript = GetComponent<Growth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buff"))
        {
            growthScript.GrowBody(1);
        }
        else if (other.CompareTag("Obstacle"))
        {
            //growthScript.RemoveBodyPart();
        }
    }
}
