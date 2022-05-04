using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIwindowsForms.Properties;
using LogicModel;
using System.Drawing;
using System.Reflection;
using System.Resources;

namespace UIwindowsForms.UIElements
{
    public class Buttons : Button
    {
        private Buttons btn;
        private int initialLactionY = 180;
        private int tabIndex = 1;

        #region METODOS
        public void initializebutton(ref List<Buttons> listBtn)
        {
            foreach (var BtnName in PropertiesApp.attributesApp[Settings.Default.AppName])
            {
                propertiesButton(BtnName);
                listBtn.Add(btn);
                initialLactionY += 54;
                tabIndex++;
            }
        }
        #endregion

        private void propertiesButton(string BtnName)
        {
            btn = new Buttons();
            btn.BackColor = Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            btn.Dock = DockStyle.Top;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btn.ForeColor = Color.White;
            btn.Image = imgButton((Menu)Enum.Parse(typeof(Menu), BtnName.Replace(' ','_')));//Resources.//(Image)(resources.GetObject("btnPuntoDeVenta.Image")));
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Location = new Point(0, initialLactionY);
            btn.Name = $"btn{BtnName.Replace(' ','_')}";
            btn.Padding = new Padding(8, 0, 0, 0);
            btn.Size = new Size(230, 54);
            btn.TabIndex = tabIndex;
            btn.Text = BtnName;
            btn.UseVisualStyleBackColor = false;
            //btn.Click += new System.EventHandler(this.btnPuntoDeVenta_Click);
        }

        private Image imgButton(Menu BtnName) 
        {
            switch (BtnName)
            {
                case Menu.Home:
                    return Resources.Home;
                case Menu.Punto_de_venta:
                    return Resources.Punto_de_venta;
                case Menu.Cliente:
                    return Resources.Cliente;
                case Menu.Proveedor:
                    return Resources.Proveedor;
                case Menu.Usuario:
                    return Resources.Usuario;
                case Menu.Consultas:
                    return Resources.Consultas;
            }

            return null;
        }
    }
}
