using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int widht = 0;
    private int indexActuelPiece = 0;
    public Pieces patternPieces = new Pieces();
    protected Piece currentPiece;
    public MirorGrid(){
        currentPiece = patternPieces.allPieces[indexActuelPiece];
        SetGrid();
    }
    protected void SetGrid(){
        for (int i=0;i<_grid.height;i++){
            List<SquareColor> LigneColor = new List<SquareColor>();
            for (int j=0;j<_grid.width;j++){
                SquareColor color = SquareColor.TRANSPARENT;
                LigneColor.Add(color);
            }
            mirorGrid.Add(LigneColor);   
        }
        _grid.SetColors(mirorGrid);
    }
    public void PieceGoDown(){
        _grid.SetColors(currentPiece.GoDown(mirorGrid));
    }
    public void PieceGoRight(){
        _grid.SetColors(currentPiece.GoRight(mirorGrid));
    }
    public void PieceGoLeft(){
        _grid.SetColors(currentPiece.GoLeft(mirorGrid));
    }
    public void GameTick(){
        if (currentPiece.isStop){
            if (indexActuelPiece > Pieces.totalPieces){
                indexActuelPiece = 0;
                patternPieces = new Pieces();
            } else {
                indexActuelPiece++;
            }
            currentPiece = patternPieces.allPieces[indexActuelPiece];
        }
        PieceGoDown();
    }

    public void BreakLine() {
        for (int i = _grid.height; i > 0; i--) {
            if (!mirorGrid[i].Contains(SquareColor.TRANSPARENT)) {
                List<SquareColor> LigneColor = new List<SquareColor>();
                for (int j=0;j<_grid.width;j++){
                SquareColor color = SquareColor.TRANSPARENT;
                LigneColor.Add(color);
            }
            mirorGrid.RemoveAt(i);
            mirorGrid.Add(LigneColor);
            }
        }
    }
}