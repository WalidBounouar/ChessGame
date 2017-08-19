using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Bishop : Piece {

        public Bishop(Board board, int color) : base(board, color) {

            base.type = "bishop";

            if (color == 0) {
                base.icon = '\u2657';
            } else {
                base.icon = '\u265d'; //might be u265D
            }

        }

        public override void getDestinations(int posX, int posY) {
            throw new NotImplementedException();
        }
    }

}
