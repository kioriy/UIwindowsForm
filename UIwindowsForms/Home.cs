using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIwindowsForms.Properties;
using UIwindowsForms.UIElements;
using LogicModel;
using DataAccess.Local;
using DataAccess;

namespace UIwindowsForms
{
    public partial class Home : Form
    {
        private Image restoreImage;
        private Button currentButton;
        private readonly User usuario;
        private Panel leftBorderButton;
        private Buttons btn = new Buttons();
        private List<Buttons> ListButton = new List<Buttons>();

         public Home(User usuario)
        {
            InitializeComponent();
            MessageBox.Show("Voy a iniciarliar los botones");
            btn.initializebutton(ref ListButton);
            MessageBox.Show("Termine");
            MessageBox.Show("Ahora voy a agregar los botones");
            addMenuButtons();
            this.pSidebar.Controls.Add(this.pLogoAndUser);
            MessageBox.Show("Termine de agregar los botones");

            //Crea el panel que sera el selector de los botones
            leftBorderButton = new Panel();
            leftBorderButton.Size = new Size(5, 54);

            //Agrega el panel selector al panel sidebar
            pSidebar.Controls.Add(leftBorderButton);

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.usuario = usuario;
            loadUserData(usuario);
        }

        #region BUTTONS

        #region Menu home
        private void btnHome_Click(object sender, EventArgs e)
        {
            activateButton(sender, Resources.Home_contrast);
        }

        private void btnPuntoDeVenta_Click(object sender, EventArgs e)
        {
            activateButton(sender, Resources.Punto_de_venta_contrast);
        }
        #endregion

        #region Title bar
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = false;
            btnRestore.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            btnMaximize.Visible = true;
            btnRestore.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #endregion

        #region MINE METHODS
        #region Activate and desactivate menu buttons
        private void activateButton(object senderButton, Image imagen)
        {
            if (senderButton != null)
            {
                disableButton();

                currentButton = (Button)senderButton;

                restoreImage = currentButton.Image;
                currentButton.BackColor = Color.FromArgb(239, 243, 246);//Background Gray
                currentButton.ForeColor = Color.FromArgb(23, 26, 43);//Background BlueB
                currentButton.Image = imagen;

                //leftborderButton
                leftBorderButton.BackColor = Color.FromArgb(251, 82, 82);//ElementColor Red;
                leftBorderButton.Location = new Point(0, currentButton.Location.Y);
                leftBorderButton.Visible = true;
                leftBorderButton.BringToFront();

            }
        }

        private void disableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(23, 26, 43);
                currentButton.ForeColor = Color.FromArgb(255, 255, 255);
                currentButton.Image = restoreImage;
            }
        }

        private void loadUserData(User user) 
        {
            lUsuario.Text = "ADMIN"; //usuario.usuario.ToUpperInvariant();
            lPerfil.Text = "ADMIN"; //usuario.perfil.ToUpperInvariant();
        }

        private void addMenuButtons()
        {
            foreach (Button btn in ListButton)
            {
                this.pSidebar.Controls.Add(btn);
            }
        }
        #endregion

        #endregion
    }
}
