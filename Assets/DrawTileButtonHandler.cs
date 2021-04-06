using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{

    public class DrawTileButtonHandler : MonoBehaviour
    {
        public GameObject[] MyPrefabs;

        public void Start()
        {
            //MyPrefabs = Resources.LoadAll<GameObject>("Prefabs");
        }

        public void Update()
        {

        }

        public void OnClick()
        {
            Vector2 position = new Vector2(-6, 3);
            var r = new System.Random();
            char n = (char)r.Next('A', 'Z');
            string path = "Prefabs\\" + n;
            var MyPrefab = Resources.Load<GameObject>(path);
            var gameObject = Instantiate(MyPrefab, position, Quaternion.identity);
            var tile = gameObject.GetComponent(typeof(Tile)) as Tile;
            tile.Letter = n;
        }
    }

}
