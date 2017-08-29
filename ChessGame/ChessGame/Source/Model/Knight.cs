﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.Source.Model {

    class Knight : Piece {

        public Knight(Board board, int color) : base(board, color) {

            base.type = "knight";

            if (color == 0) {
                base.icon = '\u2658';
            } else {
                base.icon = '\u265e'; //might be u265E
            }

        }

        public override void getDestinations(int posX, int posY) {
            //throw new NotImplementedException();

            //jagged array of all 8 possible destinations
            int[][] possibleDestinations = new int[][] {
                new int [] {posX + 1, posY + 2 },
                new int [] {posX - 1, posY + 2 },
                new int [] {posX + 1, posY - 2 },
                new int [] {posX - 1, posY - 2 },
                new int [] {posX + 2, posY + 1 },
                new int [] {posX + 2, posY - 1 },
                new int [] {posX - 2, posY + 1 },
                new int [] {posX - 2, posY - 1 }
            };

            int tmpX;
            int tmpY;
            BoardSpace tmpSpace;

            foreach (int[] pos in possibleDestinations) {

                tmpX = pos[0];
                tmpY = pos[1];

                if (tmpX >= 0 && tmpX < Board.GAMESIZE
                    && tmpY >= 0 && tmpY < Board.GAMESIZE) {

                    tmpSpace = this.Board.getBoardSpace(tmpX, tmpY);
                    tmpSpace.IsPossibleDestination = true;

                }

            }
        }
    }

}
