using System.Collections.Generic;

public class Piece{
    public List<int> ListX = new List<int>(new int[] {5,6,7,8});
    public List<int> ListY = new List<int> (new int[] {1,1,1,1});

    public void ChangeListX(int index, int value){
        ListX[index] = value;
    }
    public void ChangeListY(int index, int value){
        ListY[index] = value;
    }
}