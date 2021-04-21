using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace {
    public class RevertTilesButtonHandler : MonoBehaviour {
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

        public void OnClick() {
            if (Scrabble.GameFinished) {
                return;
            }

            if(Scrabble.PlayerTurn == "Player1") {
                for(int i = 0; i < Board.spacesPlayed.Count; i++) {
                    var playedTile = (Tile)Board.spacesPlayed[i].getTile();
                    var tileIndex = playedTile.UserListIndex;

                    switch (tileIndex) {
                        case 0:
                            playedTile.transform.position = player1Pos1;
                            break;
                        case 1:
                            playedTile.transform.position = player1Pos2;
                            break;
                        case 2:
                            playedTile.transform.position = player1Pos3;
                            break;
                        case 3:
                            playedTile.transform.position = player1Pos4;
                            break;
                        case 4:
                            playedTile.transform.position = player1Pos5;
                            break;
                        case 5:
                            playedTile.transform.position = player1Pos6;
                            break;
                        case 6:
                            playedTile.transform.position = player1Pos7;
                            break;
                    }
                }
            }
            else if (Scrabble.PlayerTurn == "Player2") {
                for (int i = 0; i < Board.spacesPlayed.Count; i++) {
                    var playedTile = (Tile)Board.spacesPlayed[i].getTile();
                    var tileIndex = playedTile.UserListIndex;

                    switch (tileIndex) {
                        case 0:
                            playedTile.transform.position = player2Pos1;
                            break;
                        case 1:
                            playedTile.transform.position = player2Pos2;
                            break;
                        case 2:
                            playedTile.transform.position = player2Pos3;
                            break;
                        case 3:
                            playedTile.transform.position = player2Pos4;
                            break;
                        case 4:
                            playedTile.transform.position = player2Pos5;
                            break;
                        case 5:
                            playedTile.transform.position = player2Pos6;
                            break;
                        case 6:
                            playedTile.transform.position = player2Pos7;
                            break;
                    }
                }
            }
            foreach(var space in Board.spacesPlayed)
            {
                Board.RemoveTile(space.getTile());
            }
            Board.spacesPlayed.Clear();
        }
    }
}