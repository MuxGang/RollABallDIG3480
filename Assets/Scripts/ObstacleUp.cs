using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleUp : MonoBehaviour
{
    private bool go_up = false;
    public float bleed = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (go_up)
        {
            transform.Translate(Vector3.up * Time.deltaTime * bleed);
            if (transform.position.y > 5)
            {
                go_up = false;
            }
        }
        else
        {
            transform.Translate(-Vector3.up * Time.deltaTime * bleed);
            if (transform.position.y < -5)
            {
                go_up = true;
            }
        }
    }
}
