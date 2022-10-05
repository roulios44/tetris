using System.Collections.Generic;
using UnityEngine;
using System;

public class Piece{
    public List<int> ListX;
    public List<int> ListY;
    public SquareColor colorPiece;
    public bool canGoRight;
    public bool canGoLeft;
    public bool canGoDown;
    public bool canRotate;
    public bool isStop;
    public bool onRush = false;

    public void ChangeListX(int index, int value){
        ListX[index] = value;
    }

    public void ChangeListY(int index, int value){
        ListY[index] = value;
    }

    public List<List<SquareColor>> GoDown(MirorGrid grid){
        lookBottom(grid.mirorGrid, grid.getHeight());
        if (canGoDown){
            for (int i = 0; i<ListX.Count;i++){
                grid.mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
            }
            for ( int i=0;i<ListX.Count;i++){
                ChangeListY(i,ListY[i]+1);
                grid.mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return grid.mirorGrid;
    }
    
    public List<List<SquareColor>> GoRight(MirorGrid grid){
        lookRight(grid.mirorGrid,grid.getWidth());
        if (canGoRight){
            for (int i=0;i<ListX.Count;i++){
                grid.mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
            }
            for (int i=0;i<ListX.Count;i++){
                ChangeListX(i, ListX[i] + 1);
                grid.mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return grid.mirorGrid;
    }

    public List<List<SquareColor>> GoLeft(List<List<SquareColor>> mirorGrid){
        lookLeft(mirorGrid);
        if (canGoLeft){
            for (int i=0;i<ListX.Count;i++){
                mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
            }
            for (int i=0;i<ListX.Count;i++){
                ChangeListX(i, ListX[i] - 1);
                mirorGrid[ListY[i]][ListX[i]] = colorPiece;
            }
        }
        return mirorGrid;
    }
    
    private void lookRight(List<List<SquareColor>> mirorGrid, int width){
        bool rightisOk = true;
        for (int i = 0; i<ListX.Count;i++){
            // Look if the future right position is not out of limit
            if (ListX[i] + 1 > width-1 ) {
                rightisOk = false;
                break;
            }
            // Look if the future right position is free
            if (!(mirorGrid[ListY[i]][ListX[i]+1] == SquareColor.TRANSPARENT) && !(ListX.Contains(ListX[i]+1))) rightisOk = false;
        }
        if (rightisOk) canGoRight = true;
        else canGoRight = false;
    }

    private void lookLeft(List<List<SquareColor>> mirorGrid){
        bool leftIsOk = true;
        for (int i = 0;i<ListX.Count;i++){
            // Look if the future left position don't gonna be out of the gird limit
            if (ListX[i] - 1 < 0){
                leftIsOk = false;
                break;
            } 
            // Look if the future left position is free
            if (!(mirorGrid[ListY[i]][ListX[i]-1] == SquareColor.TRANSPARENT) && !(ListX.Contains(ListX[i]-1))) leftIsOk = false;
        }
        if (leftIsOk) canGoLeft = true;
        else canGoLeft = false;
    }

    private void lookBottom(List<List<SquareColor>> mirorGrid, int height){
        bool bottomIsOk = true;
        for (int i = 0; i< ListY.Count;i++){
            if (ListY[i]+1 > height-1){
                bottomIsOk = false;
                break;
            }
            if (mirorGrid[ListY[i]+1][ListX[i]] != SquareColor.TRANSPARENT && isOwn(ListY[i]+1,ListX[i],i)){
                bottomIsOk = false;
            }
        }
        if (bottomIsOk) canGoDown = true;
        else {
            canGoDown = false;
            isStop = true;
        }
    }

    private void lookRotate(MirorGrid grid){
        bool rotateIsOk = true;
        lookBottom(grid.mirorGrid, grid.getHeight());
        lookRight(grid.mirorGrid, grid.getWidth());
        lookLeft(grid.mirorGrid);
        if (!canGoDown) rotateIsOk = false;
        if (!canGoLeft) rotateIsOk = false;
        if (!canGoDown) rotateIsOk = false;
        if (rotateIsOk) canRotate = true;
        else canRotate = false;
    }
    /// It rotates the piece by 90 degrees clockwise
    /// <param name="mirorGrid">a list of lists of SquareColor, which is an enum that can be either
    /// TRANSPARENT, RED, BLUE, GREEN, YELLOW, PURPLE, ORANGE, or CYAN.</param>
    public void rotatePiece(MirorGrid mirorGrid){
        lookRotate(mirorGrid);
        if (canRotate){
            for (int i = 0;i<ListX.Count;i++){
                // here we take the 2nd block (so the index 1 in coord) to move other block around, so he doesn't change his coord
            if ( i != 1){
                int coordX = ListX[i] - ListX[1];
                int coordY = ListY[i] - ListY[1];
                int newCoordX = Convert.ToInt32((coordX* Math.Cos(Math.PI/2) - coordY*Math.Sin(Math.PI/2)));
                int newCoordY = Convert.ToInt32((coordX * Math.Sin(Math.PI/2) + coordY * Math.Cos(Math.PI/2)));
                mirorGrid.mirorGrid[ListY[i]][ListX[i]] = SquareColor.TRANSPARENT;
                ChangeListX(i,newCoordX + ListX[1]);
                ChangeListY(i,newCoordY + ListY[1]);
            }
            
        }
        for ( int i = 0;i<ListX.Count;i++)mirorGrid.mirorGrid[ListY[i]][ListX[i]] = colorPiece;
        }
       
    }

    private bool isOwn(int y, int x, int index){
        bool underIsOwn = false;
        for (int i = 0; i<ListX.Count;i++){
            if (i != index){
                if ((y == ListY[i]) && (x == ListX[i])) underIsOwn =  true;
            }
        }
        if (underIsOwn)return false;
        return true;
    }
}


//Part with all pieces specifiquations (Coord & Colors)

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