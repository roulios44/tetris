using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int width = 0;
    private int breakLineCount = 0;
    private int indexActuelPiece = 0;
    public int score = 0;
    private int actualLevel = 1;
    private int totalBreakedLines = 9;
    public Pieces patternPieces = new Pieces();
    protected Piece currentPiece;
    public int GetHeight(){
        return this.height;
    }
    public int GetWidth(){
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

    public void PieceRotate(){
        currentPiece.RotatePiece(this);
    }

    public void RushFunction() {
        currentPiece.onRush = true;
        GridDisplay.SetTickTime(0.03f);
    }

    public void GameTick(){
        if (currentPiece.isStop){
            GridDisplay.SetTickTime(0.3f-(actualLevel/100));
            indexActuelPiece++;
            if (indexActuelPiece > patternPieces.allPieces.Count - 1){
                indexActuelPiece = 0;
                patternPieces = new Pieces();
            }
            currentPiece = patternPieces.allPieces[indexActuelPiece];
        }
        PieceGoDown();
        BreakLine();
        ScoreCalculator();
        LevelCalculator();
        GridDisplay.SetScore(score);
        GameIsLose();
    }

    private  void GameIsLose(){
        bool lineIsEmpty = true;
        for (int i = 0; i<mirorGrid[0].Count;i++){
            if (mirorGrid[0][i] != SquareColor.TRANSPARENT)lineIsEmpty = false;
        }
        if ((currentPiece.isStop || !currentPiece.GetCanGoDown()) && !lineIsEmpty)GridDisplay.TriggerGameOver();
        return;
    }

    public void BreakLine() {
        if (currentPiece.isStop) {
            for (int i = 0; i < _grid.height; i++) {
                if (!mirorGrid[i].Contains(SquareColor.TRANSPARENT)) {
                    List<SquareColor> LigneColor = new List<SquareColor>();
                    for (int j=0;j<_grid.width;j++){
                        SquareColor color = SquareColor.TRANSPARENT;
                        LigneColor.Add(color);
                        }
                        mirorGrid.RemoveAt(i);
                        mirorGrid.Insert(0, LigneColor);
                        breakLineCount += 1;
                        totalBreakedLines += 1;
                        }
                    }
            }
    }

    public void ScoreCalculator() {
        if (currentPiece.onRush) {
            score += 1*actualLevel;
        }
        if (breakLineCount == 1) {
            score += 40*actualLevel;
        } else if (breakLineCount == 2) {
            score += 100*actualLevel;
        } else if (breakLineCount == 3) {
            score += 300*actualLevel;
        } else if (breakLineCount == 4) {
            score += 1200*actualLevel;
        }
        breakLineCount = 0;
    }

    public void LevelCalculator() {
        if (totalBreakedLines == 10) {
            actualLevel +=1;
            totalBreakedLines = 0;
        }
    }
}