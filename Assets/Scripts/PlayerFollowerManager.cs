using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject followerPrefab;
    [SerializeField] private Vector3 playerOrigin;
    enum FollowerOriginDirection
    {
        Behind_player,
        In_front_of_player,
        Left_of_player,
        Right_of_player
    };

    [SerializeField] private FollowerOriginDirection followerOriginDirection;

    [SerializeField] private int followerCount = 1;
    [SerializeField] public List<Vector3> followerTargets;

    void InitFollowerPositions()
    {
        switch (followerOriginDirection)
        {
            case FollowerOriginDirection.Behind_player:
                followerTargets.Add(playerOrigin + new Vector3(0f, 1f, 0f));
                break;

            case FollowerOriginDirection.In_front_of_player:
                followerTargets.Add(playerOrigin + new Vector3(0f, -1f, 0f));
                break;

            case FollowerOriginDirection.Left_of_player:
                followerTargets.Add(playerOrigin + new Vector3(-1f, 0f, 0f));
                break;

            case FollowerOriginDirection.Right_of_player:
                followerTargets.Add(playerOrigin + new Vector3(1f, 0f, 0f));
                break;

            default:
                Debug.LogError("Follower spawn location not defined!");
                break;            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerOrigin += new Vector3(0.5f, 0.5f, 0f);
        // player origin is written in by dev as 3 whole numbers. arbitrary adjustments to real grid position are added by code above
        // (it just seemed nicer that way)
        InitFollowerPositions();

        GameObject.Instantiate(playerPrefab, playerOrigin, new Quaternion());
        GameObject.Instantiate(followerPrefab, followerTargets[0], new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
