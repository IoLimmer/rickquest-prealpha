using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicLerp : MonoBehaviour
{
    [SerializeField] private Vector3 childPositionOld;
    [SerializeField] private Vector3 childPositionNew;
    [SerializeField] private GameObject childObject;

    [SerializeField] private Vector3 lerpPosition;
    [SerializeField] private float lerpDuration = 0.5f;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        //childPositionOld = gameObject.transform.parent.position;
        childObject = gameObject.transform.GetChild(0).gameObject;
        childPositionOld = childObject.transform.position;
    }

    IEnumerator LerpPosition(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = childPositionOld;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition ;
    }

    // Update is called once per frame
    void Update()
    {
        childPositionNew = childObject.transform.position;

        if (childPositionNew != childPositionOld)
        {
            Debug.Log("banana");
            StartCoroutine(LerpPosition(childPositionNew));

            //https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
        }
        //parentPositionOld = gameObject.transform.parent.position + new Vector3(3f,3f,0f);

        //gameObject.transform.position = parentPositionOld;
    }
}
