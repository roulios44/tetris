using System.Collections.Generic;

public class LPiece : Piece{
    public LPiece() : base(){
        ListX = new List<int>(new int[] {5,6,7,7});
        ListY = new List<int>(new int[] {0,0,0,1});
        colorPiece = SquareColor.ORANGE;
    }
}