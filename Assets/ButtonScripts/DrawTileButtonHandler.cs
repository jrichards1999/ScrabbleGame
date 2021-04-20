using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace ScrabbleNamespace {

    public class DrawTileButtonHandler : NetworkBehaviour {

        public GameObject Background;
        public GameObject PlayerShelf;
        public GameObject EnemyShelf;

        public Player Player;

        private Vector2 playerPos1 = new Vector2(-6, 1.7f);
        private Vector2 playerPos2 = new Vector2(-6, 1.15f);
        private Vector2 playerPos3 = new Vector2(-6, 0.6f);
        private Vector2 playerPos4 = new Vector2(-6, 0.05f);
        private Vector2 playerPos5 = new Vector2(-6, -0.5f);
        private Vector2 playerPos6 = new Vector2(-6, -1.05f);
        private Vector2 playerPos7 = new Vector2(-6, -1.6f);

        private Vector2 enemyPos1 = new Vector2(6, 1.7f);
        private Vector2 enemyPos2 = new Vector2(6, 1.15f);
        private Vector2 enemyPos3 = new Vector2(6, 0.6f);
        private Vector2 enemyPos4 = new Vector2(6, 0.05f);
        private Vector2 enemyPos5 = new Vector2(6, -0.5f);
        private Vector2 enemyPos6 = new Vector2(6, -1.05f);
        private Vector2 enemyPos7 = new Vector2(6, -1.6f);

        public void Start() {
            
        }

        public void Update() {

        }

        public void OnClick() {

            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            Player = networkIdentity.GetComponent<Player>();
            Player.CmdDealTiles();

            //if (Scrabble.tilePile.Count != 0) {
            //    //tile.transform.SetParent(PlayerShelf.transform, false);

            //    for(int i = 1; i <= 7; i++) {
            //        if(i == 1) {
            //            Vector2 position = playerPos1;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 2) {
            //            Vector2 position = playerPos2;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 3) {
            //            Vector2 position = playerPos3;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 4) {
            //            Vector2 position = playerPos4;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 5) {
            //            Vector2 position = playerPos5;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 6) {
            //            Vector2 position = playerPos6;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //        else if (i == 7) {
            //            Vector2 position = playerPos7;
            //            char c = Scrabble.tilePile[0].getLetter();
            //            Scrabble.tilePile.RemoveAt(0);

            //            string path = "Prefabs\\" + c;
            //            GameObject MyPrefab = Resources.Load<GameObject>(path);
            //            GameObject tile = Instantiate(MyPrefab, position, Quaternion.identity);
            //        }
            //    }
            //}
        }
    }
}

