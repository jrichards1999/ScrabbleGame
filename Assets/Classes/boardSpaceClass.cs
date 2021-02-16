using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class boardSpace : MonoBehaviour
    {
        private tile tile;
        private string modifier;
        private bool isEmpty;
        private int boardLocationX;
        private int boardLocationY;

        public boardSpace()
        {
            tile = null;
            modifier = "";
            isEmpty = true;
            boardLocationX = 0;
            boardLocationY = 0;
        }

        public boardSpace(tile tileObject, string modifierString, bool empty, int locationX, int locationY)
        {
            tile = tileObject;
            modifier = modifierString;
            isEmpty = empty;
            boardLocationX = locationX;
            boardLocationY = locationY;
        }

        public tile getTile()
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

