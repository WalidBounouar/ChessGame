using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class Board {

        /// <summary>
        /// Jagged array of BoardSpace representing the game board.
        /// [0][0] is bottom left --> a1
        /// [0][7] is top left --> a8
        /// [7][0] is bottom right --> h1
        /// [7][7] is top right --> h8
        /// </summary>
        private BoardSpace[][] board;

        /// <summary>
        /// Dictionaries containing the dead Piece.
        /// A Dictionary might be overkill, but I wanted to play with Collections.
        /// Key will be the Piece's type (string)
        /// </summary>
        private Dictionary<string, Piece> deadBlacks;
        private Dictionary<string, Piece> deadWhites;

        /// <summary>
        /// NOT FINAL, TO DO
        /// </summary>
        public Board() {

            this.board = new BoardSpace[8][];
            for (int i = 0; i < this.board.Length; i++) {
                this.board[i] = new BoardSpace[8];
            }

        }

        public BoardSpace getBoardSpace(int posX, int posY) {
            return this.board[posX][posY];
        }

        private void killPiece(int posX, int posY) {

            Piece tmp = this.board[posX][posY].Piece;
            int color = tmp.Color;
            tmp.Alive = false;

            if (color == 0) {
                this.deadWhites.Add(tmp.Type, tmp);
            } else {
                this.deadBlacks.Add(tmp.Type, tmp);
            }

            this.board[posX][posY].Piece = null; //maybe replace by a custom method
            this.board[posX][posY].Occupied = false; //maybe replace by a custom method
            this.board[posX][posY].IsPossibleDestination = false; //remove if you take care during view update method

        }

    }

}
