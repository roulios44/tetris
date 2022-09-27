using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece{
    public Piece(SquareColor color,  int[,] spawn_coord) {
        String COLOR = color;
        int[,] SPAWN_COORD = spawn_coord;
    }


    //List<List<SquareColor>> Piece = new List<list<SquareColor>>(); 
    Piece LIGHT_BLUE_PIECE = new Piece {SquareColor.LIGHT_BLUE, {{5, 6, 7, 8}, {0, 0, 0, 0}}};
    Piece DEEP_BLUE = new Piece {SquareColor.DEEP_BLUE, {{5, 6, 7, 8}, {0, 0, 0, 0}}};
    Piece ORANGE = new Piece {SquareColor.ORANGE, {{5, 6, 7, 8}, {0, 0, 0, 0}}};
    Piece YELLOW = new Piece {SquareColor.YELLOW, {{5, 6, 7, 8}, {0, 0, 0, 0}}};
    Piece GREEN = new Piece {SquareColor.GREEN, {{5, 6, 7, 8}, {0, 0, 0, 0}}};
    Piece PURPLE = new Piece {SquareColor.PURPLE, {{5, 6, 7, 8}, {0, 0, 0, 0}}};

    
}