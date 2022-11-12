using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BlockCreater : MonoBehaviour
{
    [Header("Paths")]
    public List<Vector2> mousePath = new List<Vector2>();
    public List<Vector2> createdPath = new List<Vector2>();

    public float gap = .5f;
    public List<GameObject> blockList = new List<GameObject>();
    
    public GameObject blockPrefab;

    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            if (blockList.Count != 0)
            {
                for (int i = 0; i < blockList.Count; i++)
                {
                    GameObject block = blockList[i];
                    Destroy(block);
                }
                
                blockList.Clear();
                mousePath.Clear();
            }
            
            var mousePos = Input.mousePosition;
            //Distance of units from the camera
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePath.Add(mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            createdPath = PathCreator.Path(gap, mousePath);

            for (int i = 0; i < createdPath.Count; i++)
            {
                GameObject block = Instantiate(blockPrefab, createdPath[i], Quaternion.identity) as GameObject;
                blockList.Add(block);
            }
            
        }

    }

    
    
}
