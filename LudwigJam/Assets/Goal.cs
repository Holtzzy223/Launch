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
        // pop win message
        // pop stats display
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
        player.popSaved = Mathf.Clamp(player.popSaved,0,player.popMax);
        if (player.popSaved >= player.popMax)
        {
            if (player.popMax == 1000)
            {

                this.pointEffector.forceMagnitude = 10;
                //trigger camera pan/zoom
                
            }
            else
            {
                DisplayWin();
                this.pointEffector.forceMagnitude = 10;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerMover.instance.popSaved == 1000&&!PlayerMover.instance.firstPlanetComplete)
        {
            PlayerMover.instance.StartCoroutine(PlayerMover.instance.IncreasePop());
            PlayerMover.instance.cameraController.ActivateVirtualCamera();
            Destroy(this.gameObject);
        }
    }
}
