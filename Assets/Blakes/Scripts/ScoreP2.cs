using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreP2 : MonoBehaviour
{
    private float scorePoint;
    private TextMeshProUGUI P2;


    private void Start()
    {
        P2 = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //scorePoint += Time.deltaTime;
        P2.text = scorePoint.ToString("0");
    }

    public void Increase(float scorePlus)
    {
        scorePoint += scorePlus;
    }
}
