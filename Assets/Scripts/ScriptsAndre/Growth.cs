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
        if (Input.GetKeyDown(KeyCode.W))
        {
            RemoveBodyPart();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CutBody();
        }
    }

    public void GrowBody(int t_bodySize)
    {
        //¿El cuerpo va a crecer 1 unidad?
        if (t_bodySize == 1) {
            //Sí

            //¿El cuerpo solo tiene la cabeza?
            if (m_bodyParts.Count == 1) {
                //Sí
                m_tail.SetActive(true);
                m_bodyParts.Add(m_tail);
                PlaceBodyParts(m_tail);
            }
            else {
                RemoveBodyPart();

                GameObject m_tempBodyPart = objectPooling.RequestObject();
                m_bodyParts.Add(m_tempBodyPart);
                PlaceBodyParts(m_tempBodyPart);

                m_tail.SetActive(true);
                m_bodyParts.Add(m_tail);
                PlaceBodyParts(m_tail);
            }
        }
        else {
            //No

            //¿El cuerpo solo tiene la cabeza?
            if (m_bodyParts.Count == 1) {
                //Sí
                for (int i = 0; i < t_bodySize; i++) {
                    if (i == (t_bodySize - 1)) {
                        m_tail.SetActive(true);
                        m_bodyParts.Add(m_tail);
                        PlaceBodyParts(m_tail);
                    } 
                    else {
                        GameObject m_tempBodyPart = objectPooling.RequestObject();
                        m_bodyParts.Add(m_tempBodyPart);
                        PlaceBodyParts(m_tempBodyPart);
                    }
                }
            } 
            else {
                // No
                RemoveBodyPart();
                t_bodySize ++;
                for (int i = 0; i < t_bodySize; i++) {
                    if (i == (t_bodySize - 1)) {
                        m_tail.SetActive(true);
                        m_bodyParts.Add(m_tail);
                        PlaceBodyParts(m_tail); 
                    }
                    else {
                        GameObject m_tempBodyPart = objectPooling.RequestObject();
                        m_bodyParts.Add(m_tempBodyPart);
                        PlaceBodyParts(m_tempBodyPart);
                    }
                }
            }
        }
    }

    private void PlaceBodyParts(GameObject t_bodyPart2Place) {
        t_bodyPart2Place.transform.position =
            new Vector3 (m_bodyParts[m_bodyParts.Count - 2].transform.position.x,
            m_bodyParts[m_bodyParts.Count - 2].transform.position.y - m_offSet, 
            m_bodyParts[m_bodyParts.Count - 2].transform.position.z);
    }

    private void RemoveBodyPart() {
        m_bodyParts[m_bodyParts.Count - 1].SetActive(false);
        m_bodyParts.RemoveAt(m_bodyParts.Count - 1);
    }

    public void CutBody() {
        if (m_bodyParts.Count == 2) {
            RemoveBodyPart();
            
        }
        else {
            for (int i = 0; i < 2; i++) {
                m_bodyParts[m_bodyParts.Count - 1].SetActive(false);
                m_bodyParts.RemoveAt(m_bodyParts.Count - 1);
            }
            m_tail.SetActive(true);
            m_bodyParts.Add(m_tail);
            PlaceBodyParts(m_tail);
        }
    }
}
