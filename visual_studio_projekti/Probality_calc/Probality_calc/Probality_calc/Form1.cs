using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace Probality_calc
{
    public partial class Form1 : Form
    {
        private int panelOffsetX = 10; // This will track the starting position for the next panel horizontally
        private int panelOffsetY = 10; // Vertical offset for the next row
        private const int spaceBetweenPanels = 10; // Space between panels horizontally and vertically

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach event handler to buttons
            Coin.Click += AddInfoBox_Click;
            D6.Click += AddInfoBox_Click;
            D12.Click += AddInfoBox_Click;
            D21.Click += AddInfoBox_Click;
            D40.Click += AddInfoBox_Click;
            D60.Click += AddInfoBox_Click;
            Clear.Click += Clear_Click;
        }
        private void Coin_Click(object sender, EventArgs e)
        {

        }
        private void D6_Click(object sender, EventArgs e)
        {

        }
        private void D12_Click(object sender, EventArgs e)
        {

        }

        private void D21_Click(object sender, EventArgs e)
        {

        }

        private void D40_Click(object sender, EventArgs e)
        {

        }

        private void D60_Click(object sender, EventArgs e)
        {

        }

        private void AddInfoBox_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            // Create a new Info Box (Panel)
            Panel infoBox = new Panel
            {
                Size = new Size(150, 50),
                BackColor = Color.LightGray,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Create a Label inside the Panel
            Label infoLabel = new Label
            {
                Text = $"Event: {clickedButton.Name}",
                AutoSize = true,
                Location = new Point(10, 10)
            };

            infoBox.Controls.Add(infoLabel);

            // Check if the next panel will exceed the EventBoard width
            if (panelOffsetX + infoBox.Width > EventBoard.Width)
            {
                // Move to the next row if it exceeds the width
                panelOffsetX = 10; // Reset to the start of the new row
                panelOffsetY += infoBox.Height + spaceBetweenPanels; // Move down by the height of the panel plus space
            }

            // Set the panel's location
            infoBox.Location = new Point(panelOffsetX, panelOffsetY);

            // Add the new panel to the EventBoard
            EventBoard.Controls.Add(infoBox);

            // Update panelOffsetX for the next panel (move to the right)
            panelOffsetX += infoBox.Width + spaceBetweenPanels; // Add space between panels horizontally
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            // Create a list to hold panels to be removed
            List<Control> controlsToRemove = new List<Control>();

            // Add all Panels from EventBoard to the list
            foreach (Control control in EventBoard.Controls)
            {
                if (control is Panel)
                {
                    controlsToRemove.Add(control);
                }
            }

            // Remove the panels from EventBoard after collecting them in the list
            foreach (Control control in controlsToRemove)
            {
                EventBoard.Controls.Remove(control);
                control.Dispose(); // Dispose of the panels to free resources
            }

            // Reset panelOffsetX and panelOffsetY for when new panels are added
            panelOffsetX = 10;
            panelOffsetY = 10;
        }

        private void Calculate_Click(object sender, EventArgs e)
        {

        }
    }
}