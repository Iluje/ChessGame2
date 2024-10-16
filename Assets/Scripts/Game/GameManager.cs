using System;
using System.Collections;
using System.Collections.Generic;
using Script.Pieces;
using UnityEngine;
using Utils;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private Piece WhitePawn;
    [SerializeField] private Piece WhiteKing;
    [SerializeField] private Piece WhiteQueen;
    [SerializeField] private Piece WhiteRook;
    [SerializeField] private Piece WhiteKnight;
    [SerializeField] private Piece WhiteBishop;
    
    [SerializeField] private Piece BlackPawn;
    [SerializeField] private Piece BlackKing;
    [SerializeField] private Piece BlackQueen;
    [SerializeField] private Piece BlackRook;
    [SerializeField] private Piece BlackKnight;
    [SerializeField] private Piece BlackBishop;

    [SerializeField] private GameObject _pieceParent;
    [SerializeField] private GameObject _piecePrefab;
    [SerializeField] private GameObject _emptyPrefab;

    public Piece[,] Pieces;

    private void Start()
    {
        Pieces = new Piece[,]
        {
            { BlackRook, BlackKnight, BlackBishop, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook },
            { BlackPawn, BlackPawn, BlackPawn, BlackPawn, BlackPawn, BlackPawn, BlackPawn, BlackPawn },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn, WhitePawn },
            { WhiteRook, WhiteKnight, WhiteBishop, WhiteKing, WhiteQueen, WhiteBishop, WhiteKnight, WhiteRook },
        };
        
        DisplayMatrix();
    }

    public void DisplayMatrix()
    {
        for (int x = 0; x < Pieces.GetLength(0); x++)
        {
            for (int y = 0; y < Pieces.GetLength(1); y++)
            {

                GameObject NewPiece;
                
                if (Pieces[x,y] != null)
                {
                   NewPiece = Instantiate(_piecePrefab, _pieceParent.transform);
                   NewPiece.GetComponent<PieceHandler>().Setup(Pieces[x,y], new Vector2Int(x,y));
                }
                else
                {
                    NewPiece = Instantiate(_emptyPrefab, _pieceParent.transform);
                    NewPiece.GetComponent<PieceHandler>().SetupEmpty(new Vector2Int(x, y));
                }
                
            }
        }
    }
}
