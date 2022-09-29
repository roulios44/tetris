using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int widht = 0;
    public Pieces patternPieces = new Pieces();
    protected Piece currentPiece = new IPiece();
    public MirorGrid(){
        SetGrid();
    }
    protected void SetGrid(){
        for (int i=0;i<_grid.height;i++){
            List<SquareColor> LigneColor = new List<SquareColor>();
            for (int j=0;j<_grid.width;j++){
                SquareColor color = SquareColor.GREEN;
                LigneColor.Add(color);
            }
            mirorGrid.Add(LigneColor);   
        }
        _grid.SetColors(mirorGrid);
    }
    public void passifFall(){
        for (int i = 0; i<currentPiece.ListX.Count;i++){
            if (currentPiece.ListY[i] < 21){
                mirorGrid[currentPiece.ListY[i]][currentPiece.ListX[i]] = SquareColor.TRANSPARENT;
                currentPiece.ChangeListY(i,currentPiece.ListY[i]+1);
                mirorGrid[currentPiece.ListY[i]][currentPiece.ListX[i]] = currentPiece.colorPiece;
                }
            }
        _grid.SetColors(mirorGrid);
    }
    public void PieceGoRight(){
        _grid.SetColors(currentPiece.GoRight(mirorGrid));
    }
    public void PieceGoLeft(){
        _grid.SetColors(currentPiece.GoLeft(mirorGrid));
    }

    public void PieceRotate(){
        _grid.SetColors(currentPiece.Rotate(mirorGrid));
    }
    // public Piece generatePiece(){
    //     Piece.patternPieces.orderPiece[0];
    // }
    public void GameTick(){
        passifFall();
    }
}