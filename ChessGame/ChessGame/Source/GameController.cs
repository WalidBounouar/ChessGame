using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

    class GameController {

        /// <summary>
        /// Game model - Board class
        /// </summary>
        private Board board;

        /// <summary>
        /// Texy View
        /// </summary>
        private TextView textView;

        /// <summary>
        /// The player at the moment
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int turn;

        public GameController() {

            this.board = new Board();
            this.textView = new TextView(this.board, this);

            this.turn = 0; //white starts

        }



    }

}
