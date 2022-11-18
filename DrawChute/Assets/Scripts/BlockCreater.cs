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
    
    //Gap between blocks
    public float gap;
    public float scale;
    public float distance;
    public List<GameObject> blockList = new List<GameObject>();
    
    public GameObject blockPrefab;

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //Clear blockList and mousePath every time player start the game
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
            mousePos.z = scale;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            mousePath.Add(mousePos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            createdPath = PathCreator.Path(gap, mousePath);

            for (int i = 0; i < createdPath.Count; i++)
            {
                GameObject block = Instantiate(blockPrefab, new Vector3(createdPath[i].x, createdPath[i].y, distance), Quaternion.identity) as GameObject;
                blockList.Add(block);
            }
            
        }

    }

    
    
}
