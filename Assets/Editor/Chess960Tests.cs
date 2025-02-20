using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Chess.Game;
using System.Runtime.InteropServices;

namespace Tests
{
	public class Chess960Tests
	{
		[Test]
		public void Chess960KingBetweenRooks()
		{
			// Create a new GameManager and Chess board
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			// Generate a new Chess960 position
			gameManager.board.LoadNewChess960();

			// Verify that the king is positioned between the two rooks
			Assert.IsTrue(gameManager.board.rooks[0].occupiedSquares[0] < gameManager.board.KingSquare[0] && gameManager.board.rooks[0].occupiedSquares[1] > gameManager.board.KingSquare[0]);
		}

		[Test]
		public void Chess960BishopsAreOnDifferentColors()
		{
			// Create a new GameManager and Chess board
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			// Generate a new Chess960 position
			gameManager.board.LoadNewChess960();

			// Verify that the two bishops are on different color squares
			Assert.IsTrue(gameManager.board.bishops[0].occupiedSquares[0] % 2 != gameManager.board.bishops[0].occupiedSquares[1] % 2);
		}

		[Test]
		public void Chess960PawnsAreNotInTheBackRow()
		{
			// Create a new GameManager and Chess board
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			// Generate a new Chess960 position
			gameManager.board.LoadNewChess960();

			// Ensure no pawns are located in the back row
			foreach (var space in gameManager.board.pawns[0].occupiedSquares)
			{
				Assert.IsFalse(space == 0 || space == 1 || space == 2 || space == 3 || space == 4 || space == 5 || space == 6 || space == 7);
			}
		}

		[Test]
		public void Chess960KingIsNotInTheFrontRow()
		{
			// Create a new GameManager and Chess board
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			// Generate a new Chess960 position
			gameManager.board.LoadNewChess960();

			// Ensure the king is not in the front row (row 2 for white, row 7 for black)
			int space = gameManager.board.KingSquare[0];
			Assert.IsFalse(space == 8 || space == 9 || space == 10 || space == 11 || space == 12 || space == 13 || space == 14 || space == 15);
		}
	}
}

