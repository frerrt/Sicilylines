using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sicilylines.Modele;
using Sicilylines.Controleur;
using MySql.Data.MySqlClient;
using Sicilylines.DAL;

namespace Sicilylines
{
    public partial class Form1 : Form
    {
        private List<Liaison> l = new List<Liaison>();
        private List<Tarifier> t = new List<Tarifier>();

        Liaison l1;
        Liaison supprimer = new Liaison();
        Mg monMg;
        double operation;


        public Form1()
        {
            InitializeComponent();
            
            monMg = new Mg();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            l = monMg.chargementLiaison();
            if (l.Count != 0) { rafraichirListBox1(0); }

        }
  
        private void rafraichirListBox2(int index)
        {

            listBox2.DataSource = null;
           
            listBox2.DataSource = t;
            listBox2.DisplayMember = "Description";
            listBox2.SetSelected(index, true);
        }
  

        private void rafraichirListBox1(int index)
        {

            listBox1.DataSource = null;
            listBox1.DataSource = l;
            listBox1.DisplayMember = "Description";
            listBox1.SetSelected(index, true);



        }

        private void rafraichirListBox1_Tarif_Vides()
        {

            listBox2.DataSource = null;
            listBox2.DisplayMember = "Description";


        }




        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {





        }


        private void button1_Click(object sender, EventArgs e)
        {


            if (operation == 3)
            {
               
                int id = Convert.ToInt32(textBox1.Text);


                monMg.SupprimerLiaison(id);
                


            }
            else if (operation == 1)
            {
                int portDepart = Convert.ToInt32(portDePart.Text);

                int portArrivee = Convert.ToInt32(PortArrive.Text);

                int durees = Convert.ToInt32(duree.Text);

                int secteurs = Convert.ToInt32(secteur.Text);


                monMg.AjouterLiaisons(durees, secteurs,portDepart, portArrivee);
                





            }

            else if (operation == 2)
            {
                monMg.modifLiaison(l1);
            }

            int index = listBox1.SelectedIndex;

            rafraichirListBox1(index);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 3;
            secteur.Visible = false;
            textBox1.Visible = true;
            duree.Visible = false;
            PortArrive.Visible = false;
           
            
            portDePart.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button1.Visible = true;
        }

        private void secteur_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            secteur.Visible = true;
            operation = 1;
            textBox1.Visible = true;
            PortArrive.Visible = true;
            duree.Visible = true;
            portDePart.Visible = true;

            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            button1.Visible = true;





        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;




            if (i != -1)
            {
                Liaison lis = (Liaison)l[i];

                t = monMg.chargementTarif(lis);

                if (t.Count != 0) { rafraichirListBox2(0); }

                else { rafraichirListBox1_Tarif_Vides(); }




            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operation = 2;
            textBox1.Text = l1.Duree.ToString();

        }

        private void duree_TextChanged(object sender, EventArgs e)
        {
     
        }
    }

}
    