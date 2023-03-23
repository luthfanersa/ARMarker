using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEffect : MonoBehaviour
{   
   
    public Color startColor = Color.black;
    public Color endColor = Color.white;
    [Range(0, 10)]
    public float speed = 1;
    private int x;
    Renderer ren;

    void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        ren.material.color = 
            Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }

    private void Start()
    {
        x = 0;
    }
    public void ChangeColorButton()
    {
        if (x < 3)
        {
            if (x == 1)
            {
                startColor = Color.red;
            }
            else if (x == 2)
            {
                startColor = Color.green;
            }
            else
            {
                startColor = Color.yellow;
            }
            x++;

        }
        else
        {
            startColor = Color.black;
            x = 0;

        }

      
    }
}
