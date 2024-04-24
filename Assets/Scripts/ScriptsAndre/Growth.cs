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
    
    void Start() {
        m_bodyParts.Add(m_head);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GrowBody(m_testInt);
        }
    }

    public void GrowBody(int t_bodySize) {
        if (t_bodySize == 1 && m_bodyParts.Count == 1) {
            m_bodyParts.Add(m_tail);
            placeBodyParts(m_tail);
        }
        else {
            for (int i = 0; i < t_bodySize; i++) {
                if (i == (t_bodySize - 1) && t_bodySize != 1) {
                    m_bodyParts.Add(m_tail);
                    placeBodyParts(m_tail);
                }
                else {
                    m_bodyParts.Add(m_body);
                    placeBodyParts(m_body);
                }
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
