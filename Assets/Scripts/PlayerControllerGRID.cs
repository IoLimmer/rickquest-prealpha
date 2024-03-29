using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGRID : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint = gameObject.transform.GetChild(0).transform;
        movePoint.parent = null; //give it freedom baby
    }

    void GetInput()
    {
        var xInput = Input.GetAxisRaw("Horizontal");
        var yInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(xInput) > Mathf.Abs(yInput)) // only one axis at a time, gives priority to y axis
        {
            yInput = 0;
        }
        else
        {
            xInput = 0;
        }

        movePoint.position += new Vector3(xInput, yInput, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            GetInput();
        }
        Debug.Log(movePoint.position - new Vector3(-0.5f, -0.5f, 0f));
    }
}
