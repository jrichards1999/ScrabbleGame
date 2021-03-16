using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace {
    public class Player : Scrabble
    {
        public string Name;
        public int TotalPoints;
        public ArrayList TileList;
        public List<Tile> TempList;
        public List<Tile> PlayedTileList;

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

        public void updateList(int index)
        {
            PlayedTileList.Add(TempList[index]);
            TileList.RemoveAt(index);
        }

        public void playerTurn()
        {
            bool done = false;

            while (!done)
            {
                if (TileList.Count == 0)
                {
                    done = true;
                }

                //var index = placeTile() - TODO method to place tile, and return index of TileList from which the tile was taken
                //updateList(index);

            }
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

}

