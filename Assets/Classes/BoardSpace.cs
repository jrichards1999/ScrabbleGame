using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class BoardSpace : MonoBehaviour
    {
        private Tile tile;
        private string modifier;
        private bool isEmpty;

        public BoardSpace()
        {
            tile = null;
            modifier = "";
            isEmpty = true;
        }

        public BoardSpace(Tile tileObject, string modifierString, bool empty)
        {
            tile = tileObject;
            modifier = modifierString;
            isEmpty = empty;
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

