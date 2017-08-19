using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Knight : Piece {

        public Knight(Board board, int color) : base(board, color) {

            base.type = "knight";

            if (color == 0) {
                base.icon = '\u2658';
            } else {
                base.icon = '\u265e'; //might be u265E
            }

        }

        public override void getDestinations(int posX, int posY) {
            throw new NotImplementedException();
        }
    }

}
