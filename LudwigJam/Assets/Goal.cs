using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text winText;
    public Text popText;
    public int popSaved;
    public int popMax = 1000;
    public PointEffector2D pointEffector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void DisplayWin()
    {

        winText.text = "WINNER WINNER CHICKEN DINNER";
        winText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        popText.text = string.Format("Pops Rescued: {0:#,###0}/{1:#,###0}",popSaved,popMax);
        popSaved = Mathf.Clamp(popSaved, 0, popMax);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        popSaved++;
       

        if (popSaved >= popMax)
        {
            if (popMax == 1000)
            {

                pointEffector.forceMagnitude = 10;
                StartCoroutine(IncreasePop());
            }
            else
            {
                DisplayWin();
                pointEffector.forceMagnitude = 10;
            }
        }
    }
    public IEnumerator IncreasePop()
    {
        popMax+=100;

        yield return new WaitForEndOfFrame();
    }
}
