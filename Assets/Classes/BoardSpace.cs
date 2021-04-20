using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace ScrabbleNamespace
{
    public class BoardSpace : MonoBehaviour
    {
        private Tile tile;
        private string modifier;
        private bool isEmpty;
        private int boardLocationX;
        private int boardLocationY;

        public BoardSpace()
        {
            tile = null;
            modifier = "";
            isEmpty = true;
            boardLocationX = 0;
            boardLocationY = 0;
        }

        public BoardSpace(Tile tileObject, string modifierString, bool empty, int locationX, int locationY)
        {
            tile = tileObject;
            modifier = modifierString;
            isEmpty = empty;
            boardLocationX = locationX;
            boardLocationY = locationY;
        }

        public Tile getTile()
        {
            return tile;
        }

        public string getMod()
        {
            return modifier;
        }

        public bool checkEmpty()
        {
            return isEmpty;
        }

        public int getX()
        {
            return boardLocationX;
        }

        public int getY()
        {
            return boardLocationY;
        }

        public void SetTile(Tile tile)
        {
            this.tile = tile;
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

