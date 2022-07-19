using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 0f;
    private bool go_right = false;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      

        if (go_right)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > 5)
            {
                go_right = false;
            }
        }
        else
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
            if (transform.position.x < -5)
            {
                go_right = true;
            }
        }
    }
}
