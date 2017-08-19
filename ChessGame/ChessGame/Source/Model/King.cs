using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class King : Piece {

        public King(Board board, int color) : base(board, color) {

            base.type = "king";

            if (color == 0) {
                base.icon = '\u2654';
            } else {
                base.icon = '\u265a'; //might be u265A
            }

        }

        public override void getDestinations(int posX, int posY) {
            throw new NotImplementedException();
        }
    }

}
