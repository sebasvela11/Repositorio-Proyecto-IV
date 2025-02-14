using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    public float startWaiTime;
    public float waitedTime;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp("s"))
        {
            waitedTime = startWaiTime;
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s"))
        {
            if (waitedTime <= 0)
            {
                effector.rotationalOffset = 180;
                waitedTime = startWaiTime;
            }
            else
            {
                waitedTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey("space"))
        {
            effector.rotationalOffset = 0;
        }
    }
}