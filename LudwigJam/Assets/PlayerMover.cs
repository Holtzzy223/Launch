using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    public Text popText;
    public CameraController cameraController;
    public static PlayerMover instance;
    public bool firstPlanetComplete = false;
    public int popSaved;
    public int popMax = 1000;

    Rigidbody2D rigidBody;
    int pressCount = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        popText.text = string.Format("Pops Rescued: {0:#,###0}/{1:#,###0}", popSaved, popMax);
        
        GetInput();
        Debug.Log(pressCount);
    }

    //check input
    public void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            pressCount++;
            rigidBody.AddForceAtPosition(new Vector2(0,-40-pressCount),Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pressCount++;
            rigidBody.AddForceAtPosition(new Vector2(0, 40+pressCount), Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pressCount++;
            rigidBody.AddForceAtPosition(new Vector2(40+pressCount, 0), Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pressCount++;
            rigidBody.AddForceAtPosition(new Vector2(-40-pressCount, 0), Vector2.left);
        }
    }

    //camera view
    private void OnBecameInvisible()
    {
        if (!firstPlanetComplete)
        {
            string activeScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(activeScene);
        }
    }
    public IEnumerator IncreasePop()
    {
        Goal[] goals = FindObjectsOfType<Goal>();
        Debug.Log(goals.Length);
        firstPlanetComplete = true;
        for (int i = 0; i < goals.Length - 1; i++)
        {
           
              
            popMax += 1000;
            yield return new WaitForEndOfFrame();
            
        }
        
    }
}
