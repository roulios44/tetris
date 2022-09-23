using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int widht = 0;
    private Piece test = new Piece();
    public void SetGridBackground(){
        height = _grid.height;
        widht = _grid.width;
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
    public void GeneratePiece(){

    }
    public void GameTest(){
        for (int i = 0; i<test.ArrayX.Count;i++){
            if (test.ArrayX[i] < 21){
                mirorGrid[test.ListY[i]][test.ListX[i]] = SquareColor.GREEN;
                test.ChangeListY(i,test.ArrayY[i]+1);
                mirorGrid[test.ListY[i]][test.ListX[i]] = SquareColor.RED;
            }
        }
        _grid.SetColors(mirorGrid);
    }
}