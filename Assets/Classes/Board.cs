﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScrabbleNamespace
{
    public static class Board
    {
        //public static Board board = null;

        public static BoardSpace[,] boardSpaces = new BoardSpace[15, 15];

        static BoardSpace[,] lockedBoardSpaces = new BoardSpace[15, 15];

        public static List<BoardSpace> spacesPlayed = new List<BoardSpace>();

        /// <summary>
        /// Will create a board that contains tiles quickly for testing purposes.
        /// </summary>
        static void CreateSampleBoard()
        {
            throw new Exception("Todo");
        }

        static public bool RemoveTile(Tile tile)
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    
                    
                    if (!boardSpaces[x,y].IsEmpty && tile == boardSpaces[x, y].getTile())
                    {
                        boardSpaces[x, y].Clear();
                        spacesPlayed.Remove(boardSpaces[x, y]);
                        return true;
                    }
                }
            }
            return false;
        }

        static public bool PlaceTile(Tile tile, int x, int y)
        {
            if (boardSpaces[x, y].IsEmpty)
            {
                boardSpaces[x, y].SetTile(tile);
                spacesPlayed.Add(boardSpaces[x, y]);
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool SubmitTiles()
        {
            bool validTurn = Scrabble.validTurn(spacesPlayed);

            //If the turn is valid, remove the specific tiles played from the correct users list of tiles.
            
            if (validTurn)
            {
                int score = Scrabble.calculateScore(spacesPlayed);

                for (int x = 0; x < 15; x++)
                {
                    for (int y = 0; y < 15; y++)
                    {
                        if(!boardSpaces[x,y].IsEmpty)
                        {
                            boardSpaces[x, y].getTile().Lock();
                            lockedBoardSpaces[x, y] = boardSpaces[x, y];
                        }
                    }
                }

                if(Scrabble.PlayerTurn == "Player1")
                {
                    Scrabble.p1.TotalPoints += score;
                    GameObject go = GameObject.Find("Player1ScoreLabel");
                    Text txt = (Text)go.GetComponent(typeof(Text));
                    txt.text = String.Format("Score: {0}", Scrabble.p1.TotalPoints);

                    foreach (Tile tile in Scrabble.p1.TileList)
                    {
                        if (tile != null)
                            tile.Lock();
                    }
                    foreach (Tile tile in Scrabble.p2.TileList)
                    {
                        if (tile != null)
                            tile.Unlock();
                    }

                }
                else
                {
                    Scrabble.p2.TotalPoints += score;
                    GameObject go = GameObject.Find("Player2ScoreLabel");
                    Text txt = (Text)go.GetComponent(typeof(Text));
                    txt.text = String.Format("Score: {0}", Scrabble.p2.TotalPoints);

                    foreach (Tile tile in Scrabble.p2.TileList)
                    {
                        if(tile != null)
                            tile.Lock();
                    }
                    foreach (Tile tile in Scrabble.p1.TileList)
                    {
                        if(tile != null)
                            tile.Unlock();
                    }
                }

                
            }
            if (validTurn)
            {
                for (int i = 0; i < spacesPlayed.Count; i++)
                {
                    if (Scrabble.PlayerTurn == "Player1")
                    {
                        Scrabble.p1.TileList[spacesPlayed[i].getTilePlayerIndex()] = null;
                    }
                    else if (Scrabble.PlayerTurn == "Player2")
                    {
                        Scrabble.p2.TileList[spacesPlayed[i].getTilePlayerIndex()] = null;
                    }
                    //No longer in the players hand, so set index to -1
                    spacesPlayed[i].setTilePlayerIndex(-1);
                }
                if (Scrabble.PlayerTurn == "Player1")
                {
                    Scrabble.PlayerTurn = "Player2";
                }
                else if (Scrabble.PlayerTurn == "Player2")
                {
                    Scrabble.PlayerTurn = "Player1";
                }
            }

            if(validTurn)
                spacesPlayed.Clear();

            else {
                Text currentPlayer = GameObject.Find("CurrentPlayerIndicator").GetComponent<Text>();
                string oldText = currentPlayer.text;
                if (!oldText.Contains("Invalid")) {
                    string newText = "Invalid word, " + oldText;
                    currentPlayer.text = newText;
                }
            }
            
            return validTurn;
        }

        // Start is called before the first frame update
        public static void Start()
        {
            for (int x = 0; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    //triple words
                    if (x == 0 && y == 0)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 0 && y == 7)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 0 && y == 14)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 7 && y == 0)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 7 && y == 14)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 14 && y == 0)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 14 && y == 7)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 14 && y == 14)
                        boardSpaces[x, y] = new BoardSpace(null, "3W", true, x, y);
                    else if (x == 7 && y == 7)
                        boardSpaces[x, y] = new BoardSpace(null, "", true, x, y);

                    //double letters
                    else if (x == 0 && y == 3)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 0 && y == 11)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 2 && y == 6)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 2 && y == 8)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 3 && y == 0)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 3 && y == 7)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 3 && y == 14)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 6 && y == 2)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 6 && y == 6)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 6 && y == 8)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 6 && y == 12)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 7 && y == 3)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 7 && y == 11)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 8 && y == 2)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 8 && y == 6)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 8 && y == 8)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 8 && y == 12)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 11 && y == 0)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 11 && y == 7)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 11 && y == 14)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 12 && y == 6)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 12 && y == 8)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    else if (x == 14 && y == 3)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);
                    else if (x == 14 && y == 11)
                        boardSpaces[x, y] = new BoardSpace(null, "2L", true, x, y);

                    //double words
                    else if (x == 1 && y == 1)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 2 && y == 2)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 3 && y == 3)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 4 && y == 4)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);

                    else if (x == 1 && y == 13)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 2 && y == 12)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 3 && y == 11)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 4 && y == 10)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);

                    else if (x == 13 && y == 1)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 12 && y == 2)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 11 && y == 3)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 10 && y == 4)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);

                    else if (x == 13 && y == 13)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 12 && y == 12)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 11 && y == 11)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);
                    else if (x == 10 && y == 10)
                        boardSpaces[x, y] = new BoardSpace(null, "2W", true, x, y);

                    //triple letters
                    else if (x == 5 && y == 1)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 1 && y == 5)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 5 && y == 5)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);

                    else if (x == 9 && y == 1)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 13 && y == 5)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 9 && y == 5)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);


                    else if (x == 5 && y == 13)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 1 && y == 9)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 5 && y == 9)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);

                    else if (x == 9 && y == 13)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 13 && y == 9)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);
                    else if (x == 9 && y == 9)
                        boardSpaces[x, y] = new BoardSpace(null, "3L", true, x, y);

                    //empty
                    else
                        boardSpaces[x, y] = new BoardSpace(null, "", true, x, y);
                }
            }
        }

    }
}
