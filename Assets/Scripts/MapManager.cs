using UnityEngine;
using Uniblocks;

public class MapManager : MonoBehaviour
{
    private Transform playerTranas;
    // private Vector3 lastPos;
    private Index lastIndex;

    void Start()
    {
        playerTranas = GameObject.Find("Player").transform;
        InvokeRepeating("InitMap", 1.0f, 0.03f); // 防止进入场景卡死
    }

    void InitMap()
    {
        if (Engine.Initialized == false || ChunkManager.Initialized == false)
        {
            return;
        }

        /*Vector3 currentPos = playerTranas.position;
        if (lastPos != currentPos)
        {
            ChunkManager.SpawnChunks(playerTranas.position);
            lastPos = currentPos;
        }*/

        Index currentIdex = Engine.PositionToChunkIndex(playerTranas.position);
        if (lastIndex != currentIdex)
        {
            ChunkManager.SpawnChunks(playerTranas.position);
            lastIndex = currentIdex;
        }
    }
}
