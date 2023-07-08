using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlaneGenerator : MonoBehaviour
{
    public GameObject plane;
    protected Transform _player;

    [SerializeField] private int radius;
    [SerializeField] private int planeOffset;

    private Vector3 playerPrevPos = Vector3.zero;
    private Vector3 playerDeltaMove = Vector3.zero;

    private int XPlayerLocation => (int)Mathf.Floor(_player.transform.position.x / planeOffset) * planeOffset;
    private int ZPlayerLocation => (int)Mathf.Floor(_player.transform.position.z / planeOffset) * planeOffset;

    private Hashtable tilePlane = new Hashtable();

    private bool started;

    void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindWithTag("Player").transform;
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        playerDeltaMove.x = _player.transform.position.x - playerPrevPos.x;
        playerDeltaMove.z = _player.transform.position.z - playerPrevPos.z;

        if (started)
        {
            for (int x = -radius; x <= radius; ++x)
            {
                for (int z = -radius; z <= radius; ++z)
                {
                    Vector3 pos = new Vector3((x * planeOffset + XPlayerLocation), 0, (z * planeOffset + ZPlayerLocation));

                    if (!tilePlane.Contains(pos))
                    {
                        GameObject tile = Instantiate(plane, pos, Quaternion.identity, gameObject.transform);
                        tilePlane.Add(pos, tile);
                    }
                }
            }
            started = false;
        }

        if (hasPlayerMoved(_player.transform.position.x, _player.transform.position.z))
        {
            for (int x = -radius; x <= radius; x++)
            {
                for (int z = -radius; z <= radius; z++)
                {
                    Vector3 pos = new Vector3((x * planeOffset + XPlayerLocation), 0, (z * planeOffset + ZPlayerLocation));

                    if (!tilePlane.Contains(pos))
                    {
                        GameObject tile = Instantiate(plane, pos, Quaternion.identity, gameObject.transform);
                        tilePlane.Add(pos, tile);
                    }
                }
            }
        }

        playerPrevPos.x = _player.transform.position.x;
        playerPrevPos.z = _player.transform.position.z;
    }

    private bool hasPlayerMoved(float playerX, float playerZ)
    {
        if (Mathf.Abs(playerX) >= planeOffset || Mathf.Abs(playerZ) >= planeOffset)
        {
            return true;
        }
        return false;
    }
}
