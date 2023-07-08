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

    private Vector3 startPos = Vector3.zero;
    private int XPlayerMove => (int)(_player.transform.position.x - startPos.x);
    private int XPlayerLocation => (int)Mathf.Floor(_player.transform.position.x / planeOffset) * planeOffset;

    private int ZPlayerMove => (int)(_player.transform.position.z - startPos.z);
    private int ZPlayerLocation => (int)Mathf.Floor(_player.transform.position.z / planeOffset) * planeOffset;

    private Hashtable tilePlane = new Hashtable();

    void Start()
    {
        // identify player object using Player tag
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        GenerateWorld();
    }

    private void GenerateWorld()
    {
        if (startPos == Vector3.zero)
        {
            for (int x = -radius; x < radius - 1; x++)
            {
                for (int z = -radius; z < radius - 1; z++)
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

        if (hasPlayerMoved(XPlayerMove, ZPlayerMove))
        {
            for (int x = -radius; x < radius; x++)
            {
                for (int z = -radius; z < radius; z++)
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
    }

    private bool hasPlayerMoved(int playerX, int playerZ)
    {
        if (Mathf.Abs(XPlayerMove) >= planeOffset || Mathf.Abs(ZPlayerMove) >= planeOffset)
        {
            return true;
        }
        return false;
    }
}
