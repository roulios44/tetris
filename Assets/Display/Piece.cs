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
    //TODO add a metod to watch piece under each pixel 
}


//Part with all pieces specifiquations

public class IPiece : Piece{
    public IPiece() : base(){
        ListX = new List<int>(new int[] {5,6,7,8});
        ListY = new List<int> (new int[] {0,0,0,0});
        colorPiece = SquareColor.LIGHT_BLUE;
    }
}
public class TPiece : Piece{
    public TPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {1,1,0,1});
        colorPiece = SquareColor.PURPLE;
    }
}
public class OPiece : Piece{
    public OPiece() : base(){
        ListX = new List<int>(new int[] {5,6,5,6});
        ListY = new List<int>(new int[] {0,0,1,1});
        colorPiece = SquareColor.YELLOW;
    }
}
public class ZPiece : Piece{
    public ZPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {0,0,1,1});
        colorPiece = SquareColor.RED;
    }
}
public class SPiece : Piece{
    public SPiece() : base(){
        ListX = new List<int>(new int[] {5,6,6,7});
        ListY = new List<int>(new int[] {1,1,0,0});
        colorPiece = SquareColor.GREEN;
    }
}
public class LPiece : Piece{
    public LPiece() : base(){
        ListX = new List<int>(new int[] {5,6,7,7});
        ListY = new List<int>(new int[] {0,0,0,1});
        colorPiece = SquareColor.ORANGE;
    }
}
public class JPiece : Piece{
    public JPiece() : base(){
        ListX = new List<int>(new int[] {5,5,6,7});
        ListY = new List<int>(new int[] {1,0,0,0});
        colorPiece = SquareColor.DEEP_BLUE;
    }
}