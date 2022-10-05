using System.Collections.Generic;

public class ZPiece : Piece{
    public ZPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {0,0,1,1});
        colorPiece = SquareColor.RED;
    }
}