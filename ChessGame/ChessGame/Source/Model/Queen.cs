using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Queen : Piece {

        public Queen(Board board, int color) : base(board, color) {

            base.type = "queen";

            if (color == 0) {
                base.icon = '\u2655';
            } else {
                base.icon = '\u265b'; //might be u265B
            }

        }

        public override void getDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            //Up, down, left and right searches are copies of the Rook method

            //up seach
            tmpX = posX;
            tmpY = posY + 1;

            while (tmpY < Board.GAMESIZE
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpY < Board.GAMESIZE
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down seach
            tmpX = posX;
            tmpY = posY - 1;

            while (tmpY >= 0
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpY >= 0
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //right seach
            tmpX = posX + 1;
            tmpY = posY;

            while (tmpX < Board.GAMESIZE
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GAMESIZE
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //left seach
            tmpX = posX - 1;
            tmpY = posY;

            while (tmpX >= 0
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //Diagonal searches are copies of Bishop method

            //up right diagonal
            tmpX = posX + 1;
            tmpY = posY + 1;

            while (tmpX < Board.GAMESIZE
                && tmpY < Board.GAMESIZE
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GAMESIZE
                && tmpY < Board.GAMESIZE
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //up left diagonal
            tmpX = posX - 1;
            tmpY = posY + 1;

            while (tmpX >= 0
                && tmpY < Board.GAMESIZE
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY++;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && tmpY < Board.GAMESIZE
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down right diagonal
            tmpX = posX + 1;
            tmpY = posY - 1;

            while (tmpX < Board.GAMESIZE
                && tmpY >= 0
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX++;
                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX < Board.GAMESIZE
                && tmpY >= 0
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

            //down left diagonal
            tmpX = posX - 1;
            tmpY = posY - 1;

            while (tmpX >= 0
                && tmpY >= 0
                && !this.Board.getBoardSpace(tmpX, tmpY).Occupied) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

                tmpX--;
                tmpY--;

            }
            //Check in case the loop stoped because we found occupied space
            if (tmpX >= 0
                && tmpY >= 0
                && this.Board.getBoardSpace(tmpX, tmpY).Occupied
                && this.Board.getBoardSpace(tmpX, tmpY).Piece.Color != this.Color) {

                tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                tmpSpace.IsPossibleDestination = true;

            }

        }
    }

}
