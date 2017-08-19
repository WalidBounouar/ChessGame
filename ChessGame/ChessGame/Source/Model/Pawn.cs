using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class Pawn : Piece {

        public Pawn(Board board, int color) : base(board, color) {

            base.type = "pawn";

            if (color == 0) {
                base.icon = '\u2659';
            } else {
                base.icon = '\u265f'; //might be u265F
            }

        }

        public override void getDestinations(int posX, int posY) {
            throw new NotImplementedException();
        }
    }

}
