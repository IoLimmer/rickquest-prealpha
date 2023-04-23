using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGRID : MonoBehaviour
{
    public float playerSpeed = 0.2f;

    private float timeCounter = 0f;
    private Vector3 change;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 GetInput()
    {
        var curXmove = Input.GetAxisRaw("Horizontal");
        var curYmove = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(curYmove) > Mathf.Abs(curXmove)) //Give priority to x axis movement
        {
            curXmove = 0;
        }
        else
        {
            curYmove = 0;
        }

        return new Vector3(curXmove, curYmove, 0f);
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 change = GetInput();

        if (canMove) {
            transform.Translate(change);
            canMove = false;
        }

        if (timeCounter > playerSpeed)
        {
            canMove = true;
            timeCounter = 0f;
        }

        timeCounter += Time.deltaTime;
    }
}
