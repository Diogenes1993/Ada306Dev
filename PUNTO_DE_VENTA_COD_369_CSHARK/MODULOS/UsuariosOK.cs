using PUNTO_DE_VENTA_COD_369_CSHARK.CONEXIONLOG;
using System;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Text.RegularExpressions;

namespace PUNTO_DE_VENTA_COD_369_CSHARK
{
    public partial class UsuariosOK : Form
    {
        public UsuariosOK()
        {
            InitializeComponent();

        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        #region Metodos no vinculados a un control
        private void reinicio()
        {
            id = "";
            lblEligeIcon.Visible = true;
            txtNombre.Text = "";
            txtUser.Text = "";
            txtContra.Text = "";
            txtEmail.Text = "";
            nombre_icon = "";
            cmRol.SelectedIndex = 0;
            pcbIcon.BackgroundImage = null;
            panelcontainerdata.Visible = true;
            btnGuardar.Visible = true;
            btnGuardarCambio.Visible = false;
        }

        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection conex = new SqlConnection();
                conex.ConnectionString = ConexionBD.conexion;
                conex.Open();
                da = new SqlDataAdapter("mostrar_usuario", conex);
                da.Fill(dt);
                tblContent.DataSource = dt;
                conex.Close();
                tblContent.Columns[1].Visible = false;
                tblContent.Columns[5].Visible = false;
                tblContent.Columns[6].Visible = false;
                tblContent.Columns[7].Visible = false;
                tblContent.Columns[8].Visible = false;

                panelcontainerdata.Visible = false;
            }

            
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            CONEXIONLOG.Utilidades.Multiplayer(ref tblContent);
        }



        private void estadPanelIcon(Boolean estado)
        {
            lblEligeIcon.Visible = estado;
            panelIcono.Visible = estado;
        }

        private void visible(Boolean activo)
        {
            panelcontainerdata.Visible = activo;
            panelviewdata.Visible = activo;
        }

        public bool validar_Email(string email)
        {
            return Regex.IsMatch(email, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void cargar_Estado_Icono()
        {
            try
            {
                foreach (DataGridViewRow row in tblContent.Rows)
                {
                    try
                    {
                        string icono = Convert.ToString(row.Cells["Nombre_de_Icono"].Value);

                        if (icono == "1")
                        {
                            pcbmuestra1.Visible = false;
                        }
                        if (icono == "2")
                        {
                            pcbmuestra2.Visible = false;
                        }
                        if (icono == "3")
                        {
                            pcbmuestra3.Visible = false;
                        }
                        if (icono == "4")
                        {
                            pcbmuestra4.Visible = false;
                        }
                        if (icono == "5")
                        {
                            pcbmuestra5.Visible = false;
                        }
                        if (icono == "6")
                        {
                            pcbmuestra6.Visible = false;
                        }
                        if (icono == "7")
                        {
                            pcbmuestra7.Visible = false;
                        }
                        if (icono == "8")
                        {
                            pcbmuestra8.Visible = false;
                        }

                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex)
            {

            }
        }



        #endregion

        #region Variables privadas 

        private string id = "1";
        private string nombre_icon = "";

        #endregion
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar_Email(txtEmail.Text) == false)
            {
                MessageBox.Show("Direccion de correo electronico no valido");
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
            else
            {

                if (txtNombre.Text != "")
                {
                    try
                    {
                        SqlConnection conex = new SqlConnection();
                        conex.ConnectionString = ConexionBD.conexion;
                        conex.Open();
                        SqlCommand cmd = new SqlCommand("insertar_usuario", conex);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@login", txtUser.Text);
                        cmd.Parameters.AddWithValue("@pass", txtContra.Text);

                        cmd.Parameters.AddWithValue("@correo", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@rol", cmRol.Text);
                        cmd.Parameters.AddWithValue("@estado", "ACTIVO");

                        System.IO.MemoryStream memorybyte = new System.IO.MemoryStream();
                        pcbIcon.Image.Save(memorybyte, pcbIcon.Image.RawFormat);

                        cmd.Parameters.AddWithValue("@icono", memorybyte.GetBuffer());
                        cmd.Parameters.AddWithValue("@nombre_icono", nombre_icon);
                        cmd.ExecuteNonQuery();
                        conex.Close();
                        mostrar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }




        private void pcbmuestra1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mensaje pasando");
            pcbIcon.Image = pcbmuestra1.Image;
            MessageBox.Show("Mensaje pasado");
            nombre_icon = "1";
            estadPanelIcon(false);

        }

        private void lblEligeIcon_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
            cargar_Estado_Icono();

        }


        private void pcbmuestra2_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra2.Image;
            nombre_icon = "2";

            estadPanelIcon(false);
        }

        private void pcbmuestra3_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra3.Image;
            nombre_icon = "3";

            estadPanelIcon(false);
        }

        private void pcbmuestra4_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra4.Image;
            nombre_icon = "4";

            estadPanelIcon(false);
        }

        private void pcbmuestra5_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra5.Image;
            nombre_icon = "5";

            estadPanelIcon(false);
        }

        private void pcbmuestra6_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra6.Image;
            nombre_icon = "6";
            estadPanelIcon(false);
        }

