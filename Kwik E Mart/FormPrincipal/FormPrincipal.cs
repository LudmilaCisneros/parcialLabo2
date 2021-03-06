﻿using System;
using System.Media;
using System.Windows.Forms;
using Kwik_E_Mart;

namespace Formularios
{
    public partial class FormPrincipal : Form
    {
        FormLogin login;
        private string usuario;
        public FormPrincipal(FormLogin login, string usuario)
        {
            InitializeComponent();
            this.login = login;
            this.usuario = usuario;
            lblNombreUser.Text = usuario;
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            FormCompra formCompra = new FormCompra(usuario);
            formCompra.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("./apu.wav");
            player.Play();

        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Gracias,vuelva prontoss!!!", "adiosito", MessageBoxButtons.OK);
            this.login.Show();
        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios(usuario);
            formUsuarios.Show();
            //abrir ver usuarios y pass form agregar usuario
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormVerCompras formCompra = new FormVerCompras();
            formCompra.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //Negocio.HardcodearCompras();
        }
    }
}
