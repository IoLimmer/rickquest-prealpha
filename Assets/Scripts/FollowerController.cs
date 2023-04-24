using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public GameObject caterpillarManager;

    public float moveSpeed = 5f;

    public List<Vector3> followerTargets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followerTargets = caterpillarManager.GetComponent<CaterpillarManager>().followerTargets;
        //transform.position = Vector3.MoveTowards(transform.position, positionInWorld, moveSpeed * Time.deltaTime);
    }
}
