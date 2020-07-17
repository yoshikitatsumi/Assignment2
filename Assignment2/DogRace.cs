using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class DogRace : Form
    {
        // Defining three Punters
        Punter[] Punters = new Punter[3];

        // Defining the objects race dogs
        Greyhound D1;
        Greyhound D2;
        Greyhound D3;
        Greyhound D4;

        Greyhound[] Dogs;

        public DogRace()
        {
            InitializeComponent();
            // initial button control to enable or not
            PlaceBetBtn.Enabled = true;
            ResetBtn.Enabled = false;
            RaceBtn.Enabled = false;
            // initial amount to variables
            JMax.Text = "100"; // cash
            BMax.Text = "100";
            AMax.Text = "100";
            JBetBox.Text = "1"; //bet
            BBetBox.Text = "1";
            ABetBox.Text = "1";
        }

        private void DogRace_Load(object sender, EventArgs e)
        {
            // Setting punters from Factory (Punter Createpunter)
            Punters[0] = Factory.CreatePunter("Joe", 100);
            Punters[1] = Factory.CreatePunter("Bob", 100);
            Punters[2] = Factory.CreatePunter("Al", 100);

            // Initialising the objects race dogs
            D1 = new Dog1(Dog1Label.Text, Dog1Picture);
            D2 = new Dog2(Dog2Label.Text, Dog2Picture);
            D3 = new Dog3(Dog3Label.Text, Dog3Picture);
            D4 = new Dog4(Dog4Label.Text, Dog4Picture);
            // Setting race dogs array
            Dogs = new Greyhound[4] { D1, D2, D3, D4 };
        }

        private void PlaceBetBtn_Click(object sender, EventArgs e)
        {
            // Each punter chosing dog and betting amount
            for (int n = 0; n < 4; n++)
            {
                if (JDogNoUpDown.Value == n)
                {
                    Punters[0].Betting(Dogs[n], Convert.ToInt32(JBetBox.Text));
                }
                else if (BDogNoUpDown.Value == n)
                {
                    Punters[1].Betting(Dogs[n], Convert.ToInt32(BBetBox.Text));
                }
                else if (ADogNoUpDown.Value == n)
                {
                    Punters[2].Betting(Dogs[n], Convert.ToInt32(ABetBox.Text));
                }
            }

            // checking for betting availability
            if (Convert.ToInt32(JBetBox.Text) > Convert.ToInt32(JMax.Text))
            {
                JBetBox.Text = JMax.Text;
            }
            if (Convert.ToInt32(BBetBox.Text) > Convert.ToInt32(BMax.Text))
            {
                BBetBox.Text = BMax.Text;
            }
            if (Convert.ToInt32(ABetBox.Text) > Convert.ToInt32(AMax.Text))
            {
                ABetBox.Text = AMax.Text;
            }

            // New cash amount calculation
            JMax.Text = (Convert.ToInt32(JMax.Text) - Convert.ToInt32(JBetBox.Text)).ToString();
            BMax.Text = (Convert.ToInt32(BMax.Text) - Convert.ToInt32(BBetBox.Text)).ToString();
            AMax.Text = (Convert.ToInt32(AMax.Text) - Convert.ToInt32(ABetBox.Text)).ToString();

            // Button enable or not
            PlaceBetBtn.Enabled = false;
            ResetBtn.Enabled = true;
            RaceBtn.Enabled = true;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            // Button enable or not
            PlaceBetBtn.Enabled = true;
            ResetBtn.Enabled = false;
            RaceBtn.Enabled = false;
            // resetting cash 100 for all 
            JMax.Text = "100";
            BMax.Text = "100";
            AMax.Text = "100";
            // resetting bet nill for all
            JBetBox.Text = "0";
            BBetBox.Text = "0";
            ABetBox.Text = "0";
            // restting dog number at 1 for all
            JDogNoUpDown.Value = 1;
            BDogNoUpDown.Value = 1;
            ADogNoUpDown.Value = 1;
            // deleting BUSTED! if any
            JBustedBox.Text = "";
            BBustedBox.Text = "";
            ABustedBox.Text = "";
        }

        // slow movement using async and await
        private async void RaceBtn_Click(object sender, EventArgs e)
        {
            // Button enable or not
            PlaceBetBtn.Enabled = false;
            ResetBtn.Enabled = false;
            RaceBtn.Enabled = false;
            // Setting for BUSTED
            if (Convert.ToInt32(JMax.Text) == 0 && Convert.ToInt32(JBetBox.Text) == 0)
            {
                JBustedBox.Text = "BUSTED!";
                JDogNoUpDown.Value = 0;
            }
            if (Convert.ToInt32(BMax.Text) == 0 && Convert.ToInt32(BBetBox.Text) == 0)
            {
                BBustedBox.Text = "BUSTED!";
                BDogNoUpDown.Value = 0;
            }
            if (Convert.ToInt32(AMax.Text) == 0 && Convert.ToInt32(ABetBox.Text) == 0)
            {
                ABustedBox.Text = "BUSTED!";
                ADogNoUpDown.Value = 0;
            }

            // actual race starts
            Random rand = new Random();

            while (D1.Picture.Location.X < 700 &&
                D2.Picture.Location.X < 700 &&
                D3.Picture.Location.X < 700 &&
                D4.Picture.Location.X < 700)
            {
                D1.Move(rand.Next(0, 50));
                D2.Move(rand.Next(0, 50));
                D3.Move(rand.Next(0, 50));
                D4.Move(rand.Next(0, 50));

                await Task.Delay(200);
            }
            // setting variables with blank
            string winner = "";
            string looser = "";

            // 4 times race dogs using array
            for (int n = 0; n < 4; n++)
            {
                // Dog winning case
                if (Dogs[n].Picture.Location.X >= 700)
                {
                    winner = Dogs[n].Number;
                    if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nJoe, Bob & Al won!"; // winning punter
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) * 2 + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) * 2 + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) * 2 + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount (bet * 2)
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nJoe & Bob won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) * 2 + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) * 2 + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nAl lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nJoe & Al won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) * 2 + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) * 2 + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nBob lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nBob & Al won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) * 2 + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) * 2 + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nJoe lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nJoe won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) * 2 + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nBob & Al lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nBob won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) * 2 + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nJoe & Al lost!";
                    }
                    else if (winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = Dogs[n].Number + ".\r\nAl won!";
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) * 2 + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount (bet * 2)
                        looser = "\r\nJoe & Bob lost!";
                    }
                    else
                    {
                        looser = "\r\nAll lost!";
                    }
                }
            }

            // Showing result in message box
            MessageBox.Show("The dog race is finished and winner is " + winner + ". " + looser);
            // Resetting the race dogs at starting point
            D1.Picture.Location = new Point(35, 35);
            D2.Picture.Location = new Point(35, 95);
            D3.Picture.Location = new Point(35, 155);
            D4.Picture.Location = new Point(35, 215);
            // Resetting the buttons avvailability
            PlaceBetBtn.Enabled = true;
            ResetBtn.Enabled = true;
            RaceBtn.Enabled = false;

        }
    }
}


