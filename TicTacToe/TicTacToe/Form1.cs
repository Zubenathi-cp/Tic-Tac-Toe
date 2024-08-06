using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        // Enum to represent the two players: X and O
        public enum Player
        {
            X, O
        }

        Player currentPlayer; // Variable to keep track of the current player
        Random random = new Random(); // Random number generator for CPU moves
        int playerWinCount = 0; // Count of player wins
        int cpuWinCount = 0; // Count of CPU wins
        List<Button> buttons; // List to manage buttons in the game

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0) // Check if there are any available buttons
            {
                // Select a random button from the list
                int index = random.Next(buttons.Count);
                // Disable the selected button
                buttons[index].Enabled = false;
                currentPlayer = Player.O; // Set the current player to CPU
                // Set button text and color
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon;
                // Remove the button from the list
                buttons.RemoveAt(index);
                // Check if the game is over
                CheckGame();
                // Stop the timer to prevent CPU from making another move
                CpuTimer.Stop();
            }
        }

        private void PlayerButtonClick(object sender, EventArgs e)
        {
            var button = (Button)sender; // Cast sender to Button
            currentPlayer = Player.X; // Set the current player to X
            // Set button text and color
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            // Remove the button from the list
            buttons.Remove(button);
            // Check if the game is over
            CheckGame();
            // Start the CPU move timer
            CpuTimer.Start();
        }

        private void CheckGame()
        {
            // Check all possible winning combinations for Player X
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button7.Text == "X" && button5.Text == "X" && button3.Text == "X")
            {
                CpuTimer.Stop(); // Stop the CPU timer
                MessageBox.Show("Congratulations! You have won the game!", "Player Wins", MessageBoxButtons.OK, MessageBoxIcon.Information); // Notify player of victory
                playerWinCount++; // Increment player win count
                label1.Text = "Player wins: " + playerWinCount; // Update player win label
                RestartGame(); // Restart the game
            }
            // Check all possible winning combinations for CPU (O)
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button7.Text == "O" && button5.Text == "O" && button3.Text == "O")
            {
                CpuTimer.Stop(); // Stop the CPU timer
                MessageBox.Show("The CPU has won the game. Better luck next time!", "CPU Wins", MessageBoxButtons.OK, MessageBoxIcon.Information); // Notify CPU win
                cpuWinCount++; // Increment CPU win count
                label2.Text = "CPU wins: " + cpuWinCount; // Update CPU win label
                RestartGame(); // Restart the game
            }
            // Check for a tie
            else if (buttons.All(button => button.Enabled == false))
            {
                CpuTimer.Stop(); // Stop the CPU timer
                MessageBox.Show("It's a tie! No one wins this round.", "Game Tied", MessageBoxButtons.OK, MessageBoxIcon.Information); // Notify players of a tie
                RestartGame(); // Restart the game
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame(); // Call the RestartGame method
        }

        private void RestartGame()
        {
            // Initialize button list
            buttons = new List<Button>
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9
            };

            // Reset all buttons to their initial state
            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}

