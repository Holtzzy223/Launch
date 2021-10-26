using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float startPosX, startPosY , lengthX, lengthY;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempX = (cam.transform.position.x *(1-parallaxEffect));
        float tempY = (cam.transform.position.y *(1-parallaxEffect));
        float distX = (cam.transform.position.x * parallaxEffect/2);
        float distY = (cam.transform.position.y * parallaxEffect/2);

        transform.position = new Vector3(startPosX + distX, startPosY - distY, transform.position.z);
        if (tempX > startPosX + lengthX)
        {
            startPosX += lengthX;
        }
        else if (tempX<startPosX - lengthX)
        {
            startPosX -= lengthX;
        }

        if (tempY > startPosY + lengthY)
        {
            startPosY -= lengthY;
        }
        else if (tempY < startPosY - lengthY)
        {
            startPosY += lengthY;
        }
    }
}
