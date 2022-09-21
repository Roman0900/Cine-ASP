using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES
{
    public class Ent_Facturas
    {
        public Ent_Facturas(int NCod_Factura, bool Nestado)
        {
            Cod_Factura = NCod_Factura;
            Estado = Nestado;
        }
        public int Cod_Factura { get; set; }
        public bool Estado { get; set; }
    }
    public class Ent_DetalleXFacturas
    {
        public Ent_DetalleXFacturas(int NCod_Detalle, int NCod_Factura, string NCod_Sala, string NCod_Funcion, int NCod_Butaca,bool Nestado)
        {
            Cod_Detalle = NCod_Detalle;
            Cod_Factura = NCod_Factura;
            Cod_Sala = NCod_Sala;
            Cod_Funcion = NCod_Funcion;
            Cod_Butaca = NCod_Butaca;
            Estado = Nestado;
        }
        public int Cod_Detalle { get; set; }
        public int Cod_Factura { get; set; }
        public string Cod_Sala { get; set; }
        public string Cod_Funcion { get; set; }
        public int Cod_Butaca { get; set; }
        public bool Estado { get; set; }
    }
}
