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

        public void Start() {
            
        }

        public void Update() {

        }

        public void OnClick() {

            if (Scrabble.tilePile.Count != 0) {
                char c = Scrabble.tilePile[0].getLetter();
                Scrabble.tilePile.RemoveAt(0);
                Vector2 position = new Vector2(-6,4);

                string path = "Prefabs\\" + c;
                var MyPrefab = Resources.Load<GameObject>(path);
                MyPrefab.transform.SetParent(Background.transform, false);
                var tile = Instantiate(MyPrefab, position, Quaternion.identity);
            }
        }
    }
}

