using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Tile : MonoBehaviour
    {
        private int pointVal;
        private char letter;

        int GetPointValue(char c)
        {
            switch (c)
            {
                case 'A': return 9;
                case 'B': return 2;
                case 'C': return 2;
                case 'D': return 4;
                case 'E': return 12;
                case 'F': return 2;
                case 'G': return 3;
                case 'H': return 2;
                case 'I': return 9;
                case 'J': return 1;
                case 'K': return 1;
                case 'L': return 4;
                case 'M': return 2;
                case 'N': return 6;
                case 'O': return 8;
                case 'P': return 2;
                case 'Q': return 1;
                case 'R': return 6;
                case 'S': return 4;
                case 'T': return 6;
                case 'U': return 4;
                case 'V': return 2;
                case 'W': return 2;
                case 'X': return 1;
                case 'Y': return 2;
                case 'Z': return 1;
                default: return 0;
            }
        }

        public Tile(char character, bool blank = false)
        {
            if (!blank)
                pointVal = GetPointValue(character);
            else
                pointVal = 0;
            letter = character;
        }

        public int getVal()
        {
            return pointVal;
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

