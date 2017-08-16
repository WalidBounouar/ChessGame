using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class Pawn : Piece {

        public Pawn(Board board, string type, char icon, int color) : base(board, type, icon, color) {
        }

        public override void getDestinations(int posX, int posY) {
            throw new NotImplementedException();
        }
    }

}
