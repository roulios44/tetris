using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*Class that handle the main function of the game (create the  base grid, generate pieces...) */
public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int width = 0;
    private int breakLineCount = 0;
    private int indexActuelPiece = 0;
    public int score = 0;
    private int actualLevel = 1;
    private int totalBreakedLines = 0;
    public Pieces patternPieces = new Pieces();
    protected Piece currentPiece;

    public int GetHeight(){
        return this.height;
    }
    public int GetWidth(){
        return this.width;
    }
    // generate a same size grid of the physical one
    public MirorGrid(){
        this.width = _grid.width;
        this.height = _grid.height;
        currentPiece = patternPieces.allPieces[indexActuelPiece];
        SetGrid();
    }
    // set the grid the game will take place
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
    // set grid color for a piece going down, used to communicate between written code and unity interface
    public void PieceGoDown(){
        _grid.SetColors(currentPiece.GoDown(this));
    }

    // set grid color for a piece going right, used to communicate between written code and unity interface
    public void PieceGoRight(){
        _grid.SetColors(currentPiece.GoRight(this));
    }
    
    // set grid color for a piece going left, used to communicate between written code and unity interface
    public void PieceGoLeft(){
        _grid.SetColors(currentPiece.GoLeft(mirorGrid));
    }

     // set grid color for a piece rotating, used to communicate between written code and unity interface
    public void PieceRotate(){
        currentPiece.RotatePiece(this);
    }

     // set tick for a piece rushing down, used to communicate between written code and unity interface
    public void RushFunction() {
        currentPiece.onRush = true;
        GridDisplay.SetTickTime(0.03f);
    }

    // function used each tick of the game to refresh the grid, and handle the actions.
    public void GameTick(){
        // if the current piece played is stop, tickTime will be settled at 0.3 (base speed) and an other piece will be displayed
        if (currentPiece.isStop){
            GridDisplay.SetTickTime(0.3f-(actualLevel/100));
            indexActuelPiece++;
            if (indexActuelPiece > patternPieces.allPieces.Count - 1){
                indexActuelPiece = 0;
                patternPieces = new Pieces();
            }
            currentPiece = patternPieces.allPieces[indexActuelPiece];
        }
        // basic function to run correctly the game, make a piece go down, compute and refresh the score/level, check if the game is lost
        PieceGoDown();
        BreakLine();
        ScoreCalculator();
        LevelCalculator();
        GridDisplay.SetScore(score);
        GameIsLose();
    }

    // function to verify if the game is still payable or not
    private  void GameIsLose(){
        bool lineIsEmpty = true;
        for (int i = 0; i<mirorGrid[0].Count;i++){
            if (mirorGrid[0][i] != SquareColor.TRANSPARENT)lineIsEmpty = false;
        }
        if ((currentPiece.isStop || !currentPiece.GetCanGoDown()) && !lineIsEmpty)GridDisplay.TriggerGameOver();
        return;
    }

    // function to verify if a line is fully colored or not and delete it in consequences, if so, a new line will be created and added to the grid
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
        switch (breakLineCount){
            case 1:
                score += 40*actualLevel;
                break;
            case 2:
                score += 100*actualLevel;
                break;
            case 3:
                score += 300*actualLevel;
                break;
            case 4:
                score += 1200*actualLevel;
                break;
            default:
                breakLineCount = 0;
                break;
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