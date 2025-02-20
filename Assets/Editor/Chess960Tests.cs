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
            GameManager gameManager = new GameManager();
            gameManager.board = new Chess.Board();

            gameManager.board.LoadNewChess960();

            // Use the Assert class to test conditions
            Assert.IsTrue(gameManager.board.rooks[0].occupiedSquares[0] < gameManager.board.KingSquare[0] && gameManager.board.rooks[0].occupiedSquares[1] > gameManager.board.KingSquare[0]);
        }

		[Test]
		public void Chess960BishopsAreOnDifferentColors()
		{
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			gameManager.board.LoadNewChess960();

            // Use the Assert class to test conditions
            Assert.IsTrue(gameManager.board.bishops[0].occupiedSquares[0] % 2 != gameManager.board.bishops[0].occupiedSquares[1] % 2);
		}

		[Test]
		public void Chess960PawnsAreNotInTheBackRow()
		{
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			gameManager.board.LoadNewChess960();

			// Use the Assert class to test conditions
			foreach (var space in gameManager.board.pawns[0].occupiedSquares)
			{
				Assert.IsFalse(space == 0 || space == 1 || space == 2 || space == 3 || space == 4 || space == 5 || space == 6 || space == 7);
			}
		}

		[Test]
		public void Chess960KingIsNotInTheFrontRow()
		{
			GameManager gameManager = new GameManager();
			gameManager.board = new Chess.Board();

			gameManager.board.LoadNewChess960();

			// Use the Assert class to test conditions
			int space = gameManager.board.KingSquare[0];
			Assert.IsFalse(space == 8 || space == 9 || space == 10 || space == 11 || space == 12 || space == 13 || space == 14 || space == 15);
		}
	}
}
