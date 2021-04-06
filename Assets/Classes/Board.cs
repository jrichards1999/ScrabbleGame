using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public static class Board
    {
        //public static Board board = null;

        static BoardSpace[,] boardSpaces = new BoardSpace[15,15];

        static BoardSpace[,] previousBoardState = new BoardSpace[15,15];

        /// <summary>
        /// Will create a board that contains tiles quickly for testing purposes.
        /// </summary>
        static void CreateSampleBoard()
        {
            throw new Exception("Todo");
        }

        static public bool RemoveTile(Tile tile)
        {
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    if(tile == boardSpaces[x,y].getTile())
                    {
                        boardSpaces[x, y] = new BoardSpace();
                        return true;
                    }
                }
            }
            return false;
        }

        static public bool PlaceTile(Tile tile, int x, int y)
        {
            if(boardSpaces[x, y].IsEmpty)
            {
                boardSpaces[x, y].SetTile(tile);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Start is called before the first frame update
        public static void Start()
        {
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    boardSpaces[x, y] = new BoardSpace();
                }
            }
        }

    }
}
