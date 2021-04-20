using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace {

    public class DrawTileButtonHandler : MonoBehaviour {

        private Vector2 player1Pos1 = new Vector2(-6, 1.7f);
        private Vector2 player1Pos2 = new Vector2(-6, 1.15f);
        private Vector2 player1Pos3 = new Vector2(-6, 0.6f);
        private Vector2 player1Pos4 = new Vector2(-6, 0.05f);
        private Vector2 player1Pos5 = new Vector2(-6, -0.5f);
        private Vector2 player1Pos6 = new Vector2(-6, -1.05f);
        private Vector2 player1Pos7 = new Vector2(-6, -1.6f);

        private Vector2 player2Pos1 = new Vector2(6, 1.7f);
        private Vector2 player2Pos2 = new Vector2(6, 1.15f);
        private Vector2 player2Pos3 = new Vector2(6, 0.6f);
        private Vector2 player2Pos4 = new Vector2(6, 0.05f);
        private Vector2 player2Pos5 = new Vector2(6, -0.5f);
        private Vector2 player2Pos6 = new Vector2(6, -1.05f);
        private Vector2 player2Pos7 = new Vector2(6, -1.6f);

        public void Start() {
            
        }

        public void Update() {

        }

        public void OnClick() {

            if (Scrabble.tilePile.Count != 0) {
                for (int i = 1; i <= 7; i++) {
                    Vector2 position = new Vector2(0,0);

                    switch (i) {
                        case 1:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos1;
                            }
                            else if(Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos1;
                            }
                            break;
                        case 2:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos2;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos2;
                            }
                            break;
                        case 3:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos3;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos3;
                            }
                            break;
                        case 4:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos4;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos4;
                            }
                            break;
                        case 5:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos5;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos5;
                            }
                            break;
                        case 6:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos6;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos6;
                            }
                            break;
                        case 7:
                            if (Scrabble.PlayerTurn == "Player1") {
                                position = player1Pos7;
                            }
                            else if (Scrabble.PlayerTurn == "Player2") {
                                position = player2Pos7;
                            }
                            break;
                    }

                    char c = Scrabble.tilePile[0].getLetter();
                    Scrabble.tilePile.RemoveAt(0);
                    
                    string path = "Prefabs\\" + c;
                    var MyPrefab = Resources.Load<GameObject>(path);
                    GameObject go = Instantiate(MyPrefab, position, Quaternion.identity);
                    var v = (Tile)go.GetComponent(typeof(Tile));
                    v.Letter = c;
                }
                //if(Scrabble.PlayerTurn == "Player1"){
                //    Scrabble.PlayerTurn = "Player2";
                //}
                //else {
                //    Scrabble.PlayerTurn = "Player1";
                //}
            }
        }
    }

}

