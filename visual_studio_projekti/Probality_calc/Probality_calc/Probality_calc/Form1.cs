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
            LoadedDice.diceList = JsonLoader.ReadFile();
            InitializeComponent();
            // jsonSerializer
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Attach event handler to buttons
            D4.Click += AddInfoBox_Click;
            D6.Click += AddInfoBox_Click;
            D8.Click += AddInfoBox_Click;
            D10.Click += AddInfoBox_Click;
            D12.Click += AddInfoBox_Click;
            D20.Click += AddInfoBox_Click;
            Clear.Click += Clear_Click;


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

            // Create the panel (infoBox)
            Panel infoBox = new Panel
            {
                Size = new Size(clickedButton.Width, clickedButton.Height + 20),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Button infoButton = new Button
            {
                Size = clickedButton.Size,
                BackgroundImage = clickedButton.BackgroundImage,
                BackgroundImageLayout = clickedButton.BackgroundImageLayout,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.BottomCenter,
                FlatAppearance = { BorderSize = 0 }
            };

            // Create the label below the button
            Label nameLabel = new Label
            {
                Text = clickedButton.Name,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(150, 0, 0, 0),
                Size = new Size(infoBox.Width, 20),
                Location = new Point(0, infoButton.Height)
            };

            // Add the Button and Label to the Panel
            infoBox.Controls.Add(infoButton);
            infoBox.Controls.Add(nameLabel);

            // Set the Button's location at the top of the panel
            infoButton.Location = new Point(0, 0);

            // Move to the next row if the panel exceeds EventBoard width
            if (panelOffsetX + infoBox.Width > EventBoard.Width)
            {
                panelOffsetX = 10;
                panelOffsetY += infoBox.Height + spaceBetweenPanels;
            }

            infoBox.Location = new Point(panelOffsetX, panelOffsetY);
            EventBoard.Controls.Add(infoBox);

            // Update panelOffsetX for the next panel
            panelOffsetX += infoBox.Width + spaceBetweenPanels;

            // Attach the click event handler to the button inside the infoBox
            infoButton.Click += (s, args) => OpenSettingsForm(clickedButton.Name);
        }

        private static readonly Dictionary<string, int> DiceSides = new Dictionary<string, int>
{
    { "D4", 4 },
    { "D6", 6 },
    { "D8", 8 },
    { "D10", 10 },
    { "D12", 12 },
    { "D20", 20 },
};

        private void OpenSettingsForm(string diceName)
        {
            if (!DiceSides.ContainsKey(diceName)) return;
            int numberOfSides = DiceSides[diceName];

            Form settingsForm = new Form
            {
                Text = $"{diceName} Settings",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Panel settingsPanel = new Panel
            {
                Size = new Size(500, 300),
                BackColor = Color.FromArgb(220, 220, 220),
                BorderStyle = BorderStyle.FixedSingle
            };

            AddSettingsLabel(settingsPanel, diceName);

            AddCheckboxesForDice(settingsPanel, numberOfSides);

            settingsForm.Controls.Add(settingsPanel);
            settingsForm.ShowDialog();
        }

        private void AddSettingsLabel(Panel settingsPanel, string diceName)
        {
            Label settingsLabel = new Label
            {
                Text = $"Settings for {diceName}",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(20, 20)
            };
            settingsPanel.Controls.Add(settingsLabel);
        }

        private void AddCheckboxesForDice(Panel settingsPanel, int numberOfSides)
        {
            int maxColumns = 5; // Number of checkboxes per row before wrapping
            int spacingX = 90; 
            int spacingY = 30; 
            int startX = 20; 
            int startY = 50; 

            for (int i = 0; i < numberOfSides; i++)
            {
                int col = i % maxColumns; // Determines the column number
                int row = i / maxColumns; // Determines the row number

                CheckBox checkBox = new CheckBox
                {
                    Text = $"Side {i + 1}",
                    Location = new Point(startX + (col * spacingX), startY + (row * spacingY)),
                    AutoSize = true
                };
                settingsPanel.Controls.Add(checkBox);
            }
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
            AnsInfo.Text = $"The chosen probability calculation was: ";
            AnsInfo.Text = $"The probability is: ";
        }



        private void OpenSettingsForm()
        {
            Form settingsForm = new Form
            {
                Text = "Settings",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Panel settingsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(220, 220, 220), // Light gray
                BorderStyle = BorderStyle.FixedSingle
            };

            Label placeholderLabel = new Label
            {
                Text = "Settings",
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(20, 20)
            };

            Button applyButton = new Button
            {
                Text = "Apply",
                Size = new Size(80, 30),
                Location = new Point(300, 220)
            };
            applyButton.Click += ApplySettings_Click;

            Button cancelButton = new Button
            {
                Text = "Cancel",
                Size = new Size(80, 30),
                Location = new Point(380, 220)
            };
            cancelButton.Click += (s, e) => settingsForm.Close();


            Button sameNumButton = new Button
            {
                Text = "P of number(s) in succession",
                Size = new Size(120, 50),
                Location = new Point(50, 50)
            };
            sameNumButton.Click += TestSettings_Click;

            Button sumLessThanButton = new Button
            {
                Text = "P of sum less than",
                Size = new Size(120, 50),
                Location = new Point(50, 100)
            };
            sumLessThanButton.Click += TestSettings_Click;

            Button sumMoreThanButton = new Button
            {
                Text = "P of sum more than",
                Size = new Size(120, 50),
                Location = new Point(50, 150)
            };
            sumMoreThanButton.Click += TestSettings_Click;



            // Add controls to the panel
            settingsPanel.Controls.Add(placeholderLabel);
            settingsPanel.Controls.Add(applyButton);
            settingsPanel.Controls.Add(cancelButton);
            settingsPanel.Controls.Add(sameNumButton);
            settingsPanel.Controls.Add(sumLessThanButton);
            settingsPanel.Controls.Add(sumMoreThanButton);

            settingsForm.Controls.Add(settingsPanel);

            settingsForm.ShowDialog(); // Opens as a modal window
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
            OpenSettingsForm(); // This will open the settings in a new window
        }

    }
}