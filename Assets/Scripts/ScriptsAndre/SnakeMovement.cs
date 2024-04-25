using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    #region
    //public float m_rotateSpeed = 200f;
    //public bool m_isRotating = false;
    //public float m_targetAngle = 0;

    //public Growth growth;

    //public List<GameObject> m_bodyPartsSM = new List<GameObject>();

    //public float m_speed = 4f;
    //public float m_bodyPartDistance = 1.5f;
    //public float rotationSpeed = 50f;

    //private Vector3 currentDirection = Vector3.up;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftArrow) && !m_isRotating)
    //    {
    //        m_targetAngle += 90;
    //        m_isRotating = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow) && !m_isRotating)
    //    {
    //        m_targetAngle += -90;
    //        m_isRotating = true;
    //    }

    //    if (m_isRotating)
    //    {
    //        float step = m_rotateSpeed * Time.deltaTime;
    //        float angle = Mathf.MoveTowardsAngle(NormalizeAngle(transform.eulerAngles.z), NormalizeAngle(m_targetAngle), step);
    //        transform.eulerAngles = new Vector3(0, 0, angle);

    //        if (Mathf.Abs(NormalizeAngle(m_targetAngle) - NormalizeAngle(transform.eulerAngles.z)) < 1)
    //        {
    //            m_isRotating = false;
    //        }
    //    }

    //    if (!m_isRotating)
    //    {
    //        Move();
    //    }

    //}

    //float NormalizeAngle(float angle)
    //{
    //    while (angle < 0)
    //    {
    //        angle += 360;
    //    }
    //    while (angle > 360)
    //    {
    //        angle -= 360;
    //    }
    //    return angle;
    //}

    //private void Move()
    //{
    //    m_bodyPartsSM = growth.m_bodyParts;
    //    transform.Translate(currentDirection * m_speed * Time.deltaTime);
    //    UpdateBodyParts();
    //}

    //private void UpdateBodyParts()
    //{
    //    for (int i = m_bodyPartsSM.Count - 1; i > 0; i--)
    //    {
    //        m_bodyPartsSM[i].transform.position = Vector3.Lerp(m_bodyPartsSM[i].transform.position,
    //            m_bodyPartsSM[i - 1].transform.position, m_bodyPartDistance);
    //    }

    //    if (m_bodyPartsSM.Count > 0)
    //    {
    //        m_bodyPartsSM[0].transform.position = Vector3.Lerp(m_bodyPartsSM[0].transform.position,
    //            transform.position, m_bodyPartDistance);
    //    }
    //}
    #endregion

    private Vector2Int m_gridMoveDirection;
    private Vector2Int m_gridPos;
    private float m_gridMoveTimer;
    private float m_gridMoveTimerMax;
    [SerializeField] private float m_snakeBodySize;
    private List<Vector2Int> snakeMovePositionList = new List<Vector2Int>();

    private ObjectPooling m_objectPooling;

    private bool snakeAteFood = false;

    private void Awake() {
        m_gridPos = new Vector2Int(10, 10);
        m_gridMoveTimerMax = .5f;
        m_gridMoveTimer = m_gridMoveTimerMax;
        m_gridMoveDirection = new Vector2Int(1, 0);

        m_objectPooling = GameObject.Find("ObjectPooling").GetComponent<ObjectPooling>();

        m_snakeBodySize = 1;
    }

    private void Update() {
        InputHandler();
        HandlerGridMovement();

        if (Input.GetKeyDown(KeyCode.F)) {
            snakeAteFood = true;
            
            //snakeAteFood = false;
        }
    }

    void InputHandler() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (m_gridMoveDirection.y != -1)
            {
                m_gridMoveDirection.x = 0;
                m_gridMoveDirection.y = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_gridMoveDirection.y != 1)
            {
                m_gridMoveDirection.x = 0;
                m_gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_gridMoveDirection.x != 1)
            {
                m_gridMoveDirection.x = -1;
                m_gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (m_gridMoveDirection.x != -1)
            {
                m_gridMoveDirection.x = 1;
                m_gridMoveDirection.y = 0;
            }
        }
    }

    void HandlerGridMovement() {
        m_gridMoveTimer += Time.deltaTime;
        if (m_gridMoveTimer >= m_gridMoveTimerMax) {
            m_gridPos += m_gridMoveDirection;

            snakeMovePositionList.Insert(0, m_gridPos);

            m_gridMoveTimer -= m_gridMoveTimerMax;

            if (snakeAteFood)
            {
                m_snakeBodySize++;
                snakeAteFood = false;
            }

            if (snakeMovePositionList.Count >= m_snakeBodySize) {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositionList.Count - 1; i++) {
                //LOL QUE MAL
                Vector2Int snakeMovPos = snakeMovePositionList[i];
                GameObject temp = m_objectPooling.RequestObject();
                temp.transform.position = new Vector3(snakeMovPos.x, snakeMovPos.y);
            }

            transform.position = new Vector2(m_gridPos.x, m_gridPos.y);
            transform.eulerAngles = new Vector3(0,0, GetAngleFromVector(m_gridMoveDirection) - 90);
        }
    }

    float GetAngleFromVector(Vector2Int dir) {
        float n = Mathf.Atan2(dir.y, dir.x) *Mathf.Rad2Deg;
        if (n < 0) {
            n += 360;
        }
        return n;
    }
}
