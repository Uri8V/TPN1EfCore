using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows.Helpers
{
    public static class GridHelper
    {
        public static void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }

        public static DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;

        }

        public static void QuitarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Remove(r);
        }
        public static void SetearFila(DataGridViewRow r, object item)
        {
            switch (item)
            {
                case Brand brand:
                    r.Cells[0].Value = brand.BrandName;
                    break;
                case Sport sport:
                    r.Cells[0].Value = sport.SportName;
                    break;
                case Genre genre:
                    r.Cells[0].Value = genre.GenreName;
                    break;
                case Colour colour:
                    r.Cells[0].Value = colour.ColorName;
                    break;
                case Size size:
                    r.Cells[0].Value = size.SizeNumber;
                    break;
                case ShoeListDto shoe:
                    r.Cells[0].Value = shoe.brand;
                    r.Cells[1].Value = shoe.sport;
                    r.Cells[2].Value = shoe.genre;
                    r.Cells[3].Value = shoe.color;
                    r.Cells[4].Value = shoe.model;
                    r.Cells[5].Value = shoe.price.ToString();
                    r.Cells[6].Value = shoe.descripcion;
                    break;

                default:
                    break;

            }
            r.Tag = item;
        }

        public static void AgregarFila(DataGridViewRow r, DataGridView dgv)
        {
            dgv.Rows.Add(r);
        }

    }
}
