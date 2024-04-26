using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public enum Score
    {
        P2Score, PlayerScore
    }

    public TextMeshProUGUI P2ScoreTxt, PlayerScoreTxt;

    #region Scores
    private int p2Score, playerScore;

    private int P2Score
    {
        get { return p2Score; }
        set
        {
            P2Score = value;
        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
        }
    }
    #endregion

    public void Increment(Score whichScore) //mandar a llamar con la logica para que funcione desde las acciones del jugador
    {
        if (whichScore == Score.P2Score)
            P2ScoreTxt.text = (++P2Score).ToString();
        else
            PlayerScoreTxt.text = (++PlayerScore).ToString();
    }

    public void ResetScores()
    {
        P2Score = PlayerScore = 0;
        P2ScoreTxt.text = PlayerScoreTxt.text = "0";
    }

    /*ESTO VA EN EL SCRIPT DE LA COMIDA
    public Counter CounterInstance;
    public Growth GrowthInstance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            if (other.tag == "PlayerBody")
            {
                CounterInstance.Increment(Counter.Score.PlayerScore);
                //GrowBody = true;
            }
            else if (other.tag == "Player2Body")
            {
                CounterInstance.Increment(Counter.Score.P2Score);
                //GrowBody = true;
            }
        }
    }
}*/
