using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMover : MonoBehaviour
{
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
        popSaved = Mathf.Clamp(popSaved, 0, popMax);
        GetInput();
        if (firstPlanetComplete)
        {
            StartCoroutine(IncreasePop());
        }
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
    public IEnumerator IncreasePop()
    {
        for (int i = 0; i <= 900; i++)
        {
           

            popMax += 100;
            yield return new WaitForEndOfFrame();
        }
    }
}
