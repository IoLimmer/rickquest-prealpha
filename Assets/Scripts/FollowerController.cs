using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private List<Vector3> followerTargets;
    public int positionInCaterpillar;

    // Start is called before the first frame update
    void Start()
    {
        followerTargets = gameObject.GetComponentInParent<CaterpillarManager>().followerTargets;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, followerTargets[positionInCaterpillar], moveSpeed * Time.deltaTime);

        followerTargets = gameObject.GetComponentInParent<CaterpillarManager>().followerTargets;
    }
}
