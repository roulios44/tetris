using System.Collections.Generic;

public class TPiece : Piece{
    public TPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {1,1,0,1});
        colorPiece = SquareColor.PURPLE;
    }
}