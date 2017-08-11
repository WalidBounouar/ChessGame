using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source {

     abstract class Piece {

        /// <summary>
        /// The Board on which the Piece exists.
        /// </summary>
        private Board board;

        /// <summary>
        /// The type of Piece : rook, queen, king, etc.
        /// </summary>
        private string type;
        
        /// <summary>
        /// Access to type variable. Get only.
        /// </summary>
        public string Type {
            get { return type; }
        }

        /// <summary>
        /// The character user to represent the Piece.
        /// </summary>
        private char icon;

        /// <summary>
        /// Access to icon variable. Get Only.
        /// </summary>
        public char Icon {
            get { return icon;  }
        }

        /// <summary>
        /// The state of the piece.
        /// true --> on board
        /// false --> off board
        /// </summary>
        private bool alive;

        /// <summary>
        /// Access to alive variable.
        /// </summary>
        public bool Alive {
            get { return alive; }
            set { alive = value;  }
        }

        /// <summary>
        /// The color of the Piece
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int color;

        /// <summary>
        /// Access to color variable. Get only.
        /// </summary>
        public int Color {
            get { return color; }
        }

        /// <summary>
        /// Constructor for a Piece.
        /// </summary>
        /// <param name="board"> The Board on which the Piece exists. </param>
        /// <param name="type"> The type of piece : rook, queen, king, etc. </param>
        /// <param name="icon"> The character user to represent the Piece. </param>
        /// <param name="color"> The color of the Piece. 0 --> white and 1 --> black </param>
        public Piece(Board board, string type, char icon, int color ) {

            this.board = board;
            this.type = type;
            this.icon = icon;
            this.color = color;
            this.alive = true; //By default, a Piece is alive when created.

        }

        /// <summary>
        /// Returns all the possible position for the piece depending on the
        /// position given as an argument.
        /// </summary>
        /// <param name="position"> Array with x and y value of piece's position </param>
        /// <returns>A jagged array of all the possible positions for the piece</returns>
        public abstract int[][] getDestinations(int[] position);

    }

}
