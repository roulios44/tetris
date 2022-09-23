using System.Collections.Generic;

public class Piece{
    public List<int> ListX;
    public List<int> ListY;
    public SquareColor colorPiece;

    public void ChangeListX(int index, int value){
        ListX[index] = value;
    }
    public void ChangeListY(int index, int value){
        ListY[index] = value;
    }
}

public class IPiece : Piece{
    public IPiece() : base(){
        ListX = new List<int>(new int[] {5,6,7,8});
        ListY = new List<int> (new int[] {0,0,0,0});
        colorPiece = SquareColor.LIGHT_BLUE;
    }
}