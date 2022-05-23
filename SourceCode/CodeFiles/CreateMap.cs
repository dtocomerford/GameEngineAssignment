using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public static Node[,] nodes = new Node[4, 4];
    public GameObject bottom;
    public GameObject bottomLeft;
    public GameObject bottomRight;
    public GameObject leftSide;
    public GameObject rightSide;
    public GameObject top;
    public GameObject topLeft;
    public GameObject topRight;
    public GameObject topBottom;
    public GameObject leftRight;

    public int xPosition = 0;
    public int zPosition = 0;


    public int iX = 0;
    public int jY = 0;



    // Start is called before the first frame update
    void Start()
    {
        //Populate the 2D array with nodes
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                nodes[i, j] = new Node(i, j);
            }
        }

        GetNeighbours();

        //Set the connections for each node
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {

                //Randomly set the connection as north or west
                int result = Random.Range(1, 3);
                if (result == 1)
                {
                    nodes[i, j].connectNorth = true;
                    nodes[i, j].topRight = false;
                }
                if (result == 2)
                {
                    nodes[i, j].connectWest = true;
                    nodes[i, j].topRight = false;
                }

                //Its a far left grid piece
                if (nodes[i, j].xPosition == 0)
                {
                    nodes[i, j].connectWest = false;
                    nodes[i, j].connectNorth = true;
                    nodes[i, j].topRight = false;
                    nodes[i, j].piece = Node.PieceType.LEFT;
                }
                //Its a top piece
                if (nodes[i, j].yPosition == 0)
                {
                    nodes[i, j].connectWest = true;
                    nodes[i, j].connectNorth = false;
                    nodes[i, j].topRight = false;
                    nodes[i, j].piece = Node.PieceType.TOP;
                }
                //Its the starting piece in the top left 
                if (nodes[i, j].yPosition == 0 && nodes[i, j].xPosition == 0)
                {
                    nodes[i, j].connectWest = false;
                    nodes[i, j].connectNorth = false;
                    nodes[i, j].piece = Node.PieceType.TOPLEFT;
                }

                //Its the top right piece
                if (nodes[i, j].xPosition == nodes.GetLength(0)-1 && j == 0)
                {
                    nodes[i, j].connectWest = false;
                    nodes[i, j].connectNorth = false;
                    nodes[i, j].topRight = true;
                    nodes[i, j].piece = Node.PieceType.TOPRIGHT;
                }

                //Check to see if its an edge piece, if so add another side to the piece
                //For these pieces they are on the far right side of the grid so require a right side
                if (nodes[i, j].xPosition == nodes.GetLength(0) - 1 && nodes[i, j].connectWest == true)
                {
                    nodes[i, j].piece = Node.PieceType.TOPRIGHT;
                }

                if (nodes[i, j].xPosition == nodes.GetLength(0) - 1 && nodes[i, j].connectNorth == true)
                {
                    nodes[i, j].piece = Node.PieceType.LEFTRIGHT;
                }

                if(nodes[i, j].yPosition == nodes.GetLength(0)-1 && nodes[i, j].connectNorth)
                {
                    nodes[i, j].piece = Node.PieceType.BOTTOMLEFT;
                }
                if (nodes[i, j].yPosition == nodes.GetLength(0) - 1 && nodes[i, j].connectWest)
                {
                    nodes[i, j].piece = Node.PieceType.TOPBOTTOM;
                }


            }
        }

        //PrintConnections();
        DrawGrid();
    }



    void Update()
    {


        
    }


    void DrawGrid()
    {
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                //Its a top left grid piece
                if (nodes[i, j].piece == Node.PieceType.TOPLEFT)
                {
                    Instantiate(topLeft, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }
                //Its a top piece
                if (nodes[i, j].piece == Node.PieceType.TOP)
                {
                    Instantiate(top, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }
                //Its a left piece
                if (nodes[i, j].piece == Node.PieceType.LEFT)
                {
                    Instantiate(leftSide, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }
                //Its a top right piece
                if (nodes[i, j].piece == Node.PieceType.TOPRIGHT)
                {
                    Instantiate(topRight, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }
                //its a bottom left piece
                if (nodes[i, j].piece == Node.PieceType.BOTTOMLEFT)
                {
                    Instantiate(bottomLeft, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }
                //Its a bottom right piece
                if (nodes[i, j].piece == Node.PieceType.BOTTOMRIGHT)
                {
                    Instantiate(bottomRight, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }

                //Its a top and bottom piece
                if (nodes[i, j].piece == Node.PieceType.TOPBOTTOM)
                {
                    Instantiate(topBottom, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;
                }

                //Its a left right side piece
                if (nodes[i, j].piece == Node.PieceType.LEFTRIGHT)
                {
                    Instantiate(leftRight, new Vector3(xPosition, 0, zPosition), Quaternion.identity);
                    xPosition -= 10;

                }
            }
            zPosition += 10;
            xPosition = 0;
        }
    }





    void GetNeighbours()
    {
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                nodes[i, j].GetNeighbours();

            }
        }
    }

    void PrintConnections()
    {
        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            for (int j = 0; j < nodes.GetLength(0); j++)
            {
                Debug.Log("x: " + i + " y: " + j);
                //Debug.Log("x: " + nodes[i,j].xPosition + " y: " + nodes[i, j].yPosition);

                Debug.Log("North: " + nodes[i, j].connectNorth);
                Debug.Log("West: " + nodes[i, j].connectWest);
                Debug.Log("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Debug.Log("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
            }
        }
    }


}
