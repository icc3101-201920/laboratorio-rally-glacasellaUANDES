using ModelosRally;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistasRally
{
    public partial class Form1 : Form
    {
        public event EventHandler<AgregarPilotoEventArgs> OnAgregarPiloto;

        public Form1()
        {
            InitializeComponent();
            this.RolComboBox.DataSource = Enum.GetValues(typeof(Rol));
        }

        private void AgregarPilotoButton_Click(object sender, EventArgs e)
        {
            if (OnAgregarPiloto != null)
            {
                AgregarPilotoEventArgs pilotoArgs = new AgregarPilotoEventArgs();
                pilotoArgs.persona = new Persona(this.NameTextBox.Text, (Rol)Enum.Parse(typeof(Rol), this.RolComboBox.SelectedItem.ToString()));
                OnAgregarPiloto(this, pilotoArgs);
            }
               
        }

        public void ActualizarListadoPilotos(Persona pilotoNuevo)
        {
            PilotNameComboBox.Items.Add(pilotoNuevo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NombreEquipoTextBox.Text != null && NombreEquipoTextBox.Text != "")
            {
                VistaDeEquiposTreeView.Nodes.Add(NombreEquipoTextBox.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VistaDeEquiposTreeView.SelectedNode == null)
            {
                MessageBox.Show("Please, select a team", "Team not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VistaDeEquiposTreeView.SelectedNode.Nodes.Add("Nombre: " + this.NameTextBox.Text + ".Rol: " + this.RolComboBox.SelectedItem.ToString());
            VistaDeEquiposTreeView.SelectedNode = null;

        }
    }
}
