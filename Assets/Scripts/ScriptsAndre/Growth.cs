using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    [SerializeField] GameObject m_head;
    [SerializeField] GameObject m_body;
    [SerializeField] GameObject m_tail;
    [SerializeField] float m_offSet;
    [SerializeField] int m_testInt;

    public List<GameObject> m_bodyParts = new List<GameObject>();

    ObjectPooling objectPooling;

    void Start() {
        m_bodyParts.Add(m_head);
        objectPooling = GameObject.Find("ObjectPooling").GetComponent<ObjectPooling>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GrowBody(m_testInt);
        }
    }

    public void GrowBody(int t_bodySize)
    {
        if (t_bodySize == 1)
        {
            if (m_bodyParts.Count == 1)
            {
                m_bodyParts.Add(m_tail);
                placeBodyParts(m_tail);
            }
            else
            {
                GameObject m_tempBodyPart = objectPooling.RequestObject();
                m_bodyParts.Add(m_tempBodyPart);
                placeBodyParts(m_tempBodyPart);
            }
        }
        else
        {
            if (m_bodyParts.Count == 1)
            {
                for (int i = 0; i < t_bodySize; i++)
                {
                    if (i == (t_bodySize - 1))
                    {
                        m_bodyParts.Add(m_tail);
                        placeBodyParts(m_tail);
                    }
                    else
                    {
                        GameObject m_tempBodyPart = objectPooling.RequestObject();
                        m_bodyParts.Add(m_tempBodyPart);
                        placeBodyParts(m_tempBodyPart);
                    }
                }
            } else
            {
                //El mismo codigo de arriba pero tenemos que usar RemoveAt()
            }
            
        }
    }

    private void placeBodyParts(GameObject t_bodyPart2Place) {
        t_bodyPart2Place.transform.position =
            new Vector3 (m_bodyParts[m_bodyParts.Count - 2].transform.position.x,
            m_bodyParts[m_bodyParts.Count - 2].transform.position.y - m_offSet, 
            m_bodyParts[m_bodyParts.Count - 2].transform.position.z);
    }
}
