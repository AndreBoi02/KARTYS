using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreP1 : MonoBehaviour
{
    private float scorePoint;
    private TextMeshProUGUI P1;


    private void Start()
    {
        P1 = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //scorePoint += Time.deltaTime;
        P1.text = scorePoint.ToString("0");
    }

    public void Increase(float scorePlus)
    {
        scorePoint += scorePlus;
    }
}
