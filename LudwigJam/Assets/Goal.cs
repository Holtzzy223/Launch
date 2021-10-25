using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text winText;
    public Text popText;
    int maxPops = 1001;
    int popsAvailable;
    public PointEffector2D pointEffector;
    // Start is called before the first frame update
    void Start()
    {
        this.popsAvailable = this.maxPops;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
       
        spriteRenderer.material.EnableKeyword("_EMISSION");
        spriteRenderer.material.SetColor("_EmissionColor", Color.green);
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
        this.popsAvailable -= 10; ;
        this.popsAvailable = Mathf.Clamp(this.popsAvailable, 0, this.maxPops);
        if (this.popsAvailable > 0)
        {
            player.popSaved+=10;
        }
        player.popSaved = Mathf.Clamp(player.popSaved,0,player.popMax);
        if (this.popsAvailable == 0) 
        {
            if (player.popSaved >= player.popMax)
            {

                this.pointEffector.forceMagnitude = 10;
                if (player.popMax > 1000)
                {
                    DisplayWin();
                }
            }
            else
            {   
                this.pointEffector.forceMagnitude = 10;
            }
     
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerMover.instance.popSaved == 1000 && !PlayerMover.instance.firstPlanetComplete)
        {
            //trigger camera pan/zoom
            PlayerMover.instance.StartCoroutine(PlayerMover.instance.IncreasePop());
            PlayerMover.instance.cameraController.ActivateVirtualCamera();
            Destroy(this.gameObject);
        }
        else if (this.popsAvailable <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
