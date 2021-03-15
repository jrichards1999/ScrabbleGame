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
                case 'A': return 1;
                case 'B': return 3;
                case 'C': return 3;
                case 'D': return 2;
                case 'E': return 1;
                case 'F': return 4;
                case 'G': return 2;
                case 'H': return 4;
                case 'I': return 1;
                case 'J': return 8;
                case 'K': return 5;
                case 'L': return 1;
                case 'M': return 3;
                case 'N': return 1;
                case 'O': return 1;
                case 'P': return 3;
                case 'Q': return 10;
                case 'R': return 1;
                case 'S': return 1;
                case 'T': return 1;
                case 'U': return 1;
                case 'V': return 4;
                case 'W': return 4;
                case 'X': return 8;
                case 'Y': return 4;
                case 'Z': return 10;
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

        public char getLetter()
        {
            return letter;
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

