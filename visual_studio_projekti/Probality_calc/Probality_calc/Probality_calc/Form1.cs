using System.Drawing;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;


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
            InitializeObservableButtons();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeObservableButtons();

            // Attach event handler to buttons

            Clear.Click += Clear_Click;


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
            infoBox.Controls.Add(infoButton);
            infoBox.Controls.Add(nameLabel);
            infoButton.BringToFront();  // Ensure the button is clickable

            Dice die = LoadedDice.diceList.Find((Dice x) => x.Name == clickedButton.Name);
            DiceStorage.diceList.Add(die);
        }



        /*private static readonly Dictionary<string, int> DiceSides = new Dictionary<string, int>
{
    { "D4", 4 },
    { "D6", 6 },
    { "D8", 8 },
    { "D10", 10 },
    { "D12", 12 },
    { "D20", 20 },
}; */

        private void OpenSettingsForm(string diceName)
        {

            //int numberOfSides = DiceSides[diceName];
            int numberOfSides = LoadedDice.diceList.Find((Dice x) => x.Name == diceName).Sides;

            // Create the settings form
            Form settingsForm = new Form
            {
                Text = $"{diceName} Settings",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Create a settings panel
            Panel settingsPanel = new Panel
            {
                Size = new Size(500, 300),
                BackColor = Color.FromArgb(220, 220, 220),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Add a label at the top of the settings panel
            AddSettingsLabel(settingsPanel, diceName);

            // Add checkboxes for each side of the dice
            AddCheckboxesForDice(settingsPanel, numberOfSides);

            // Add the panel to the settings form and show it
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
            int maxColumns = 5;  // Number of checkboxes per row before wrapping
            int spacingX = 90;
            int spacingY = 30;
            int startX = 20;
            int startY = 50;

            for (int i = 0; i < numberOfSides; i++)
            {
                int col = i % maxColumns; // Determines the column number
                int row = i / maxColumns; // Determines the row number

                // Create a checkbox for each side
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
            AnsInfo.Text = "";
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
            sameNumButton.Click += SameNum_Click;

            Button sumLessThanButton = new Button
            {
                Text = "P of sum less than",
                Size = new Size(120, 50),
                Location = new Point(50, 100)
            };
            sumLessThanButton.Click += sumLessThan_Click;

            Button sumMoreThanButton = new Button
            {
                Text = "P of sum more than",
                Size = new Size(120, 50),
                Location = new Point(180, 100)
            };
            sumMoreThanButton.Click += sumMoreThan_Click;

            Button sumExactlyButton = new Button
            {
                Text = "P of sum exactly",
                Size = new Size(120, 50),
                Location = new Point(180, 50)
            };
            sumExactlyButton.Click += SumExactly_Click;



            // Add controls to the panel
            settingsPanel.Controls.Add(placeholderLabel);
            settingsPanel.Controls.Add(applyButton);
            settingsPanel.Controls.Add(cancelButton);
            settingsPanel.Controls.Add(sameNumButton);
            settingsPanel.Controls.Add(sumLessThanButton);
            settingsPanel.Controls.Add(sumMoreThanButton);
            settingsPanel.Controls.Add(sumExactlyButton);
            settingsForm.Controls.Add(settingsPanel);
           
            settingsForm.ShowDialog(); // Opens as a modal window
        }


        private string selectedOperation = null; //ottaa stringin sisään ja sillä valitsee logiikan

        private void ApplySettings_Click(object sender, EventArgs e) // ei tee mitään. pelkästään haluttua todennäkösyyttä painamalla homma toimii
        {
            //MessageBox.Show("Settings applied!");
        }

        private void sumLessThan_Click(object sender, EventArgs e)
        {
            selectedOperation = "";
            selectedOperation += "SumLessThan";
            MessageBox.Show("Sum less than applied!");
        }

        private void sumMoreThan_Click(object sender, EventArgs e)
        {
            selectedOperation = "";
            selectedOperation += "SumMoreThan";
            MessageBox.Show("Sum more than applied!");
        }

        private void SameNum_Click(object sender, EventArgs e)
        {
            selectedOperation = "";
            selectedOperation += "SameNum";
            MessageBox.Show("Same number in succession applied!");
        }

        private void SumExactly_Click(object sender, EventArgs e)
        {
            selectedOperation = "";
            selectedOperation += "SumExactly";
            MessageBox.Show("Sum exactly applied!");
        }

        private void TestSettings_Click(object sender, EventArgs e) // ei tee mitään tarpeellista
        {
            //MessageBox.Show("Asetus vaihdettu testi");
        }

        private void Setting_Button_Click(object sender, EventArgs e)
        {
            OpenSettingsForm(); // This will open the settings in a new window
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            Logic logic = new Logic();

            if (selectedOperation == "SumLessThan")
            {
                string result = logic.SumLessThan(5);
                AnsInfo.Text += result;
            }
            else if (selectedOperation == "SumMoreThan")
            {
                string result = logic.SumMoreThan(5);
                AnsInfo.Text += result;
            }
            else if (selectedOperation == "SameNum")
            {
                string result = logic.SameNumInSuccession();
                AnsInfo.Text += result;
            }
            else if (selectedOperation == "SumExactly")
            {
                string result = logic.SumExactly(5);
                AnsInfo.Text += result;
            }
            else
            {
                AnsInfo.Text += "No operation selected!\n";
            }
        }

        private void Roll_Click(object sender, EventArgs e)
        {
            RollDice rollDice = new RollDice();
            var testi = rollDice.RollLessThan();
            AnsInfo.Text += testi;
        }



        private Dictionary<string, ObservableButton> observableButtons = new Dictionary<string, ObservableButton>();


        public class ObservableButton
        {
            public event EventHandler Clicked;  // Correct event type

            public string Name { get; }

            public ObservableButton(string name)
            {
                Name = name;
            }

            public void Click(object sender, EventArgs e)
            {
                Clicked?.Invoke(sender, e);  // Pass both parameters
            }
        }
        /*  Miksi vitus tääl on random public class Dice kun meillä oli se jo tuol jsonSerializer classissa ?? - LJ
        public class Dice
        {
            public string Name { get; set; }
            public int Sides { get; set; }

            public Dice(string name, int sides)
            {
                Name = name;
                Sides = sides;
            }
        } */

        // tää on mitkä nopat on json tiedostossa/luotu ja ladattu eli ne jotka on siinä vasemmalla puolella valittavissa. älä sekoita DiceStorageen
        public class LoadedDice
        {
            public static List<Dice> diceList { get; set; }
        }


        public class DiceList
        {
            public List<Dice> Dice { get; set; }
        }

        public class JsonLoader
        {
            public static List<Dice> ReadFile()
            {
                // Assuming the JSON file is in the same directory as the executable
                string filePath = Path.Combine(Application.StartupPath, "Dice.json");

                // Read the JSON file content
                string json = File.ReadAllText("../../Dice.json");

                // Deserialize the JSON to the DiceList object
                var diceList = JsonConvert.DeserializeObject<DiceList>(json);

                // Return the list of dice
                return diceList.Dice;  // Access the Dice list from DiceList class              // en kyl ymmärrä onks tää joku chatgpt koodi vai vaan bandaid fix -LJ
            }

            public static bool SaveFile(List<Dice> dice)
            {
                string filePath = Path.Combine(Application.StartupPath, "Dice.json");
                try
                {
                    string JsonOutput = JsonConvert.SerializeObject(dice);
                    File.WriteAllText(filePath, JsonOutput);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private void DiceButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            // Get the Dice object from the Tag property
            Dice selectedDice = clickedButton.Tag as Dice;
            if (selectedDice != null)
            {
                MessageBox.Show($"You selected {selectedDice.Name} with {selectedDice.Sides} sides.");
       //         DiceStorage.diceList.Add(selectedDice);
            }
        }




        private void InitializeObservableButtons()
        {
            dicePanel.Controls.Clear(); // Clear any existing buttons

            int startX = 10, startY = 10, buttonSpacing = 80;

            foreach (var dice in LoadedDice.diceList)  // Assuming LoadedDice.diceList is your list of dice
            {
                // Load the corresponding image for the dice
                Image diceImage = LoadDiceImage(dice.Name);

                // Create the actual UI button
                Button button = new Button
                {
                    Text = dice.Name.ToUpper(),  // Set the button text to the dice name in uppercase
                    Name = dice.Name,  // Set the button's name to the dice's name
                    Size = new Size(60, 60),  // Set a standard size for the button
                    Location = new Point(startX, startY),  // Set button location
                    Font = new Font("Arial", 10, FontStyle.Bold),  // Set font style
                    BackColor = Color.LightGray,  // Set background color
                    BackgroundImage = diceImage,  // Set the image as the background
                    BackgroundImageLayout = ImageLayout.Stretch,  // Stretch the image to fit the button size

                };

                // Attach the click event to trigger AddInfoBox_Click when the button is clicked
                button.Click += AddInfoBox_Click;

                // Add the button to the dicePanel
                dicePanel.Controls.Add(button);

                // Update the button placement for the next button
                startX += buttonSpacing;
                if (startX > dicePanel.Width - 100)  // If the button exceeds panel width, move to the next row
                {
                    startX = 10;
                    startY += buttonSpacing;  // Increase Y to move to the next row
                }
            }
        }


        private Image LoadDiceImage(string diceName)
            {
                // Format the image name (e.g., "d4.png" becomes "Resources.Images.d4.png")
                string resourcePath = $"Probality_calc.Resources.{diceName.ToUpper()}.png"; // Adjust namespace

            Assembly assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                if (stream != null)
                {
                    return Image.FromStream(stream);
                }
                else
                {
                    // If image not found, load a default placeholder image instead
                    return Properties.Resources.Custom; // Add a default image to your resources
                }
            }
        }



}






}
