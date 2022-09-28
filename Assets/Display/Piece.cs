using System.Collections.Generic;
using UnityEngine;

public class Piece{
    public List<int> ListX;
    public List<int> ListY;
    public SquareColor colorPiece;
    public bool canGoRight;
    public bool canGoLeft;
    public bool canGoDown;
    public bool isStop;

    public void ChangeListX(int index, int value){
        ListX[index] = value;
    }

    public void ChangeListY(int index, int value){
        ListY[index] = value;
    }

    public List<List<SquareColor>> GoDown(List<List<SquareColor>> mirorGrid){
        lookBottom(mirorGrid);
        if (canGoDown){
            for (int i = 0; i<ListX.Count;i++){
                mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
                ChangeListY(i,ListY[i]+1);
                mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return mirorGrid;
    }
    
    public List<List<SquareColor>> GoRight(List<List<SquareColor>> mirorGrid){
        lookRight();
        if (canGoRight){
            for (int i=0;i<ListX.Count;i++){
                mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
            }
            for (int i=0;i<ListX.Count;i++){
                ChangeListX(i, ListX[i] + 1);
                mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return mirorGrid;
    }

    public List<List<SquareColor>> GoLeft(List<List<SquareColor>> mirorGrid){
        lookLeft();
        if (canGoLeft){
            for (int i=0;i<ListX.Count;i++){
                mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
                ChangeListX(i, ListX[i] - 1);
                mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return mirorGrid;
    }
    
    private void lookRight(){
        bool rightisOk = true;
        foreach (int coordX in ListX){
            if (coordX + 1 > 9) rightisOk = false;
        }
        if (rightisOk) canGoRight = true;
        else canGoRight = false;
    }

    private void lookLeft(){
        bool leftIsOk = true;
        foreach (int coordX in ListX){
            if (coordX - 1 < 0) leftIsOk = false;
        }
        if (leftIsOk) canGoLeft = true;
        else canGoLeft = false;
    }

    private void lookBottom(List<List<SquareColor>> mirorGrid){
        bool bottomIsOk = true;
        for (int i = 0; i<ListX.Count;i++){
            if (!(mirorGrid[ListY[i]+1][ListX[i]] == SquareColor.TRANSPARENT && ListY[i]+1 < 21)){
                bottomIsOk = false;
            }
            if (bottomIsOk) canGoDown = true;
            else canGoDown = false;
        }
    }
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