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

        public boardSpace()
        {
            tile = null;
            modifier = "";
            isEmpty = true;
        }

        public boardSpace(tile tileObject, string modifierString, bool empty)
        {
            tile = tileObject;
            modifier = modifierString;
            isEmpty = empty;
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

