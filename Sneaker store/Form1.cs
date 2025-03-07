using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Sneaker_store
{
    public partial class Sneakers : Form
    {
        //Variables

        //Name 
        string name =  "a";

        //Prices
        double jordanPrice = 249.99;
        double dunkPrice = 199.99;
        double maxPrice = 224.99;

        //Number of sneakers bought
        int jordanNumber = 0;
        int dunkNumber = 0;
        int maxNumber = 0;

        //Taxes and stuff
        double taxRate = 0.13;

        //Subtotal (Before taxes)
        double subtotal = 0;

        //Total (After taxes)
        double total = 0;

        //Tendered
        double tendered = 0;

        //Allow printing variable
        int allowPrint = 0;

        //Recipt sound 
        SoundPlayer reciptPlayer = new SoundPlayer(Properties.Resources.recipt);


        public Sneakers()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (jordanNumber > -1 || maxNumber > -1 || dunkNumber > -1)
            {
                try
                {
                    reciptButton.Enabled = false;
                    name = nameInput.Text;
                    jordanNumber = Convert.ToInt32(jordanInput.Text);
                    dunkNumber = Convert.ToInt32(dunkInput.Text);
                    maxNumber = Convert.ToInt32(maxInput.Text);
                    subtotal = (jordanPrice * jordanNumber) + (dunkPrice * dunkNumber) + (maxPrice * maxNumber);
                    taxRate = (subtotal * taxRate);
                    total = (taxRate + subtotal);
                    subtotalOutput.Text = $"{subtotal.ToString("C")}";
                    taxOutput.Text = $"{taxRate.ToString("C")}";
                    totalOutput.Text = $"{total.ToString("C")}";
                    calculateButton.Enabled = false;
                    changeButton.Enabled = true;
                }
                catch
                {
                    totalOutput.Text = "Input error";
                    subtotalOutput.Text = "Input error";
                    taxOutput.Text = "Input error";
                    changeButton.Enabled = false;
                }
            }

             if (jordanNumber < 0 || maxNumber < 0 || dunkNumber <0)
            {
                subtotalOutput.Text = $"Nice try Ayush";
                totalOutput.Text = $"Nice try Ayush";
                taxOutput.Text = $"Nice try Ayush";
                changeButton.Enabled = false;
            }
        }



        private void changeButton_Click(object sender, EventArgs e)
        {


            try
            {
                tendered = Convert.ToDouble(tenderedInput.Text);
                if (tendered > total)
                {
                    allowPrint = 1;
                    tendered = (tendered - total);
                    changeOutput.Text = $"{tendered.ToString("C")}";
                    reciptButton.Enabled = true;
                    changeButton.Enabled = false;
                    reciptButton.Enabled = true;
                }
                else
                {
                    changeOutput.Text = $"Insuficient founds";
                }
            }

            catch
            {
                changeOutput.Text = $"Input error";
            }
            calculateButton.Enabled = false;

        }
        


        private void reciptButton_Click(object sender, EventArgs e)
        {
            if (allowPrint == 1)

            {
                reciptButton.Enabled = false;
                reciptPlayer.Play();
                allowPrint =0;
                if ((name == "Pasha") || (name == "Cole") || (name == "pasha") || (name == "Ayush") || (name == "cole"))
                {
                    reciptOutput.Text += $"\nMario's sneaker store";
                    reciptOutput.Refresh();


                    if (jordanNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nAir Jordans      x{jordanNumber}   @${jordanPrice}";
                        reciptOutput.Refresh();


                    }


                    if (dunkNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nDunks SB      x{dunkNumber}   @${dunkPrice}";
                        reciptOutput.Refresh();

                    }

                    if (maxNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nAir Maxes      x{maxNumber}   @${maxPrice}";
                        reciptOutput.Refresh();
                    }

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\n---------------------------------------";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nSubtotal              {subtotal.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTax                        {taxRate.ToString("C")}";
                    reciptOutput.Refresh();
                    reciptPlayer.Play();
                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTotal                    {total.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\n---------------------------------------";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTendered              {(tendered + total).ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nChange                {tendered.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\n{name}, you stink";
                    reciptOutput.Refresh();
                }

                else
                {
                    reciptOutput.Text += $"\nMario's sneaker store";
                    reciptOutput.Refresh();


                    if (jordanNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nAir Jordans      x{jordanNumber}   @${jordanPrice}";
                        reciptOutput.Refresh();

                    }


                    if (dunkNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nDunks SB      x{dunkNumber}   @${dunkPrice}";
                        reciptOutput.Refresh();

                    }

                    if (maxNumber > 0)
                    {
                        Thread.Sleep(450);
                        reciptOutput.Text += $"\n\nAir Maxes      x{maxNumber}   @${maxPrice}";
                        reciptOutput.Refresh();
                    }

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\n---------------------------------------";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nSubtotal              {subtotal.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTax                        {taxRate.ToString("C")}";
                    reciptOutput.Refresh();
                    reciptPlayer.Play();
                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTotal                    {total.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\n---------------------------------------";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nTendered              {(tendered + total).ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nChange                {tendered.ToString("C")}";
                    reciptOutput.Refresh();

                    Thread.Sleep(450);
                    reciptOutput.Text += $"\n\nHave a nice day {name}";
                    reciptOutput.Refresh();
                }

            }
            else { reciptOutput.Text = $" "; }

        }
        
        private void newButton_Click(object sender, EventArgs e)
        {
            subtotalOutput.Text = $" ";
            totalOutput.Text = $" ";
            taxOutput.Text = $"  ";
            changeOutput.Text = $"  ";
            reciptOutput.Text = $"  ";
            jordanInput.Text = $" ";
            dunkInput.Text = $" ";
            maxInput.Text = $" ";
            tenderedInput.Text = $" ";
            nameInput.Text = $" ";
            jordanNumber = 0;
            dunkNumber = 0;
            maxNumber = 0;
            tendered = 0;
            total = 0;
            subtotal = 0;
            taxRate = 0.13;
            allowPrint = 0;
            calculateButton.Enabled = true;
            reciptButton.Enabled = false;

        }
    }
}