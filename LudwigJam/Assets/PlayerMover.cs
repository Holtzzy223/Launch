using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
    
    Rigidbody2D rigidBody;
    int pressCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
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
    //drop
    //camera view
    private void OnBecameInvisible()
    {

        string activeScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeScene);
    }
}
