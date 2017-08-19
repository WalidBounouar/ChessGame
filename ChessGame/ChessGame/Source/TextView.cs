using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class TextView {

        Board board;

        GameController controller;

        public TextView(Board board, GameController controller) {

            this.board = board;
            this.controller = controller;

        }

    }

}
