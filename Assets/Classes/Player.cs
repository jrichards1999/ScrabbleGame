using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name;
    public int TotalPoints;
    public ArrayList TileList;

    public Player()
    {
        Name = "Player";
        TotalPoints = 0;
        //TODO - Initialize a set of random tiles for the player once the tile class is finalized.
    }

    public Player(string name)
    {
        Name = name;
        TotalPoints = 0;
        //TODO - Initialize a set of random tiles for the player once the tile class is finalized.
    }

    public void updateTotalPoints(int points)
    {
        TotalPoints += points;
    }

    public int getPoints()
    {
        return TotalPoints;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
