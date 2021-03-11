using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScrabbleNamespace
{
    public class Tile : MonoBehaviour
    {
        // The plane the object is currently being dragged on
        private Plane dragPlane;

        // The difference between where the mouse is on the drag plane and 
        // where the origin of the object is on the drag plane
        private Vector3 offset;

        private int pointVal;
        private char letter;

        private Camera myMainCamera;
        private bool beingDragged = false;

        int GetPointValue(char c)
        {
            switch (c)
            {
                case 'A': return 1;
                case 'B': return 3;
                case 'C': return 3;
                case 'D': return 2;
                case 'E': return 1;
                case 'F': return 4;
                case 'G': return 2;
                case 'H': return 4;
                case 'I': return 1;
                case 'J': return 8;
                case 'K': return 5;
                case 'L': return 1;
                case 'M': return 3;
                case 'N': return 1;
                case 'O': return 1;
                case 'P': return 3;
                case 'Q': return 10;
                case 'R': return 1;
                case 'S': return 1;
                case 'T': return 1;
                case 'U': return 1;
                case 'V': return 4;
                case 'W': return 4;
                case 'X': return 8;
                case 'Y': return 4;
                case 'Z': return 10;
                default: return 0;
            }
        }

        public Tile(char character, bool blank = false)
        {
            if (!blank)
                pointVal = GetPointValue(character);
            else
                pointVal = 0;
            letter = character;
        }

        public int getVal()
        {
            return pointVal;
        }

        // Start is called before the first frame update
        void Start()
        {
            myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnMouseDown() {
            beingDragged = true;
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }

        void OnMouseDrag() {
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }

        private void OnMouseUp() {
            if (beingDragged) {
                transform.position = new Vector2(0, 0);
                beingDragged = false;
            }
        }
    }
}

