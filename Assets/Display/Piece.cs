using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece {
    public SquareColor COLOR {get; set;}
    public int[] SPAWN_COORD_X {get; set;}
    public int[] SPAWN_COORD_Y {get; set;}
    public Piece(SquareColor color,  int[] spawn_coord_x, int[] spawn_coord_y) : base() {
        SquareColor COLOR = color;
        int[] SPAWN_COORD_X = spawn_coord_x;
        int[] SPAWN_COORD_Y = spawn_coord_y;
    }
}