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

        public MainWindow() {

            InitializeComponent();

            this.boardModel = new Board();
            Debug.WriteLine(this.boardModel.toString());

        }
        
    }

}
