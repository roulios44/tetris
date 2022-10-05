using System.Collections.Generic;

public class OPiece : Piece{
    public OPiece() : base(){
        ListX = new List<int>(new int[] {5,6,5,6});
        ListY = new List<int>(new int[] {0,0,1,1});
        colorPiece = SquareColor.YELLOW;
    }
}