using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    struct BoardSpace {

        /// <summary>
        /// Boolean showing if the BoardSpace is occupied by a Piece.
        /// </summary>
        private bool occupied;

        /// <summary>
        /// Access to occupied variable. Get and Set.
        /// </summary>
        public bool Occupied {
            get { return occupied; }
            set { occupied = value; }
        }

        /// <summary>
        /// The Piece that occupies the BoardSpace.
        /// </summary>
        private Piece piece;

        /// <summary>
        /// Access to the BoardSpace's Piece. Get and Set.
        /// </summary>
        public Piece Piece {
            get { return piece;  }
            set {
                piece = value;

                if (value == null) {
                    this.occupied = false;
                } else {
                    this.occupied = true;
                }
            }
        }

        /// <summary>
        /// Shows if the BoardSpace is a possible destination.
        /// Will be used when a Piece is determining where it can land
        /// when a player wants to move it.
        /// </summary>
        private bool isPossibleDestination;

        /// <summary>
        /// Access to isPossibleDestination variable. Get and Set.
        /// </summary>
        public bool IsPossibleDestination {
            get { return isPossibleDestination; }
            set { isPossibleDestination = value; }
        }

        /// <summary>
        /// Method that gives appropriate character depending on the state
        /// of the BoardSpace.
        /// Occupied and a destination --> X
        /// Occupied only --> icon of the Piece
        /// Destination only --> x
        /// else --> a space
        /// </summary>
        /// <returns> The appriate char reprsenting the state of the BoardSpace.</returns>
        public char getBoardSpaceChar() {

            char output = '-';

            if (this.occupied) {
                output = this.piece.Icon;
            }

            return output;
        }

        /*
        /// <summary>
        /// Constructor in case the BoardSpace is created with a Piece.
        /// </summary>
        /// <param name="piece"> The Piece that will occupy the BoardSpace.</param>
        public BoardSpace(Piece piece) {

            this.isPossibleDestination = false;
            this.piece = piece;
            this.occupied = false;
            
            if (piece != null) {      //Maybe revise
                this.occupied = true;
            }

        }
        */

    }

}
