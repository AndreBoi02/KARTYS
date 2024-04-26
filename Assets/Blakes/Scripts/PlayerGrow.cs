using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrow : MonoBehaviour
{
    public GameObject headPrefab;
    public GameObject bodyPrefab;
    public GameObject tailPrefab;

    private Transform head;
    private Transform tail;
    private Transform[] bodySegments;

    void Start()
    {
        head = Instantiate(headPrefab, transform.position, Quaternion.identity).transform;
        tail = Instantiate(tailPrefab, transform.position - new Vector3(1, 0, 0), Quaternion.identity).transform;
        bodySegments = new Transform[0];
    }

    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(head.position, 0.5f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("increase"))
            {
                AddBodySegment();
                Destroy(collider.gameObject);
            }
        }
        UpdateBodySegments();
    }

    void AddBodySegment()
    {
        Transform newBodySegment = Instantiate(bodyPrefab, tail.position, Quaternion.identity).transform;
        Transform[] newBodyArray = new Transform[bodySegments.Length + 1];
        for (int i = 0; i < bodySegments.Length; i++)
        {
            newBodyArray[i] = bodySegments[i];
        }
        newBodyArray[newBodyArray.Length - 1] = newBodySegment;
        bodySegments = newBodyArray;
        tail = newBodySegment;
    }
    void UpdateBodySegments()
    {
        Vector3 previousPosition = head.position;
        for (int i = 0; i < bodySegments.Length; i++)
        {
            Vector3 temp = bodySegments[i].position;
            bodySegments[i].position = previousPosition;
            previousPosition = temp;
        }
        tail.position = previousPosition;
    }
    //ARR.ADD PARA CRECER

//      List<GameObject> arr = new List<GameObject>
//      for(int i = arr.Count(); i >= 1; --i)
}
