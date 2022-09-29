using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int width = 0;
    private int indexActuelPiece = 0;
    public Pieces patternPieces = new Pieces();
    protected Piece currentPiece;
    public int getHeight(){
        return this.height;
    }
    public int getWidht(){
        return this.width;
    }
    public MirorGrid(){
        this.width = _grid.width;
        this.height = _grid.height;
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
        _grid.SetColors(currentPiece.GoDown(this));
    }
    public void PieceGoRight(){
        _grid.SetColors(currentPiece.GoRight(this));
    }
    public void PieceGoLeft(){
        _grid.SetColors(currentPiece.GoLeft(mirorGrid));
    }
    public void GameTick(){
        if (currentPiece.isStop){
            indexActuelPiece++;
            if (indexActuelPiece > 6){
                indexActuelPiece = 0;
                patternPieces = new Pieces();
            }
            currentPiece = patternPieces.allPieces[indexActuelPiece];
        }
        PieceGoDown();
        BreakLine();
    }

    public void BreakLine() {
        for (int i = 0; i < _grid.height; i++) {
            if (!mirorGrid[i].Contains(SquareColor.TRANSPARENT)) {
                List<SquareColor> LigneColor = new List<SquareColor>();
                for (int j=0;j<_grid.width;j++){
                SquareColor color = SquareColor.TRANSPARENT;
                LigneColor.Add(color);
            }
            mirorGrid.RemoveAt(i);
            mirorGrid.Insert(0, LigneColor);
            }
        }
    }
}