        private void pcbmuestra7_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra7.Image;
            nombre_icon = "7";
            estadPanelIcon(false);
        }

        private void pcbmuestra8_Click(object sender, EventArgs e)
        {
            pcbIcon.Image = pcbmuestra8.Image;
            nombre_icon = "8";
            estadPanelIcon(false);
        }

        private void UsuariosOK_Load(object sender, EventArgs e)
        {
            panelcontainerdata.Visible = false;
            panelIcono.Visible = false;
            mostrar();
        }

        private void pcbAgregar_Click(object sender, EventArgs e)
        {
            reinicio();

        }

        private void tblContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = tblContent.SelectedCells[1].Value.ToString();
            txtNombre.Text = tblContent.SelectedCells[2].Value.ToString();
            txtUser.Text = tblContent.SelectedCells[3].Value.ToString();
            txtContra.Text = tblContent.SelectedCells[4].Value.ToString();
            nombre_icon = tblContent.SelectedCells[6].Value.ToString();
            txtEmail.Text = tblContent.SelectedCells[7].Value.ToString();
            cmRol.Text = tblContent.SelectedCells[8].Value.ToString();

            pcbIcon.BackgroundImage = null;
            byte[] b = (Byte[])tblContent.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            pcbIcon.Image = Image.FromStream(ms);
            pcbIcon.SizeMode = PictureBoxSizeMode.Zoom;

            lblEligeIcon.Visible = false;
            panelcontainerdata.Visible = true;
            btnGuardar.Visible = false;
            btnGuardarCambio.Visible = true;


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelcontainerdata.Visible = false;
        }

        private void btnGuardarCambio_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                try
                {
                    SqlConnection conex = new SqlConnection();
                    conex.ConnectionString = ConexionBD.conexion;
                    conex.Open();
                    SqlCommand cmd = new SqlCommand("actualizar_usuario", conex);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idusuario", id);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@login", txtUser.Text);
                    cmd.Parameters.AddWithValue("@pass", txtContra.Text);

                    cmd.Parameters.AddWithValue("@correo", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@rol", cmRol.Text);

                    System.IO.MemoryStream memorybyte = new System.IO.MemoryStream();
                    pcbIcon.Image.Save(memorybyte, pcbIcon.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@icono", memorybyte.GetBuffer());
                    cmd.Parameters.AddWithValue("@nombre_icono", nombre_icon);
                    cmd.ExecuteNonQuery();
                    conex.Close();
                    mostrar();
                    reinicio();
                    panelcontainerdata.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void pcbIcon_Click(object sender, EventArgs e)
        {
            panelIcono.Visible = true;
        }

        private void tblContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.tblContent.Columns["Delete"].Index)
            {
                DialogResult resul;
                resul = MessageBox.Show("¿Realmente desea eliminar este Usuario?", "Eliminando Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resul == DialogResult.OK)
                {
                    try
                    {
                        foreach (DataGridViewRow row in tblContent.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string user = Convert.ToString(row.Cells["Login"].Value);

                            SqlConnection conex = new SqlConnection();
                            conex.ConnectionString = ConexionBD.conexion;
                            conex.Open();
                            SqlCommand cmd = new SqlCommand("eliminar_usuario", conex);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idusuario", onekey);
                            cmd.Parameters.AddWithValue("@login", user);
                            cmd.ExecuteNonQuery();
                            conex.Close();
                            mostrar();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }

        private void pcbseleccion_Click(object sender, EventArgs e)
        {
            DialogFile.InitialDirectory = "";
            DialogFile.Filter = "Imagenes|*.jpg;*.png";
            DialogFile.FilterIndex = 2;
            DialogFile.Title = "Cargador de Imagenes";
            if (DialogFile.ShowDialog() == DialogResult.OK)
            {
                pcbIcon.BackgroundImage = null;
                pcbIcon.Image = new Bitmap(DialogFile.FileName);
                pcbIcon.SizeMode = PictureBoxSizeMode.Zoom;
                nombre_icon=Path.GetFileName(DialogFile.FileName);
                lblEligeIcon.Visible = false;
                panelIcono.Visible = false;
    }
        }
    }
}

            