using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLerp : MonoBehaviour
{
    [SerializeField] private Vector3 parentPositionOld;
    [SerializeField] private Vector3 parentPositionNew;
    [SerializeField] private Vector3 lerpPosition;
    [SerializeField] private float lerpSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        parentPositionOld = gameObject.transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        parentPositionNew = gameObject.transform.parent.position;

        if (parentPositionNew != parentPositionOld)
        {
            Debug.Log("banana");
            lerpPosition = Vector3.Lerp(parentPositionOld, parentPositionNew, lerpSpeed);
            gameObject.transform.position = lerpPosition;
        }
        //parentPositionOld = gameObject.transform.parent.position + new Vector3(3f,3f,0f);

        //gameObject.transform.position = parentPositionOld;
    }
}
