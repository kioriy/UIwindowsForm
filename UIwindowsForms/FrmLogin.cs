using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Resources;
using UIwindowsForms.Properties;
using System.Threading;
using LogicModel; 
using DataAccess;
using DataAccess.Local;

namespace UIwindowsForms
{
    public partial class FrmLogin : Form
    {
        private Image restoreImage;
        private User usuario;
        private Login login = new Login();
    
        public FrmLogin(string AppName)
        {
            InitializeComponent();
            Settings.Default.AppName = AppName;
            //this.Text = "inicio de sesión TEST 2";
            lVersion.Text = "Version 1.12";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voy a realizar el login FrmLogin.cs");
            usuario = new User() { usuario = txtUsuario.Text, contraseña = txtContraseña.Text };
            MessageBox.Show("Inicialice al usuario, voy a entrar al metodo de la sesion FrmLogin.cs");
            if (login.starSesion(ref usuario))
            {
                MessageBox.Show("Si consegui datos FrmLogin.cs");
                MessageBox.Show($"{usuario.usuario} - {usuario.contraseña} FrmLogin.cs");
                Thread t_home = new Thread(new ThreadStart(startHome));
                t_home.Start();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Usuario no encontrado");
            }
        }

        private void PbMostrarContraseña_Click(object sender, EventArgs e)
        {
            bool StatusPasswordChar = txtContraseña.UseSystemPasswordChar;

            restoreImage = PbMostrarContraseña.Image;
            PbMostrarContraseña.Image = StatusPasswordChar ? Resources.ver_password_red_33 : restoreImage;
            txtContraseña.UseSystemPasswordChar = !StatusPasswordChar;
        }

        private void startHome() 
        {
            Application.Run(new Home(usuario));
        }
    }
}
