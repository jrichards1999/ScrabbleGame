using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScrabbleNamespace {

    public class WinnerDisplayHandler : MonoBehaviour {
        public void DisplayP1Winner() {
            var position = new Vector2(0, 0);
            string path = "Prefabs\\p1wins";
            var MyPrefab = Resources.Load<GameObject>(path);
            GameObject go = Instantiate(MyPrefab, position, Quaternion.identity);
            finishGame();
        }
        public void DisplayP2Winner() {
            var position = new Vector2(0, 0);
            string path = "Prefabs\\p2wins";
            var MyPrefab = Resources.Load<GameObject>(path);
            GameObject go = Instantiate(MyPrefab, position, Quaternion.identity);
            finishGame();
        }
        public void DisplayTie() {
            var position = new Vector2(0, 0);
            string path = "Prefabs\\tie";
            var MyPrefab = Resources.Load<GameObject>(path);
            GameObject go = Instantiate(MyPrefab, position, Quaternion.identity);
            finishGame();
        }

        private void finishGame() {
            Scrabble.GameFinished = true;
            Text currentPlayer = GameObject.Find("CurrentPlayerIndicator").GetComponent<Text>();
            currentPlayer.text = "Game Is Finished";
        }
    }
}