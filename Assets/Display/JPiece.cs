using System.Collections.Generic;

public class JPiece : Piece{
    public JPiece() : base(){
        ListX = new List<int>(new int[] {5,5,6,7});
        ListY = new List<int>(new int[] {1,0,0,0});
        colorPiece = SquareColor.DEEP_BLUE;
    }
}