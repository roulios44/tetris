using System.Collections.Generic;

public class SPiece : Piece{
    public SPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {1,1,0,0});
        colorPiece = SquareColor.GREEN;
    }
}