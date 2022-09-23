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

public class JPiece : Piece {
    public JPiece() : base() {
        ListX = new List<int>(new int[] {5, 5, 6, 7});
        ListY = new List<int> (new int[] {0, 1, 1, 1});
        colorPiece = SquareColor.DEEP_BLUE;
    }
}

public class KPiece : Piece {
    public KPiece() : base() {
        ListX = new List<int>(new int[] {5, 6, 7, 7});
        ListY = new List<int> (new int[] {1, 1, 1, 0});
        colorPiece = SquareColor.ORANGE;
    }
}

public class LPiece : Piece {
    public LPiece() : base() {
        ListX = new List<int>(new int[] {5, 5, 6, 6});
        ListY = new List<int> (new int[] {0, 0, 1, 1});
        colorPiece = SquareColor.YELLOW;
    }
}

public class MPiece : Piece {
    public MPiece() : base() {
        ListX = new List<int>(new int[] {5, 6, 6, 7});
        ListY = new List<int> (new int[] {1, 1, 0, 0});
        colorPiece = SquareColor.GREEN;
    }
}

public class NPiece : Piece {
    public NPiece() : base() {
        ListX = new List<int>(new int[] {5, 6, 6, 7});
        ListY = new List<int> (new int[] {1, 1, 0, 1});
        colorPiece = SquareColor.PURPLE;
    }
}

public class OPiece : Piece {
    public OPiece() : base() {
        ListX = new List<int>(new int[] {5, 6, 6, 7});
        ListY = new List<int> (new int[] {0, 0, 1, 1});
        colorPiece = SquareColor.RED;
    }
}