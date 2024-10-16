using System;
using System.Collections;
using System.Collections.Generic;
using Script.Pieces;
using UnityEngine;
using UnityEngine.UI;

public class PieceHandler : MonoBehaviour
{
    private Vector2Int _position;
    private Image _pieceImage;
    private Piece _piece;
    
    public void Setup(Piece piece, Vector2Int position)
    {
        _piece = piece;
        _position = position;
        _pieceImage.sprite = piece.sprite;
    }

    public void SetupEmpty(Vector2Int position)
    {
        _position = position;
    }
}
