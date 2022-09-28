using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Pieces {
    public int[] orderPiece;
    public static int totalPieces = 7;
    public List<Piece> allPieces = new List<Piece>();
    public Pieces() {
        List<int> toRandomize = new List<int> ();
        for (int i = 0; i < totalPieces; i++) {
            toRandomize.Add(i);
        }
        List<int> randomOrder = new List<int> ();
        System.Random rnd = new System.Random();
        while(toRandomize.Count != 0) {
            int randomArrayPlace = rnd.Next(0, toRandomize.Count);
            randomOrder.Add(toRandomize[randomArrayPlace]);
            toRandomize.RemoveAt(randomArrayPlace);
        }
        orderPiece = randomOrder.ToArray();
        setPiecesOrder();
    }
    public void setPiecesOrder(){
        allPieces = new List<Piece>();
        List<Piece> pieceInOrder = new List<Piece>();
        pieceInOrder.Add(new IPiece());
        pieceInOrder.Add(new TPiece());
        pieceInOrder.Add(new OPiece());
        pieceInOrder.Add(new ZPiece());
        pieceInOrder.Add(new SPiece());
        pieceInOrder.Add(new LPiece());
        pieceInOrder.Add(new JPiece());
        for (int i = 0;i<orderPiece.Length;i++){
            allPieces.Add(pieceInOrder[orderPiece[i]]);
        }
    }
}