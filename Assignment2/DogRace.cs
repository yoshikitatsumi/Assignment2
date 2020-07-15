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

        // Defining the objects
        Greyhound D1;
        Greyhound D2;
        Greyhound D3;
        Greyhound D4;

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

            // When the forms loads, I initialise the objects   
            D1 = new Dog1(Dog1Label.Text, Dog1Picture);
            D2 = new Dog2(Dog2Label.Text, Dog2Picture);
            D3 = new Dog3(Dog3Label.Text, Dog3Picture);
            D4 = new Dog4(Dog4Label.Text, Dog4Picture);
        }

        private void PlaceBetBtn_Click(object sender, EventArgs e)
        {
            // Each punter chosing dog and betting amount
            if (JDogNoUpDown.Value == 1)
            {
                Punters[0].Betting(D1, Convert.ToInt32(JBetBox.Text));
            }
            else if (JDogNoUpDown.Value == 2)
            {
                Punters[0].Betting(D2, Convert.ToInt32(JBetBox.Text));
            }
            else if (JDogNoUpDown.Value == 3)
            {
                Punters[0].Betting(D3, Convert.ToInt32(JBetBox.Text));
            }
            else if (JDogNoUpDown.Value == 4)
            {
                Punters[0].Betting(D4, Convert.ToInt32(JBetBox.Text));
            }
            if (BDogNoUpDown.Value == 1)
            {
                Punters[1].Betting(D1, Convert.ToInt32(BBetBox.Text));
            }
            else if (BDogNoUpDown.Value == 2)
            {
                Punters[1].Betting(D2, Convert.ToInt32(BBetBox.Text));
            }
            else if (BDogNoUpDown.Value == 3)
            {
                Punters[1].Betting(D3, Convert.ToInt32(BBetBox.Text));
            }
            else if (BDogNoUpDown.Value == 4)
            {
                Punters[1].Betting(D4, Convert.ToInt32(BBetBox.Text));
            }
            if (ADogNoUpDown.Value == 1)
            {
                Punters[2].Betting(D1, Convert.ToInt32(ABetBox.Text));
            }
            else if (ADogNoUpDown.Value == 2)
            {
                Punters[2].Betting(D2, Convert.ToInt32(ABetBox.Text));
            }
            else if (ADogNoUpDown.Value == 3)
            {
                Punters[2].Betting(D3, Convert.ToInt32(ABetBox.Text));
            }
            else if (ADogNoUpDown.Value == 4)
            {
                Punters[2].Betting(D4, Convert.ToInt32(ABetBox.Text));
            }

            // checking for betting 
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


            JMax.Text = (Convert.ToInt32(JMax.Text) - Convert.ToInt32(JBetBox.Text)).ToString();
            BMax.Text = (Convert.ToInt32(BMax.Text) - Convert.ToInt32(BBetBox.Text)).ToString();
            AMax.Text = (Convert.ToInt32(AMax.Text) - Convert.ToInt32(ABetBox.Text)).ToString();



            // Setting for BUSTED
            if (0 > Convert.ToInt32(JMax.Text))
            {
                JBustedBox.Text = "BUSTED!";
                JMax.Text = "0";
                JBetBox.Text = "0";
            }
            if (0 > Convert.ToInt32(BMax.Text))
            {
                BBustedBox.Text = "BUSTED!";
                BMax.Text = "0";
                BBetBox.Text = "0";
            }
            if (0 > Convert.ToInt32(AMax.Text))
            {
                ABustedBox.Text = "BUSTED!";
                AMax.Text = "0";
                ABetBox.Text = "0";
            }

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
            JBetBox.Text = "0";
            BBetBox.Text = "0";
            ABetBox.Text = "0";
            JDogNoUpDown.Value = 1;
            BDogNoUpDown.Value = 1;
            ADogNoUpDown.Value = 1;
            JBustedBox.Text = "";
            BBustedBox.Text = "";
            ABustedBox.Text = "";
        }

        // slow movement using async and await
        private async void RaceBtn_Click(object sender, EventArgs e)
        {
            // Setting for BUSTED again
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
            // setting variables with null
            string winner = "";
            string looser = "";

            // 4 dogs racing
            for (int i = 0; i < 4; i++)
            {
                // Dog1 winning case
                if (D1.Picture.Location.X >= 700)
                {
                    winner = D1.Number;
                    if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nJoe, Bob & Al won!"; // winning punter
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nJoe & Bob won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nAl lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nJoe & Al won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nBob & Al won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nJoe won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob & Al lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nBob won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Al lost!";
                    }
                    else if (winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D1.Number + ".\r\nAl won!";
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Bob lost!";
                    }
                    else
                    {
                        looser = "\r\nAll lost!";
                    }
                }
                else if (D2.Picture.Location.X >= 700)
                {
                    winner = D2.Number;
                    if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nJoe, Bob & Al won!"; // winning punter
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nJoe & Bob won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nAl lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nJoe & Al won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nBob & Al won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nJoe won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob & Al lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nBob won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Al lost!";
                    }
                    else if (winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D2.Number + ".\r\nAl won!";
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Bob lost!";
                    }
                    else
                    {
                        looser = "\r\nAll lost!";
                    }
                }
                else if (D3.Picture.Location.X >= 700)
                {
                    winner = D3.Number;
                    if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nJoe, Bob & Al won!"; // winning punter
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nJoe & Bob won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nAl lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nJoe & Al won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nBob & Al won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nJoe won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob & Al lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nBob won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Al lost!";
                    }
                    else if (winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D3.Number + ".\r\nAl won!";
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Bob lost!";
                    }
                    else
                    {
                        looser = "\r\nAll lost!";
                    }
                }
                else if (D4.Picture.Location.X >= 700)
                {
                    winner = D4.Number;
                    if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nJoe, Bob & Al won!"; // winning punter
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nJoe & Bob won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nAl lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nJoe & Al won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value && winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nBob & Al won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe lost!";
                    }
                    else if (winner == "Dog" + JDogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nJoe won!";
                        JMax.Text = (Convert.ToInt32(JBetBox.Text) + Convert.ToInt32(JMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nBob & Al lost!";
                    }
                    else if (winner == "Dog" + BDogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nBob won!";
                        BMax.Text = (Convert.ToInt32(BBetBox.Text) + Convert.ToInt32(BMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Al lost!";
                    }
                    else if (winner == "Dog" + ADogNoUpDown.Value)
                    {
                        winner = D4.Number + ".\r\nAl won!";
                        AMax.Text = (Convert.ToInt32(ABetBox.Text) + Convert.ToInt32(AMax.Text)).ToString(); // after winning cash amount
                        looser = "\r\nJoe & Bob lost!";
                    }
                    else
                    {
                        looser = "\r\nAll lost!";
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
            MessageBox.Show("The dog race is finished and winner is " + winner + ". " + looser);

            D1.Picture.Location = new Point(35, 35);
            D2.Picture.Location = new Point(35, 95);
            D3.Picture.Location = new Point(35, 155);
            D4.Picture.Location = new Point(35, 215);

            PlaceBetBtn.Enabled = true;
            ResetBtn.Enabled = true;
            RaceBtn.Enabled = false;

        }

        private void JBetBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
