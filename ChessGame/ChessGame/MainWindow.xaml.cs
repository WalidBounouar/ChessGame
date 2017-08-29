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

        /// <summary>
        /// 0 --> choose a piece
        /// 1 --> choose a destination
        /// </summary>
        private int mode;

        /// <summary>
        /// Last pressed button
        /// </summary>
        private BoardButton lastPressed;

        public MainWindow() {

            InitializeComponent();

            this.boardModel = new Board();
            Debug.WriteLine(this.boardModel.toString()); //REMOVE WHEN DONE

            this.mode = 0;//default start by chosing a piece

            this.turn = 0; //white starts
            this.showTurn();

            this.updateDeadPiecesViews();

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
                    this.buttonArray[i][j] = presentButton;
                    
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

        /// <summary>
        /// Updated the view to show who's turn it is.
        /// </summary>
        private void showTurn() {

            if (this.turn == 0) {
                this.turnDisplay.Text = "White Turn";
            } else {
                this.turnDisplay.Text = "Black Turn";
            }

        }

        private void boardButton_Click(object sender, RoutedEventArgs e) {
            //throw new NotImplementedException();            

            BoardButton clickedButton = sender as BoardButton;
            Debug.WriteLine(clickedButton.Name);//REMOVE

            int x = clickedButton.PosX;
            int y = clickedButton.PosY;

            BoardSpace clickedSpace = this.boardModel.getBoardSpace(x, y);

            if (this.mode == 0) { //mode 0 --> chose piece

                clickedSpace.Piece.getDestinations(x, y);
                this.mode = (this.mode + 1) % 2;
                this.lastPressed = clickedButton;

            } else { // other mode is chose destinations

                this.movePiece(clickedSpace);
                this.lastPressed = null;

                this.mode = (this.mode + 1) % 2;
                this.turn = (this.turn + 1) % 2;//. only change tuen after destination chosen.

            }

            this.updateView();
            Debug.WriteLine(this.boardModel.toString());//REMOVE

        }

        private void movePiece(BoardSpace destination) {

            if (destination.Occupied) {
                this.boardModel.killPiece(destination);
            }

            int sourceX = this.lastPressed.PosX;
            int sourceY = this.lastPressed.PosY;
            BoardSpace sourceSpace = this.boardModel.getBoardSpace(sourceX, sourceY);

            destination.Piece = sourceSpace.Piece; //move Piece, auto set Occupied to true

            sourceSpace.Piece = null;//auto set Occupied to false

        }

        private void updateView() {

            this.showTurn();

            this.updateDeadPiecesViews();

            //updating board.
            for (int i = 0; i < this.buttonArray.Length; i++) {
                for (int j = 0; j < this.buttonArray.Length; j++) {

                    BoardButton presentButton = this.buttonArray[i][j];
                    BoardSpace presentSpace = this.boardModel.getBoardSpace(i, j); //MAYBE REPLACE BY GETTER

                    if (mode == 0) { //if mode is now chose piece, we clear the possible distinations.
                        presentButton.ClearValue(BoardButton.BackgroundProperty); //clears background color
                        presentSpace.IsPossibleDestination = false;
                    }

                    if (presentSpace.IsPossibleDestination) {
                        presentButton.Background = Brushes.Red;
                    }

                    if (!presentSpace.IsPossibleDestination 
                        && ( !presentSpace.Occupied 
                             || presentSpace.Piece.Color != this.turn) ) {

                        presentButton.IsEnabled = false;

                    } else {
                        presentButton.IsEnabled = true;
                    }

                    presentButton.Content = presentSpace.getBoardSpaceChar();

                    Debug.WriteLine(presentSpace.toString());//REMOVE
                    
                }

            }

        }
        
        /// <summary>
        /// Updated the TextBlocks that shows the dead Pieces.
        /// </summary>
        private void updateDeadPiecesViews() {


            StringBuilder deadWhitesString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadWhites) {
                deadWhitesString.Append(" " + piece.Icon + " ");
            }

            this.deadWhitesView.Text = deadWhitesString.ToString();

            StringBuilder deadBlacksString = new StringBuilder();

            foreach (Piece piece in this.boardModel.DeadBlacks) {
                deadBlacksString.Append(" " + piece.Icon + " ");
            }

            this.deadBlacksView.Text = deadBlacksString.ToString();
        }

    }

}
