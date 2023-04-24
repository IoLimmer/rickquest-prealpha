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
        // spawn followers relative to player position. i.e. in certain director one unit over each time

        for (int i = 1; i < followerCount+1; i++)
        {
            switch (followerOriginDirection)
            {

                case FollowerOriginDirection.Behind_player:
                    followerTargets.Add(playerOrigin + new Vector3(0f, 1f, 0f) * i);
                    break;

                case FollowerOriginDirection.In_front_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(0f, -1f, 0f) * i);
                    break;

                case FollowerOriginDirection.Left_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(-1f, 0f, 0f) * i);
                    break;

                case FollowerOriginDirection.Right_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(1f, 0f, 0f) * i);
                    break;

                default:
                    Debug.LogError("Follower spawn location not defined!");
                    break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // player origin is written in by dev as 3 whole numbers. arbitrary adjustments to real grid position are added by code below
        // (it just seemed nicer that way)
        playerOrigin += new Vector3(0.5f, 0.5f, 0f);

        InitFollowerPositions();

        GameObject.Instantiate(playerPrefab, playerOrigin, new Quaternion());

        // now spawn however many followers we want
        for (int i = 0; i < followerCount; i++){ 
            GameObject.Instantiate(followerPrefab, followerTargets[i], new Quaternion());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
