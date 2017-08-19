using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class Board {

        /// <summary>
        /// Variable showing size of game. Constant.
        /// </summary>
        public const int GAMESIZE = 8;

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
        /// Board contructor.
        /// </summary>
        public Board() {

            //initializing the dictionaries (deadpieces)
            this.deadBlacks = new Dictionary<string, Piece>();
            this.deadWhites = new Dictionary<string, Piece>();

            //initializing the jagged array
            this.board = new BoardSpace[Board.GAMESIZE][];
            for (int i = 0; i < this.board.Length; i++) {
                this.board[i] = new BoardSpace[Board.GAMESIZE];
            }

            //initializing the rooks
            this.board[0][0].Piece = new Rook(this, 0); //BoardSpace occupied variable is automatically set to true here.
            this.board[7][0].Piece = new Rook(this, 0);
            this.board[0][7].Piece = new Rook(this, 1);
            this.board[7][7].Piece = new Rook(this, 1);

            //initializing the knights
            this.board[1][0].Piece = new Knight(this, 0);
            this.board[6][0].Piece = new Knight(this, 0);
            this.board[1][7].Piece = new Knight(this, 1);
            this.board[6][7].Piece = new Knight(this, 1);

            //initializing the bishops
            this.board[2][0].Piece = new Bishop(this, 0);
            this.board[5][0].Piece = new Bishop(this, 0);
            this.board[2][7].Piece = new Bishop(this, 1);
            this.board[5][7].Piece = new Bishop(this, 1);

            //initializing the queens
            this.board[3][0].Piece = new Queen(this, 0);
            this.board[3][7].Piece = new Queen(this, 1);

            //initializing the kings
            this.board[4][0].Piece = new King(this, 0);
            this.board[4][7].Piece = new King(this, 1);

            //initializing the pawns
            for (int i = 0; i < Board.GAMESIZE; i++) {
                this.board[i][1].Piece = new Pawn(this, 0);
            }

            for (int i = 0; i < Board.GAMESIZE; i++) {
                this.board[i][6].Piece = new Pawn(this, 1);
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
