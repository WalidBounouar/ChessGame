using ChessGame.Source;
using ChessGame.Source.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessGame {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        /// <summary>
        /// Game model - Board class
        /// </summary>
        private Board boardModel;

        /// <summary>
        /// The player at the moment
        /// 0 --> white
        /// 1 --> black
        /// </summary>
        private int turn;

        /// <summary>
        /// Jagged array for all the buttons on the board.
        /// </summary>
        private BoardButton[][] buttonArray;

        public MainWindow() {

            InitializeComponent();

            this.boardModel = new Board();
            Debug.WriteLine(this.boardModel.toString()); //REMOVE WHEN DONE

            this.turn = 0; //white starts

            //initializing the buttonArray
            this.buttonArray = new BoardButton[Board.GAMESIZE][]; //Change Game size
            for (int i = 0; i < this.buttonArray.Length; i++) {
                this.buttonArray[i] = new BoardButton[Board.GAMESIZE];
            }

            //creating the buttons for the board.
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    string name = "space" + i + j;

                    BoardSpace correspondingSpace = this.boardModel.getBoardSpace(i, j);

                    BoardButton presentButton = new BoardButton(i, j, name, correspondingSpace);
                    
                    if (!correspondingSpace.Occupied
                        || correspondingSpace.Piece.Color != this.turn) {

                        presentButton.IsEnabled = false;

                    }

                    int realJ = (j - this.buttonArray.Length + 1) * -1; //to fix grid y axis problem

                    Grid.SetColumn(presentButton, i);
                    Grid.SetRow(presentButton, realJ);
                    this.boardGrid.Children.Add(presentButton);

                    presentButton.AddHandler(BoardButton.ClickEvent, new RoutedEventHandler(boardButton_Click)); //Adding eventHandler

                }

            }

        }

        void boardButton_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();            

            BoardButton clickedButton = sender as BoardButton;
            Debug.WriteLine(clickedButton.Name);
            

        }

    }

}
