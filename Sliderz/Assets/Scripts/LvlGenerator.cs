using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LvlGenerator : MonoBehaviour
{
    public Tilemap tm;
    public Tile tile;
    private Vector3Int previous;
    Vector3Int currentCell;

    public int bottomY = -1;
    public float difficultyScaler = 2f;
    public float difficultyThreshold = 20000f;
    private float difficulty = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get current grid location
        currentCell = tm.WorldToCell(transform.position);
        // add one in a direction (you'll have to change this to match your directional control)
        currentCell.x += 20;
        currentCell.y = bottomY;

        // if the position has changed
        if (currentCell != previous)
        {
            // set the new tile
            tm.SetTile(currentCell, tile);

            // erase previous


            // save the new position for next frame
            previous = currentCell;
        }
    }

    void LoadObstacle()
    {
        Debug.Log("Obs");
    }

    void ChooseObstacle()
    {

    }
}
