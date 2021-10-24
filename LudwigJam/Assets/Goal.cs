using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text winText;
    public Text popText;

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
       
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerMover player = collision.gameObject.GetComponent<PlayerMover>();
        player.popSaved++;
        
        if (player.popSaved >= player.popMax)
        {
            if (player.popMax == 1000)
            {

                pointEffector.forceMagnitude = 10;
                
            }
            else
            {
                DisplayWin();
                pointEffector.forceMagnitude = 10;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerMover.instance.popSaved == 1000)
        {
            PlayerMover.instance.StartCoroutine(PlayerMover.instance.IncreasePop());
        }
    }
}
