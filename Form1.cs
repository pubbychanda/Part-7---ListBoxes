////
////THE PROGRAM CRASHES WHEN I REMOVE ALL NUMBERS FROM NUMBER LIST !!!
////I ALSO NEED TO PROGRAM THE SORTING BUTTONS !!!
////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Part_7___ListBoxes
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int>();
        List<string> heroes = new List<string>();
        Random rng = new Random();
        int removednumber;
        string removedhero;
        string addedhero;
        string duplicatehero;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ///initial numbers list
            for (int i = 0; i < 20; i++)
                numbers.Add(rng.Next(100));
            lstNumbers.DataSource = numbers;

            ///initial heroes list
            heroes.Add("superman");
            heroes.Add("batman");
            lstHeroes.DataSource = heroes;
        }
        private void btnSortNumbers_Click(object sender, EventArgs e)
        {
            numbers.Sort();
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: Numbers sorted.";
        }
        private void btnSortHeroes_Click(object sender, EventArgs e)
        {
            heroes.Sort();
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: Heroes Sorted.";
        }
        private void btnNewNumbers_Click(object sender, EventArgs e)
        {
            numbers.Clear();
            for (int i = 0; i < 20; i++)
                numbers.Add(rng.Next(100));
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: Numbers re-generated.";
        }
        private void btnNewHeroes_Click(object sender, EventArgs e)
        {
            heroes.Clear();
            heroes.Add("superman");
            heroes.Add("batman");
            lstHeroes.DataSource = null;
            lstHeroes.DataSource = heroes;
            lblStatus.Text = "Status: Heroes re-generated.";
        }
        private void btnRemoveNumber_Click(object sender, EventArgs e)
        {
            removednumber = (Int32)lstNumbers.SelectedValue;
            numbers.RemoveAt((Int32)lstNumbers.SelectedIndex);
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: " + removednumber + " has been removed.";
        }
        private void btnRemoveAllNumbers_Click(object sender, EventArgs e)
        {
            removednumber = (Int32)lstNumbers.SelectedValue;
            while (numbers.Remove(removednumber))
                numbers.Remove(removednumber);
            lstNumbers.DataSource = null;
            lstNumbers.DataSource = numbers;
            lblStatus.Text = "Status: " + removednumber + " has been removed.";
        }
        private void btnRemoveHero_Click(object sender, EventArgs e)
        {
            removedhero = txtRemoveHero.Text.ToLower().Trim();

            ///Correct string check
            for (int i = 0; i < heroes.Count; i++)
                if (removedhero != heroes[i])
                    lblStatus.Text = "Status: Invalid Hero Name.";
                else if (removedhero == heroes[i])
                {
                    txtRemoveHero.Text = "";
                    heroes.Remove(removedhero);
                    lstHeroes.DataSource = null;
                    lstHeroes.DataSource = heroes;
                    lblStatus.Text = "Status: '" + removedhero + "' has been successfully removed.";
                }
        }
        private void btnAddHero_Click(object sender, EventArgs e)
        {
            addedhero = txtAddHero.Text.ToLower().Trim();

            ///duplicate check
            for (int i = 0; i < heroes.Count; i++) 
                if (addedhero == heroes[i])
                    duplicatehero = heroes[i];
            ///output = null
            if (addedhero == "")
                lblStatus.Text = "Status: No input received.";
            ///output = duplicate
            else if (addedhero == duplicatehero)
                lblStatus.Text = "Status: Duplicate has been Ingored. ";
            ///output is ALLOWED
            else
            {
                heroes.Add(addedhero);
                lstHeroes.DataSource = null;
                lstHeroes.DataSource = heroes;
                lblStatus.Text = "Status: '" + addedhero + "' has been successfully added.";
            }
           











        }
    }
}
