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
            // jsonSerializer
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

            InitializeSettingsPanel();
        }

        //suurin osa Click functioista on vain sen takia että ilman niitä tulee erroreja
        private void Coin_Click(object sender, EventArgs e) 
        {
            var D2 = new Dice("D2", 2);
            DiceStorage.diceList.Add(D2);
        }
        private void D6_Click(object sender, EventArgs e) 
        {
            var D6 = new Dice("D6", 6);
            DiceStorage.diceList.Add(D6);
        }
        private void D12_Click(object sender, EventArgs e) 
        {
            var D12 = new Dice("D12", 12);
            DiceStorage.diceList.Add(D12);
        }
        private void D21_Click(object sender, EventArgs e) 
        {
            var D21 = new Dice("D21", 21);
            DiceStorage.diceList.Add(D21);
        }
        private void D40_Click(object sender, EventArgs e) 
        {
            var D40 = new Dice("D40", 40);
            DiceStorage.diceList.Add(D40);
        }
        private void D60_Click(object sender, EventArgs e) 
        {
            var D60 = new Dice("D60", 60);
            DiceStorage.diceList.Add(D60);
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
            DiceStorage.diceList.Clear();
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
            // muuttaa paremmaks myöhemmin
            AnsInfo.Text = $"Your selected dice were: ";
            AnsInfo.Text = $"The chosen propability calculation was: ";
            AnsInfo.Text = $"The probability is: ";
        }

        private void InitializeSettingsPanel()
        {
            settingsPanel = new Panel
            {
                Size = new Size(500, 300),
                BackColor = Color.FromArgb(220, 220, 220), // Light gray
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false, // Settings page is hidden initially on launch
                Location = new Point((this.Width - 300) / 2, (this.Height - 200) / 2) 
            };

            // Placeholder label
            Label placeholderLabel = new Label
            {
                Text = "Settings",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(20, 20)
            };

            // Apply Button
            Button applyButton = new Button
            {
                Text = "Apply",
                Size = new Size(80, 30),
                Location = new Point(50, 250)
            };
            applyButton.Click += ApplySettings_Click;

            // testi Button
            Button SameNumButton = new Button
            {
                Text = "P of number(s) in succession",
                Size = new Size(120, 50),
                Location = new Point(50, 50)
            };
            SameNumButton.Click += TestSettings_Click;

            Button SumLessThanButton = new Button
            {
                Text = "P of sum less than",
                Size = new Size(120, 50),
                Location = new Point(50, 100)
            };
            SumLessThanButton.Click += TestSettings_Click;

            Button SumMoreThanButton = new Button
            {
                Text = "P of sum more than",
                Size = new Size(120, 50),
                Location = new Point(50, 150)
            };
            SumMoreThanButton.Click += TestSettings_Click;

            // Cancel Button
            Button cancelButton = new Button
            {
                Text = "Cancel",
                Size = new Size(80, 30),
                Location = new Point(160, 250)
            };
            cancelButton.Click += (s, e) => settingsPanel.Visible = false; 

            // Add controls to the panel
            settingsPanel.Controls.Add(placeholderLabel);
            settingsPanel.Controls.Add(applyButton);
            settingsPanel.Controls.Add(cancelButton);
            settingsPanel.Controls.Add(SameNumButton);
            settingsPanel.Controls.Add(SumLessThanButton);
            settingsPanel.Controls.Add(SumMoreThanButton);

            // Add panel to form
            this.Controls.Add(settingsPanel);
        }

        // Apply button click event handler
        private void ApplySettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Settings applied!");
        }

        private void TestSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asetus vaihdettu testi");
            
        }

        private void Setting_Button_Click(object sender, EventArgs e)
        {
            settingsPanel.Visible = true; // Show settings overlay
            settingsPanel.BringToFront(); // **Ensure it's on top**

        }
    }
}