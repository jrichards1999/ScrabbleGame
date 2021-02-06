using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Board : MonoBehaviour
    {
        BoardSpace[,] boardSpaces = new BoardSpace[15,15];

        BoardSpace[,] previousBoardState = new BoardSpace[15,15];

        /// <summary>
        /// Will create a board that contains tiles quickly for testing purposes.
        /// </summary>
        void CreateSampleBoard()
        {
            throw new Exception("Todo");
        }

        void PlaceTile(char c, int x, int y)
        {
            boardSpaces[x, y].SetTile(new Tile(c));
        }

        // Start is called before the first frame update
        void Start()
        {
            for(int x = 0; x < 15; x++)
            {
                for(int y = 0; y < 15; y++)
                {
                    boardSpaces[x, y] = new BoardSpace();
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
