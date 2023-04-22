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

    // Update is called once per frame
    void Update()
    {
        Vector3 change = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

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
        Debug.Log(timeCounter);
    }
}
