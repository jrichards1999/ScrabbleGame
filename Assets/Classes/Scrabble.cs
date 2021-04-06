using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Scrabble : MonoBehaviour
    {
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
            BoardSpaces[0, 4] = new BoardSpace(new Tile('T', false), "3L", false, 0, 4);//T  of Test

            BoardSpaces[1, 0] = new BoardSpace(new Tile('A', false), "2W", false, 1, 0);
            BoardSpaces[1, 1] = new BoardSpace(new Tile('P', false), "3W", false, 1, 1);
            BoardSpaces[1, 2] = new BoardSpace(new Tile('P', false), "2L", false, 1, 2);
            BoardSpaces[1, 3] = new BoardSpace(new Tile('L', false), "3L", false, 1, 3);
            BoardSpaces[1, 4] = new BoardSpace(new Tile('E', false), "3L", false, 1, 4);//E of Test (already played)

            BoardSpaces[2, 4] = new BoardSpace(new Tile('S', false), "3L", false, 2, 4);//S of Test and So
            BoardSpaces[2, 5] = new BoardSpace(new Tile('O', false), "3L", false, 2, 5);//O of So

            BoardSpaces[3, 4] = new BoardSpace(new Tile('T', false), "3L", false, 3, 4);//T of Test
            BoardSpaces[3, 5] = new BoardSpace(new Tile('R', false), "3L", false, 3, 5);
            BoardSpaces[3, 6] = new BoardSpace(new Tile('A', false), "3L", false, 3, 6);
            BoardSpaces[3, 7] = new BoardSpace(new Tile('P', false), "3L", false, 3, 7);

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
            int wordTotal = 0;
            string modifiers = "";
            List<BoardSpace> spacesAdded = new List<BoardSpace>();
            List<BoardSpace> countedPlays = new List<BoardSpace>();

            foreach (BoardSpace space in spacesPlayed)
            {
                //Check Above and Below
                if ((space.getX() != 0 && BoardSpaces[space.getX() - 1, space.getY()].checkEmpty() == false) || (space.getX() != 15 && BoardSpaces[space.getX() + 1, space.getY()].checkEmpty() == false))
                {
                    //Add all modifiers, although this string will only be checked later for double or triple word
                    modifiers += space.getMod();

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
                    countedPlays.Add(space);
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    //Above
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
                    //Reset to original position
                    xIndex = space.getX();
                    yIndex = space.getY();

                    //Below
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

            modifiers = "";
            wordTotal += total;
            total = 0;

            foreach (BoardSpace space in spacesPlayed)
            {
                //Check Left and Right Space 
                if ((space.getY() != 0 && BoardSpaces[space.getX(), space.getY() - 1].checkEmpty() == false) || (space.getY() != 15 && BoardSpaces[space.getX(), space.getY() + 1].checkEmpty() == false))
                {
                    //Add the modifier when checking left and right only if that modifier wasn't already used - otherwise just add the value of the tile
                    if (!countedPlays.Contains(space))
                    {
                        //Add all modifiers, although this string will only be checked later for double or triple word
                        modifiers += space.getMod();

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
                    }
                    else
                    {
                        total += space.getTile().getVal();
                    }
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    //Left
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
                    //Reset to original position
                    xIndex = space.getX();
                    yIndex = space.getY();

                    //Right
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

            wordTotal += total;

            return wordTotal;

        }

        static bool validTurn(List<BoardSpace> spacesPlayed)
        {
            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary();

            oDict.DictionaryFile = "en-US.dic";
            oDict.Initialize();

            List<String> wordsPlayed = new List<String>();
            List<BoardSpace> spacesAdded = new List<BoardSpace>();

            foreach (BoardSpace space in spacesPlayed)
            {
                string word = "";
                word += space.getTile().getLetter();

                //Check Above and Below
                if ((space.getX() != 0 && BoardSpaces[space.getX() - 1, space.getY()].checkEmpty() == false) || (space.getX() != 15 && BoardSpaces[space.getX() + 1, space.getY()].checkEmpty() == false))
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    //Above
                    while (xIndex != 0 && BoardSpaces[xIndex - 1, yIndex].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex - 1, yIndex], spacesAdded))
                    {
                        spacesAdded.Add(BoardSpaces[xIndex - 1, yIndex]);
                        word = BoardSpaces[xIndex - 1, yIndex].getTile().getLetter() + word;
                        Console.WriteLine(word);

                        xIndex--;
                    }
                    //Reset to original position
                    xIndex = space.getX();
                    yIndex = space.getY();

                    //Below
                    while (xIndex != 15 && BoardSpaces[xIndex + 1, yIndex].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex + 1, yIndex], spacesAdded))
                    {
                        spacesAdded.Add(BoardSpaces[xIndex + 1, yIndex]);
                        word = word + BoardSpaces[xIndex + 1, yIndex].getTile().getLetter();
                        Console.WriteLine(word);

                        xIndex++;
                    }

                    if (word.Length > 1)
                    {
                        wordsPlayed.Add(word);
                    }
                }

                word = "";
                word += space.getTile().getLetter();
                //Check Left and Right Space 
                if ((space.getY() != 0 && BoardSpaces[space.getX(), space.getY() - 1].checkEmpty() == false) || (space.getY() != 15 && BoardSpaces[space.getX(), space.getY() + 1].checkEmpty() == false))
                {
                    int xIndex = space.getX();
                    int yIndex = space.getY();
                    //Left
                    while (yIndex != 0 && BoardSpaces[xIndex, yIndex - 1].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex, yIndex - 1], spacesAdded))
                    {
                        spacesAdded.Add(BoardSpaces[xIndex, yIndex - 1]);
                        word = BoardSpaces[xIndex, yIndex - 1].getTile().getLetter() + word;
                        Console.WriteLine(word);

                        yIndex--;
                    }
                    //Reset to original position
                    xIndex = space.getX();
                    yIndex = space.getY();

                    //Right
                    while (yIndex != 15 && BoardSpaces[xIndex, yIndex + 1].checkEmpty() == false && !checkListForMatch(BoardSpaces[xIndex, yIndex + 1], spacesAdded))
                    {
                        spacesAdded.Add(BoardSpaces[xIndex, yIndex + 1]);
                        word = word + BoardSpaces[xIndex, yIndex + 1].getTile().getLetter();
                        Console.WriteLine(word);

                        yIndex++;
                    }

                    if (word.Length > 1)
                    {
                        wordsPlayed.Add(word);
                    }
                }

            }

            foreach (string word in wordsPlayed)
            {
                string wordToCheck = word;
                NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling();

                oSpell.Dictionary = oDict;
                if (!oSpell.TestWord(wordToCheck))
                {
                    //FAKE WORD DETECTED - RETURN FALSE AND NOTIFY PLAYER THEIR TURN IS NO GOOD
                    return false;
                }
            }


            return true;//ALL WORDS ARE GOOD
        }

        static void Main(string[] args)
        {
            populateBoard();

            //Create list with the aforementioned [t][e][s][t] BoardSpaces
            List<BoardSpace> testList = new List<BoardSpace>();
            testList.Add(BoardSpaces[0, 4]);
            testList.Add(BoardSpaces[2, 4]);

            //Write total to console
            Console.WriteLine(validTurn(testList));
            Console.Read();
        }

        // Start is called before the first frame update
        void Start()
        {
            tilePile = initializeTilePile();
            Board.Start();
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

        public void OnClick() {

        }

    }


}

