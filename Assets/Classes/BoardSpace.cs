using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class BoardSpace
    {
        private Tile tile;
        private string modifier;
        public bool IsEmpty = true;
        private int boardLocationX;
        private int boardLocationY;

        public BoardSpace()
        {
            tile = null;
            modifier = "";
            IsEmpty = true;
            boardLocationX = 0;
            boardLocationY = 0;
        }

        public BoardSpace(Tile tileObject, string modifierString, bool empty, int locationX, int locationY)
        {
            tile = tileObject;
            modifier = modifierString;
            IsEmpty = empty;
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
            return IsEmpty;
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
            this.IsEmpty = false;
        }

        public void Clear()
        {
            this.tile = null;
            this.IsEmpty = true;
        }
    }
}

