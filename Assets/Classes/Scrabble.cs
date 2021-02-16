using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Scrabble : MonoBehaviour
    {
        static boardSpace[,] boardSpaces = new boardSpace[15, 15];

        static void populateBoard()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    boardSpaces[i, j] = new boardSpace();
                }
            }

            //test implementation which puts [t][e][s][t] in the top left of the board game and scores with easy to follow values
            //passed each type of modifier to verify scoring works
            boardSpaces[0, 0] = new boardSpace(new tile(10, "t"), "2W", false, 0, 0);
            boardSpaces[0, 1] = new boardSpace(new tile(9, "e"), "3W", false, 0, 1);
            boardSpaces[0, 2] = new boardSpace(new tile(8, "s"), "2L", false, 0, 2);
            boardSpaces[0, 3] = new boardSpace(new tile(7, "t"), "3L", false, 0, 3);
        }


        //checkListForMatch - pass a space and check a list of spaces for that passed space, even if the list is null
        //parameters -
        //space: current space the algorithm is looking at
        //spaceList: list to search in (usually list of boardSpaces whose totals have been accounted for already)
        //returns - t/f depending on if the item was found
        static bool checkListForMatch(boardSpace space, List<boardSpace> spaceList)
        {
            if (spaceList != null)
            {
                return spaceList.Contains(space);
            }

            return false;
        }

        //calculateScore - pass the list of the spaces which the player placed tiles on (assumes tiles and adjacent tiles are correct in spelling) and calculates total
        //parameters -
        //spacesPlayed: list of boardSpace objects to let the algorithm know which spaces got played this turn
        //returns: an integer totaling the spaces played, as well as all the confirmed viable tiles up, down, left and right of each of those spaces played
        static int calculateScore(List<boardSpace> spacesPlayed)
        {
            int total = 0;
            string modifiers = "";
            List<boardSpace> spacesAdded = null;

            foreach (boardSpace space in spacesPlayed)
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
                if (space.getX() != 0 && boardSpaces[space.getX() - 1, space.getY()].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (xIndex != 0 && boardSpaces[xIndex - 1, yIndex].checkEmpty() == false && !checkListForMatch(boardSpaces[xIndex - 1, yIndex], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(boardSpaces[xIndex - 1, yIndex]))
                        {
                            total += boardSpaces[xIndex - 1, yIndex].getTile().getVal();
                            spacesAdded.Add(boardSpaces[xIndex - 1, yIndex]);
                        }
                        else
                        {
                            break;
                        }

                        xIndex--;
                    }
                }
                //Check Below Space
                if (space.getX() != 15 && boardSpaces[space.getX() + 1, space.getY()].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (xIndex != 15 && boardSpaces[xIndex + 1, yIndex].checkEmpty() == false && !checkListForMatch(boardSpaces[xIndex + 1, yIndex], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(boardSpaces[xIndex + 1, yIndex]))
                        {
                            total += boardSpaces[xIndex + 1, yIndex].getTile().getVal();
                            spacesAdded.Add(boardSpaces[xIndex + 1, yIndex]);
                        }
                        else
                        {
                            break;
                        }

                        xIndex++;
                    }
                }
                //Check Left of Space 
                if (space.getY() != 0 && boardSpaces[space.getX(), space.getY() - 1].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();

                    while (yIndex != 0 && boardSpaces[xIndex, yIndex - 1].checkEmpty() == false && !checkListForMatch(boardSpaces[xIndex, yIndex - 1], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(boardSpaces[xIndex, yIndex - 1]))
                        {
                            total += boardSpaces[xIndex, yIndex - 1].getTile().getVal();
                            spacesAdded.Add(boardSpaces[xIndex, yIndex - 1]);
                        }
                        else
                        {
                            break;
                        }

                        yIndex--;
                    }
                }
                //Check Right of Space
                if (space.getY() != 15 && boardSpaces[space.getX(), space.getY() + 1].checkEmpty() == false)
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    while (yIndex != 15 && boardSpaces[xIndex, yIndex + 1].checkEmpty() == false && !checkListForMatch(boardSpaces[xIndex, yIndex + 1], spacesAdded))
                    {
                        if (!spacesPlayed.Contains(boardSpaces[xIndex, yIndex + 1]))
                        {
                            total += boardSpaces[xIndex, yIndex + 1].getTile().getVal();
                            spacesAdded.Add(boardSpaces[xIndex, yIndex + 1]);
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

        //TODO:Determine if we need to explicitly type this main method, or if unity generates one for us.

        //static void Main(string[] args)
        //{
        //    populateBoard();

        //    //Create list with the aforementioned [t][e][s][t] boardSpaces
        //    List<boardSpace> testList = new List<boardSpace>();
        //    testList.Add(boardSpaces[0, 0]);
        //    testList.Add(boardSpaces[0, 1]);
        //    testList.Add(boardSpaces[0, 2]);
        //    testList.Add(boardSpaces[0, 3]);

        //    //Write total to console
        //    Console.WriteLine(calculateScore(testList));
        //    Console.Read();
        //}

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

