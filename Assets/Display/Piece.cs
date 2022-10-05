using System.Collections.Generic;
using UnityEngine;
using System;

public class Piece{
    protected List<int> ListX;
    protected List<int> ListY;
    public SquareColor colorPiece;
    protected bool canGoRight;
    protected bool canGoLeft;
    protected bool canGoDown;
    protected bool canRotate;
    public bool isStop;

    protected void ChangeListX(int index, int value){
        ListX[index] = value;
    }

    protected void ChangeListY(int index, int value){
        ListY[index] = value;
    }

    public bool GetCanGoDown(){
        return canGoDown;
    }
    public List<List<SquareColor>> GoDown(MirorGrid grid){
        LookBottom(grid.mirorGrid, grid.GetHeight());
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
        LookRight(grid.mirorGrid,grid.GetWidth());
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
        LookLeft(mirorGrid);
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
    
    private void LookRight(List<List<SquareColor>> mirorGrid, int width){
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

    private void LookLeft(List<List<SquareColor>> mirorGrid){
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

    private void LookBottom(List<List<SquareColor>> mirorGrid, int height){
        bool bottomIsOk = true;
        for (int i = 0; i< ListY.Count;i++){
            if (ListY[i]+1 > height-1){
                bottomIsOk = false;
                break;
            }
            if (mirorGrid[ListY[i]+1][ListX[i]] != SquareColor.TRANSPARENT && IsOwn(ListY[i]+1,ListX[i],i)){
                bottomIsOk = false;
            }
        }
        if (bottomIsOk) canGoDown = true;
        else {
            canGoDown = false;
            isStop = true;
        }
    }

    private void LookRotate(MirorGrid grid){
        bool rotateIsOk = true;
        LookBottom(grid.mirorGrid, grid.GetHeight());
        LookRight(grid.mirorGrid, grid.GetWidth());
        LookLeft(grid.mirorGrid);
        if (!canGoDown) rotateIsOk = false;
        if (!canGoLeft) rotateIsOk = false;
        if (!canGoDown) rotateIsOk = false;
        if (rotateIsOk) canRotate = true;
        else canRotate = false;
    }
    /// It rotates the piece by 90 degrees clockwise
    /// <param name="mirorGrid">a list of lists of SquareColor, which is an enum that can be either
    /// TRANSPARENT, RED, BLUE, GREEN, YELLOW, PURPLE, ORANGE, or CYAN.</param>
    public void RotatePiece(MirorGrid mirorGrid){
        LookRotate(mirorGrid);
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

    private bool IsOwn(int y, int x, int index){
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

