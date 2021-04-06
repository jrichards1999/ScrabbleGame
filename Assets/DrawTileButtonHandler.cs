using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace {

    public class DrawTileButtonHandler : MonoBehaviour {

        public void Start() {
            
        }

        public void Update() {

        }

        public void OnClick() {

            if (Scrabble.tilePile.Count != 0) {
                char c = Scrabble.tilePile[0].getLetter();
                Scrabble.tilePile.RemoveAt(0);
                Vector2 position = new Vector2(-6, 3);

                string path = "Prefabs\\" + c;
                var MyPrefab = Resources.Load<GameObject>(path);
                Instantiate(MyPrefab, position, Quaternion.identity);
            }
        }
    }

}

