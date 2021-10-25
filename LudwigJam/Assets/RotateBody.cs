using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public PointEffector2D pe;
    public bool isForceVariable = true;
    public bool rotate = true;
    float forceMag;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
        forceMag = pe.forceMagnitude;
        StartCoroutine(SetRotationSpeed(-2f,2f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        var forceMod = Random.Range(1f,5f);
        var fVar = Mathf.Acos(transform.localRotation.z);
        if (isForceVariable)
        {
            pe.forceVariation = fVar * forceMod;
        }
        else 
        {
            pe.forceVariation = 0f;
        }
        if (rotate)
        {
            transform.Rotate(new Vector3(0, 0, rotateSpeed));
        }

    }

    IEnumerator SetRotationSpeed(float minRot = 1, float maxRot = 2)
    {
        yield return new WaitForSeconds(Random.Range(2,5));
        rotateSpeed = Random.Range(minRot, maxRot);
    }
}
