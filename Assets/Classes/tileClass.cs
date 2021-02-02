using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class tile : MonoBehaviour
    {
        private int pointVal;
        private string letter;

        public tile(int points, string character)
        {
            pointVal = points;
            letter = character;
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

