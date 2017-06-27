using UnityEngine;
using Uniblocks;

public class BlockManager : MonoBehaviour
{
    public int range = 10;

    private ushort blockId = 0;
    private Transform selectBlockEffect;

    void Start()
    {
        selectBlockEffect = GameObject.Find("selected block graphics").transform;
        selectBlockEffect.gameObject.SetActive(false);
    }

    void Update()
    {
        SelectBolckId();

        // origin direction range ingoreTransparent 
        VoxelInfo info = Engine.VoxelRaycast(Camera.main.transform.position, Camera.main.transform.forward, range, false);
        if (info != null)
        {
            // 左键销毁
            if (Input.GetMouseButtonDown(0))
            {
                Voxel.DestroyBlock(info);
            }
            // 中键摆放
            if (Input.GetMouseButtonDown(1))
            {
                VoxelInfo newInfo = new VoxelInfo(info.adjacentIndex, info.chunk);
                Voxel.PlaceBlock(newInfo, blockId);
            }
        }

        UpdateSelectBolckEffect(info);
    }

    void SelectBolckId()
    {
        for (ushort i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                blockId = i;
            }
        }
    }

    void UpdateSelectBolckEffect(VoxelInfo info)
    {
        if (info != null)
        {
            selectBlockEffect.gameObject.SetActive(true);
            selectBlockEffect.position = info.chunk.VoxelIndexToPosition(info.index);
        }
        else
        {
            selectBlockEffect.gameObject.SetActive(false);
        }
    }
}
