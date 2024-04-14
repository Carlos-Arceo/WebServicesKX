using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServicesKX.dsDatosTableAdapters;

namespace WebServicesKX
{
    /// <summary>
    /// Descripción breve de WebServicesKX
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicesKX : System.Web.Services.WebService
    {
        reservacionTableAdapter Reservacion = new reservacionTableAdapter();


        [WebMethod]
        public string DevolverNombre()
        {
            return "Carlos Manuel Uuh Arceo";
        }


        [WebMethod]
        public string HoraServidor()
        {
            return DateTime.Now.ToString();
        }



        [WebMethod]
        public string[] BuscarReserva(int folio)
        {
            // Obtener el DataTable con los datos del contacto
            DataTable dataTable = this.Reservacion.GetData(folio);

            // Verificar si el DataTable contiene datos y si hay al menos una fila
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                // Obtener la primera fila del DataTable
                DataRow firstRow = dataTable.Rows[0];

                // Crear un array para almacenar los valores de las columnas
                string[] rowData = new string[dataTable.Columns.Count];

                // Recorrer cada columna de la fila y guardar su valor en el array
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    rowData[i] = firstRow[i].ToString();
                }

                // Devolver el array con los valores del primer registro
                return rowData;
            }
            else
            {
                // Si no se encontraron datos, devolver un array vacío o lanzar una excepción según sea necesario
                return new string[0];
            }
        }
    }
}
