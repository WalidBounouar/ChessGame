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
            throw new NotImplementedException();
        }
    }

}
