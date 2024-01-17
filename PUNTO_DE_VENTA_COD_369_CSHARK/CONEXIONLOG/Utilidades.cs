using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUNTO_DE_VENTA_COD_369_CSHARK.CONEXIONLOG
{
    public class Utilidades
    {
        public static void Multiplayer(ref DataGridView tabla)
        {
            tabla.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.AllCells;
            tabla.ColumnHeadersDefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
            tabla.DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;
            tabla.DefaultCellStyle.WrapMode=DataGridViewTriState.True;

            tabla.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle styleHeader=new DataGridViewCellStyle();
            styleHeader.BackColor=System.Drawing.Color.White;
            styleHeader.ForeColor = System.Drawing.Color.Black;
            styleHeader.Font = new Font("Segoe UI",10,FontStyle.Bold);
            tabla.ColumnHeadersDefaultCellStyle = styleHeader;
        }
    }
}
