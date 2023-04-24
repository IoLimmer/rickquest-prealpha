using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 playerOrigin;
    enum FollowerOriginDirection
    {
        Behind_player,
        In_front_of_player,
        Left_of_player,
        Right_of_player
    };

    [SerializeField] private FollowerOriginDirection followerOriginDirection;

    [SerializeField] private int followerCount = 3;
    [SerializeField] public List<Vector3> followerTargets;

    // Start is called before the first frame update
    void Start()
    {
        playerOrigin += new Vector3(0.5f, 0.5f, 0f);
        // player origin is written in by dev as 3 whole numbers. arbitrary adjustments to real grid position are added by code above
        // (it just seemed nicer that way)

        GameObject.Instantiate(playerPrefab, playerOrigin, new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
