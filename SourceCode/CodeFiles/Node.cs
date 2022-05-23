using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool connectNorth;
    public bool connectWest;
    public bool topRight;
    public int xPosition;
    public int yPosition;
    public ArrayList neighbours;
    public PieceType piece;

    public enum PieceType
    {
        TOP,
        LEFT,
        RIGHT,
        BOTTOM,
        TOPLEFT,
        TOPRIGHT,
        BOTTOMRIGHT,
        BOTTOMLEFT,
        LEFTRIGHT,
        TOPBOTTOM
    }


    public Node(int x, int y)
    {
        this.xPosition = x;
        this.yPosition = y;
    }

    public void GetNeighbours()
    {
        this.neighbours = new ArrayList();
        if (this.yPosition < 4 - 1)
        {
            this.neighbours.Add(CreateMap.nodes[this.xPosition, this.yPosition + 1]);

        }
        if (this.yPosition > 1)
        {
            this.neighbours.Add(CreateMap.nodes[this.xPosition, this.yPosition - 1]);
        }
        if (this.xPosition < 4 - 1)
        {
            this.neighbours.Add(CreateMap.nodes[this.xPosition + 1, this.yPosition]);

        }
        if (this.xPosition > 1)
        {
            this.neighbours.Add(CreateMap.nodes[this.xPosition - 1, this.yPosition]);

        }
    }
}
