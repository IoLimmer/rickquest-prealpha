using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector3 playerOrigin;
    private Transform playerPoint;

    [SerializeField] private List<GameObject> followers;
    enum FollowerOriginDirection
    {
        Behind_player,
        In_front_of_player,
        Left_of_player,
        Right_of_player
    };

    [SerializeField] private FollowerOriginDirection followerOriginDirection;

    [SerializeField] public List<Vector3> followerTargets;

    void InitFollowerPositions()
    {
        followerTargets.Add(playerOrigin);

        // spawn followers relative to player position. i.e. in certain direction one unit over each time

        for (int i = 1; i < followers.Count + 1; i++)
        {
            switch (followerOriginDirection)
            {
                // spawn followers behind player
                case FollowerOriginDirection.Behind_player:
                    followerTargets.Add(playerOrigin + new Vector3(0f, 1f, 0f) * i);
                    break;

                // spawn followers in front of player
                case FollowerOriginDirection.In_front_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(0f, -1f, 0f) * i);
                    break;

                // spawn followers to the left of the player
                case FollowerOriginDirection.Left_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(-1f, 0f, 0f) * i);
                    break;

                // spawn followers to the right of the player
                case FollowerOriginDirection.Right_of_player:
                    followerTargets.Add(playerOrigin + new Vector3(1f, 0f, 0f) * i);
                    break;

                default:
                    Debug.LogError("Follower spawn location not defined");
                    break;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        // get initial player position
        playerOrigin = player.transform.position;

        // get player pointer
        playerPoint = player.GetComponent<PlayerControllerGRID>().movePoint;

        // spawn however many followers we want
        InitFollowerPositions();
        for (int i = 0; i < followers.Count; i++) { 
            followers[i].transform.position = followerTargets[i+1];
        }
    }

    List<Vector3> UpdateFollowerTargets(List<Vector3> oldFollowerTargets)
    {
        List<Vector3> newFollowerTargets = new List<Vector3>();

        newFollowerTargets.Add(playerPoint.position);
        for (int i = 0; i < oldFollowerTargets.Count - 1; i++)
        {
            newFollowerTargets.Add(oldFollowerTargets[i]);
        }
        return newFollowerTargets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerPoint.position, followerTargets[0]) >= .95f)
        {
            followerTargets = UpdateFollowerTargets(followerTargets);
        }
    }
}
