using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public Material[] materials;

    // Start is called before the first frame update
    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Init()
    {
        var rand = Random.Range(0,3);
        var randScale = Random.Range(1f,2f);
        spriteRenderer.sprite = sprites[rand];
        switch (rand)
        {
            case 0:
                spriteRenderer.material = materials[0];
                break;
            case 1:
                spriteRenderer.material = materials[1];
                break;
            case 2:
                spriteRenderer.material = materials[2];
                break;
        }
        this.gameObject.transform.localScale *= randScale;
    }
}
