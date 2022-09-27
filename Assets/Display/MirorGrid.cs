using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MirorGrid{
    public List<List<SquareColor>> mirorGrid = new List<List<SquareColor>>();
    private _GridDisplay _grid = GameObject.FindObjectOfType<_GridDisplay>();
    private int height = 0;
    private int widht = 0;
    private int test = 10;
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
        if (test < 21){
            mirorGrid[test][3] = SquareColor.GREEN;
            test++;
            mirorGrid[test][3] = SquareColor.RED;
            _grid.SetColors(mirorGrid);
        }
    }
}