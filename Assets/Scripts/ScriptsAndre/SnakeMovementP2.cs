using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovementP2 : MonoBehaviour
{
    #region Vars
    private Vector2Int m_gridMoveDirection;
    private Vector2Int m_gridPos;
    private float m_gridMoveTimer;
    private float m_gridMoveTimerMax;
    public float m_snakeBodySize;
    private List<Vector2Int> snakeMovePositionList = new List<Vector2Int>();

    private ObjectPooling m_objectPooling;

    public bool snakeAteFood = false;
    #endregion

    private void Awake()
    {
        m_gridPos = new Vector2Int(9, 10);
        m_gridMoveTimerMax = .5f;
        m_gridMoveTimer = m_gridMoveTimerMax;
        m_gridMoveDirection = new Vector2Int(1, 0);

        m_objectPooling = GameObject.Find("ObjectPoolingP2").GetComponent<ObjectPooling>();

        m_snakeBodySize = 2;
    }

    private void Update()
    {
        InputHandler();
        HandlerGridMovement();

        if (Input.GetKeyDown(KeyCode.F))
        {
            snakeAteFood = true;

            //snakeAteFood = false;
        }
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (m_gridMoveDirection.y != -1)
            {
                m_gridMoveDirection.x = 0;
                m_gridMoveDirection.y = 1;
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (m_gridMoveDirection.y != 1)
            {
                m_gridMoveDirection.x = 0;
                m_gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (m_gridMoveDirection.x != 1)
            {
                m_gridMoveDirection.x = -1;
                m_gridMoveDirection.y = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (m_gridMoveDirection.x != -1)
            {
                m_gridMoveDirection.x = 1;
                m_gridMoveDirection.y = 0;
            }
        }
    }

    void HandlerGridMovement()
    {
        m_gridMoveTimer += Time.deltaTime;
        if (m_gridMoveTimer >= m_gridMoveTimerMax)
        {
            m_gridPos -= m_gridMoveDirection;

            snakeMovePositionList.Insert(0, m_gridPos);

            m_gridMoveTimer -= m_gridMoveTimerMax;

            if (snakeAteFood)
            {
                m_snakeBodySize++;
                snakeAteFood = false;
            }

            if (snakeMovePositionList.Count >= m_snakeBodySize)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            for (int i = 0; i < snakeMovePositionList.Count - 1; i++)
            {
                //LOL QUE MAL
                Vector2Int snakeMovPos = snakeMovePositionList[i];
                GameObject temp = m_objectPooling.RequestObject();
                temp.transform.position = new Vector3(snakeMovPos.x, snakeMovPos.y);
                StartCoroutine(TurnBodyOff(temp));
            }

            transform.position = new Vector2(m_gridPos.x, m_gridPos.y);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(m_gridMoveDirection) + 90);
        }
    }

    float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }
        return n;
    }

    IEnumerator TurnBodyOff(GameObject t_object)
    {
        yield return new WaitForSeconds(1.0f);
        m_objectPooling.DespawnObject(t_object);
    }

    //Para hacer que el jugador crezca cuando combe deben:

    // Las furtas tienen que tener un RB, Collider con trigger,
    // en su script de la (fruta) una función de OntriggerEnter2D, comparan el tag que sea player o player 2
    // if (other.CompareTag("PLayer"))
    //{
    //other.GetComponent<SnakeMovemnt>().m_snakeBodySize; += numeroDelValorDeLaComida;
    //}
    // if (other.CompareTag("PLayer2"))
    //{
    //other.GetComponent<SnakeMovemntP2>().m_snakeBodySize; += numeroDelValorDeLaComida;
    //}
}
