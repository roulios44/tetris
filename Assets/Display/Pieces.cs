using System.Collections;
using System;
using System.Collections.Generic;

public class Pieces : Piece {
    public int[] RandomTable() {
        List<int> toRandomize = new List<int> ();
        for (int i = 1; i < 8; i++) {
            toRandomize.Add(i);
        }
        List<int> randomOrder = new List<int> ();
        Random rnd = new Random();
        while(toRandomize.Count != 0) {
            int randomArrayPlace = rnd.Next(0, toRandomize.Count);
            randomOrder.Add(toRandomize[randomArrayPlace]);
            toRandomize.RemoveAt(randomArrayPlace);
        }
        return randomOrder.ToArray();
    }
}

