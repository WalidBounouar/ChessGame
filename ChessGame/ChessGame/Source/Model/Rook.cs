using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Rook : Piece {

        public Rook(Board board, int color) : base(board, color) {

            base.type = "rook";

            if (color == 0) {
                base.icon = '\u2656';
            } else {
                base.icon = '\u265c'; //might be u265C
            }

        }

        public override void getDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

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

        }
    }

}
