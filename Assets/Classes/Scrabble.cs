using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Scrabble : MonoBehaviour
    {
        Player p1 = new Player();
        Player p2 = new Player();
        public List<Tile> TilePile;

        // Start is called before the first frame update
        void Start()
        {
            TilePile = initializeTilePile();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<Tile> initializeTilePile()
        {
            List<Tile> tilePile = new List<Tile>();
            for(char tileLetter = 'A'; tileLetter < 'Z'; tileLetter++)
            {
                var numOfTile = GetNumOfTile(tileLetter);
                for(int i = 0; i < numOfTile; i++)
                {
                    tilePile.Add(new Tile(tileLetter));
                }
            }

            for(int i = 0; i < 2; i++)
            {
                tilePile.Add(new Tile(' ', true));
            }

            tilePile = Shuffle(tilePile); //Need to test this shuffle function with debugger.

            return tilePile;
        }

        int GetNumOfTile(char c)
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

        public Tile drawTile()
        {
            if(TilePile.Count > 0)
            {
                var toRtn = TilePile[0];
                TilePile.RemoveAt(0);
                return toRtn;
            }
            else
            {
                return null;
            }
        }

        public List<Tile> Shuffle(List<Tile> list)
        {
            System.Random rng = new System.Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Tile value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

    }


}

