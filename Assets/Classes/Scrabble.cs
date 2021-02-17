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
        public List<Tile> tilePile;

        static BoardSpace[,] BoardSpaces = new BoardSpace[15, 15];

        static void populateBoard()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    BoardSpaces[i, j] = new BoardSpace();
                }
            }

            //test implementation which puts [t][e][s][t] in the top left of the board game and scores with easy to follow values
            //passed each type of modifier to verify scoring works
            BoardSpaces[0, 0] = new BoardSpace(new Tile('T', false), "2W", false, 0, 0);
            BoardSpaces[0, 1] = new BoardSpace(new Tile('E', false), "3W", false, 0, 1);
            BoardSpaces[0, 2] = new BoardSpace(new Tile('S', false), "2L", false, 0, 2);
            BoardSpaces[0, 3] = new BoardSpace(new Tile('T', false), "3L", false, 0, 3);
        }


        //checkListForMatch - pass a space and check a list of spaces for that passed space, even if the list is null
        //parameters -
        //space: current space the algorithm is looking at
        //spaceList: list to search in (usually list of BoardSpaces whose totals have been accounted for already)
        //returns - t/f depending on if the item was found
        static bool checkListForMatch(BoardSpace space, List<BoardSpace> spaceList)
        {
            if (spaceList != null)
            {
                return spaceList.Contains(space);
            }

            return false;
        }

        //calculateScore - pass the list of the spaces which the player placed Tiles on (assumes Tiles and adjacent Tiles are correct in spelling) and calculates total
        //parameters -
        //spacesPlayed: list of BoardSpace objects to let the algorithm know which spaces got played this turn
        //returns: an integer totaling the spaces played, as well as all the confirmed viable Tiles up, down, left and right of each of those spaces played
        static int calculateScore(List<BoardSpace> spacesPlayed)
        {
            int total = 0;
            string modifiers = "";
            List<BoardSpace> spacesAdded = null;

            foreach (BoardSpace space in spacesPlayed)
            {
                //Check if the space played has double or triple letter modifier - add that to the total
                //Else add the unmodified value to the total
                if (space.getMod() == "2L")
                {
                    total += space.getTile().getVal() * 2;
                }
                else if (space.getMod() == "3L")
                {
                    total += space.getTile().getVal() * 3;
                }
                else
                {
                    total += space.getTile().getVal();
                }

                //Add all modifiers, although this string will only be checked later for double or triple word
                modifiers += space.getMod();

                //Check Above Current Tile
                if (space.getX() != 0 && BoardSpaces[space.getX() - 1, space.getY()].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (xIndex != 0 && BoardSpaces[xIndex - 1, yIndex].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex - 1, yIndex], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(BoardSpaces[xIndex - 1, yIndex]))
                        {
                            total += BoardSpaces[xIndex - 1, yIndex].getTile().getVal();
                            spacesAdded.Add(BoardSpaces[xIndex - 1, yIndex]);
                        }
                        else
                        {
                            break;
                        }

                        xIndex--;
                    }
                }
                //Check Below Space
                if (space.getX() != 15 && BoardSpaces[space.getX() + 1, space.getY()].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (xIndex != 15 && BoardSpaces[xIndex + 1, yIndex].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex + 1, yIndex], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(BoardSpaces[xIndex + 1, yIndex]))
                        {
                            total += BoardSpaces[xIndex + 1, yIndex].getTile().getVal();
                            spacesAdded.Add(BoardSpaces[xIndex + 1, yIndex]);
                        }
                        else
                        {
                            break;
                        }

                        xIndex++;
                    }
                }
                //Check Left of Space 
                if (space.getY() != 0 && BoardSpaces[space.getX(), space.getY() - 1].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (yIndex != 0 && BoardSpaces[xIndex, yIndex - 1].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex, yIndex - 1], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(BoardSpaces[xIndex, yIndex - 1]))
                        {
                            total += BoardSpaces[xIndex, yIndex - 1].getTile().getVal();
                            spacesAdded.Add(BoardSpaces[xIndex, yIndex - 1]);
                        }
                        else
                        {
                            break;
                        }

                        yIndex--;
                    }
                }
                //Check Right of Space
                if (space.getY() != 15 && BoardSpaces[space.getX(), space.getY() + 1].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    while (yIndex != 15 && BoardSpaces[xIndex, yIndex + 1].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex, yIndex + 1], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(BoardSpaces[xIndex, yIndex + 1]))
                        {
                            total += BoardSpaces[xIndex, yIndex + 1].getTile().getVal();
                            spacesAdded.Add(BoardSpaces[xIndex, yIndex + 1]);
                        }
                        else
                        {
                            break;
                        }

                        yIndex++;
                    }
                }
            }

            //Add all multiplicative modifiers to total and return
            if (modifiers.Contains("2W"))
            {
                total = total * 2;
            }
            if (modifiers.Contains("3W"))
            {
                total = total * 3;
            }

            return total;

        }

        static void Main(string[] args)
        {
            populateBoard();

            //Create list with the aforementioned [t][e][s][t] BoardSpaces
            List<BoardSpace> testList = new List<BoardSpace>();
            testList.Add(BoardSpaces[0, 0]);
            testList.Add(BoardSpaces[0, 1]);
            testList.Add(BoardSpaces[0, 2]);
            testList.Add(BoardSpaces[0, 3]);

            //Write total to console
            Console.WriteLine(calculateScore(testList));
            Console.Read();
        }

        // Start is called before the first frame update
        void Start()
        {
            tilePile = initializeTilePile();
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
            if(tilePile.Count > 0)
            {
                var toRtn = tilePile[0];
                tilePile.RemoveAt(0);
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

