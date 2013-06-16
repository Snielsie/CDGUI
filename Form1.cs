using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace NielsD_Gui
{

    public partial class Form1 : Form
    {
        int[] kaartnummer = {1, 2};


        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // keuze menu van de band
            // hieronder zet ik liedjes erin via AddRange():
            listBox1.Items.AddRange(new object[] { "Beasty Boys, €10,-", "Dragonforce, €10,-", "Blind Guardian, €10,-", "Floggin Molly, €10,-", "Gunther, €10,-", "The lonely island, €10,-", "Owl City, €10,-", "Zero Wing, €10,-", "U2, €10,-", "Coldplay, €10,-" });
            groupBox2.Location = groupBox1.Location;
            groupBox3.Location = groupBox1.Location;
            groupBox4.Location = groupBox1.Location;
            groupBox5.Location = groupBox1.Location;
            groupBox6.Location = groupBox1.Location;
            groupBox7.Location = groupBox1.Location;
            this.Size = groupBox1.Size + new System.Drawing.Size(50, 70);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // alles hieronder zorgt ervoor dat geselecteerde liedjes naar de 2e listbox gaan
            int count = listBox1.SelectedItems.Count;

            if (count > 0)
            {
                foreach (object o in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(o);
                }
                for (int i = 0; i < count; i++)
                {
                    object o = listBox1.SelectedItems[0];
                    listBox1.Items.Remove(o);
                }
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            object s = listBox2.SelectedItem;
            if (s != null)
            {
                listBox1.Items.Add(s);
                listBox2.Items.Remove(s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox4.Visible = true;
        }
        // hieronder word listbox 1 en 2 gecleard en de standaard items weer in listbox1 geladen
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(new object[] { "Beasty Boys, €10,-", "Dragonforce, €10,-", "Blind Guardian, €10,-", "Floggin Molly, €10,-", "Gunther, €10,-", "The lonely island, €10,-", "Owl City, €10,-", "Zero Wing, €10,-", "U2, €10,-", "Coldplay, €10,-" });
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //invoer vergelijken met vastgestelde nummers
            // TryParse kijkt of de eerst opgegeven variable/element (in dit geval nummer.Text) kan worden omgezet naar een integer (int)
            // Als dit lukt dan zet hij de omgezette integer van de textbox in de 2e opgegeven variable (in dit geval numbervalue) zodat we die daarna kunnen uitlezen.
            // Ook geeft de TryParse een true of false terug mocht het zijn gelukt (handig voor if statements)
            int numbervalue = 0;
            if (int.TryParse(nummer.Text, out numbervalue))
            {

                if (Convert.ToInt32(nummer.Text) == kaartnummer[0] && Convert.ToInt32(pincode.Text) == kaartnummer[1])
                {
                    groupBox4.Visible = false;
                    groupBox2.Visible = true;
                    // hiermee ga je naar groupbox 5
                    groupBox2.Visible = false;
                    groupBox5.Visible = true;
                }
                else
                {
                    //invoer word gecleared
                    nummer.Text = "";
                    pincode.Text = "";
                    MessageBox.Show("Uw ingevoerde gegevens zijn incorrect", "Foute Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            nummer.Text = "";
            pincode.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int invoergeld;
            int totaalbedrag = listBox2.Items.Count * 10;
            if (int.TryParse(invoer.Text, out invoergeld))
            {
                if (invoergeld >= totaalbedrag)
                    invoer.ForeColor = Color.DarkGreen;
                else
                    invoer.ForeColor = Color.Red;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox3.Visible = true;
            label8.Text = "U moet " + listBox2.Items.Count * 10 + " euro betalen";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox2.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int totaalbedrag = listBox2.Items.Count * 10;
            int invoergeld = 0;
            if (int.TryParse(invoer.Text, out invoergeld))
            {

                if (invoergeld >= totaalbedrag)
                {
                    if (invoergeld > totaalbedrag)
                    {
                        MessageBox.Show("Uw wisselgeld is " + (invoergeld - totaalbedrag) + " euro", "Wisselgeld",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    groupBox3.Visible = false;
                    groupBox5.Visible = true;
                }
                else
                {
                    MessageBox.Show("U moet nog: " + (totaalbedrag - invoergeld) + " euro betalen.", "Betalen",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            invoer.Text = "";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox3.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            groupBox1.Visible = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox1.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox6.Visible = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            groupBox5.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
                textBox1.Enabled = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
                textBox1.Enabled = true;
            }

        }

        public void button17_Click_1(object sender, EventArgs e)
        {
            //hieronder word ervoor gezorgd dat je het mail vakje kan invullen
            if (radioButton1.Checked)
            {
                if (IsEmail(textBox1.Text))
                {
                    // als email klopt dan doorsturen naar volgende scherm
                    groupBox6.Visible = false;
                    groupBox7.Visible = true;
                    timer1.Enabled = true;
                }
                    //hieronder laat hij zien hoe het wat er gebeurd als het fout gaat
                else
                {
                    MessageBox.Show("Uw ingevoerde gegevens zijn incorrect", "Fout Mailadres",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                }
            }
                //hier word het bonnetje geprint
            else
            {
                MessageBox.Show("U bonnetje is geprint", "Printen",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                groupBox6.Visible = false;
                groupBox7.Visible = true;
                timer1.Enabled = true;
            }
        }
        // hier word de email voor alle mogelijke combinatie's getest en kijkt hij of deze wel geldig is
        public static bool IsEmail(string Email)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
                return (true);
            else
                return (false);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            groupBox7.Visible = true;
        }
        // deze timer heeft 10 sec afscheids scherm en gaat dan de boel reseten
        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox7.Visible = false;
            timer1.Enabled = false;
            resetalles();
        }
        //hieronder clear ik alles weer en is de machine klaar voor de volgende gebruiker
        private void resetalles()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(new object[] { "Beasty Boys, €10,-", "Dragonforce, €10,-", "Blind Guardian, €10,-", "Floggin Molly, €10,-", "Gunther, €10,-", "The lonely island, €10,-", "Owl City, €10,-", "Zero Wing, €10,-", "U2, €10,-", "Coldplay, €10,-" }); invoer.Text = "";
            nummer.Text = "";
            pincode.Text = "";
            textBox1.Text = "";

        }

        private void button18_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void abonnement_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
