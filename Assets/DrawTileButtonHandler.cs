using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTileButtonHandler : MonoBehaviour {
    public GameObject[] MyPrefabs;

    public void Start() {
        MyPrefabs = Resources.LoadAll<GameObject>("Prefabs");
    }

    public void Update() {

    }

    public void OnClick() {
        Vector2 position = new Vector2(-6, 3);
        var r = new System.Random();
        int n = r.Next(0, 25);

        var MyPrefab = MyPrefabs[n];
        Instantiate(MyPrefab, position, Quaternion.identity);
    }
}
