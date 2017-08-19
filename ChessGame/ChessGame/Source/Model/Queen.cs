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
            throw new NotImplementedException();
        }
    }

}
