using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace ScrabbleNamespace {
    public class Player : NetworkBehaviour
    {
        public string Name;
        public int TotalPoints;
        public ArrayList TileList;
        public List<Tile> TempList;
        public List<Tile> PlayedTileList;

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

        public override void OnStartClient() {
            base.OnStartClient();

            TotalPoints = 0;
        }

        [Command]
        public void CmdDealTiles() {
            if (Scrabble.tilePile.Count != 0) {

                for (int i = 1; i <= 7; i++) {
                    if (i == 1) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0,0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                        if (hasAuthority) {
                            tile.transform.position = playerPos1;
                        }
                        else {
                            tile.transform.position = enemyPos1;
                        }
                    }
                    else if (i == 2) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                    else if (i == 3) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                    else if (i == 4) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                    else if (i == 5) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                    else if (i == 6) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                    else if (i == 7) {
                        char c = Scrabble.tilePile[0].getLetter();
                        Scrabble.tilePile.RemoveAt(0);
                        string path = "Prefabs\\" + c;
                        GameObject MyPrefab = Resources.Load<GameObject>(path);
                        GameObject tile = Instantiate(MyPrefab, new Vector2(0, 0), Quaternion.identity);
                        NetworkServer.Spawn(tile, connectionToClient);
                        RpcShowTile(tile, i.ToString());
                    }
                }
            }
        }

        [ClientRpc]
        void RpcShowTile(GameObject tile, string location) {
            if(location == "1") {
                if (hasAuthority) {
                    tile.transform.position = playerPos1;
                }
                else {
                    tile.transform.position = enemyPos1;
                }
            }
            else if (location == "2") {
                if (hasAuthority) {
                    tile.transform.position = playerPos2;
                }
                else {
                    tile.transform.position = enemyPos2;
                }
            }
            else if (location == "1") {
                if (hasAuthority) {
                    tile.transform.position = playerPos1;
                }
                else {
                    tile.transform.position = enemyPos1;
                }
            }
            else if (location == "3") {
                if (hasAuthority) {
                    tile.transform.position = playerPos3;
                }
                else {
                    tile.transform.position = enemyPos3;
                }
            }
            else if (location == "4") {
                if (hasAuthority) {
                    tile.transform.position = playerPos4;
                }
                else {
                    tile.transform.position = enemyPos4;
                }
            }
            else if (location == "5") {
                if (hasAuthority) {
                    tile.transform.position = playerPos5;
                }
                else {
                    tile.transform.position = enemyPos5;
                }
            }
            else if (location == "6") {
                if (hasAuthority) {
                    tile.transform.position = playerPos6;
                }
                else {
                    tile.transform.position = enemyPos6;
                }
            }
            else if (location == "7") {
                if (hasAuthority) {
                    tile.transform.position = playerPos7;
                }
                else {
                    tile.transform.position = enemyPos7;
                }
            }
        }

        public void updateTotalPoints(int points)
        {
            TotalPoints += points;
        }

        public int getPoints()
        {
            return TotalPoints;
        }

        public void updateList(int index)
        {
            PlayedTileList.Add(TempList[index]);
            TileList.RemoveAt(index);
        }

        public void playerTurn()
        {
            bool done = false;

            while (!done)
            {
                if (TileList.Count == 0)
                {
                    done = true;
                }

                //var index = placeTile() - TODO method to place tile, and return index of TileList from which the tile was taken
                //updateList(index);

            }
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

