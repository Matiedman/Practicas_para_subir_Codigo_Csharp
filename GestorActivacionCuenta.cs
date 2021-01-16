using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;

//using AForge.Imaging;

namespace AngularMVCProject.Models
{
    public class GestorActivacionCuenta
    {
        //Metodos, funciones de la 'ActivacionCuenta' por medio de la clase 'GestorActivacionCuenta'.
        /*public TemplateMatch[] ProcessImage(Image dniFrontal, Image dniDorsal)
        {

        }*/
        private static bool activada = false;

        public bool ActivacionCuenta(string fotoDniFrontal, string fotoDniDorsal, string dni) //Validar que SOLO sean imagenes.
        {
            byte[] bytesFotoFrontal = Convert.FromBase64String(fotoDniFrontal);
            byte[] bytesFotoDorsal = Convert.FromBase64String(fotoDniDorsal); // Convierte la cadena especificada, que codifica los datos binarios como dígitos
                                                                              // en base 64, en una matriz equivalente de enteros de 8 bits sin signo.
                                                                              // En otras palabras, convierte la cadena base 64 a un array de bytes. 
                                                                              // Luego se asigna a la variable de tipo byte[].

            // Stream myStream = openFileDialog.OpenFile(); // Es para leer lo que se tiene en al abrir el archivo de dialogo (Win Forms).
            //Verificacion de las imagenes.
            string StrConn = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=dbHomeBank;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                try
                {
                    conn.Open();

                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "INSERT INTO Products VALUES (@id, @name, @quantity, @price, @image)"; //Va a la BD.
                                                                                                              // Creo que es el proc almacenado
                    comm.CommandType = System.Data.CommandType.StoredProcedure;

                    // Creando los parámetros necesarios
                    comm.Parameters.Add("@imagefrontal", System.Data.SqlDbType.Image);
                    comm.Parameters.Add("@imageDorsal", System.Data.SqlDbType.Image);

                    // Asignando los valores a los atributos

                    // Asignando el valor de la imagen

                    //Las siguientes seis lineas pueden no ser necesarias, ya que en la linea 67 y 68 la asignacion del lado
                    // derecho podria reemplazarce por 'bytesFotoFrontal' y 'bytesFotoDorsal' que estan en la linea 24 y 25. Habria que probar.
                    // Almaceno la imagen 
                    Image imagenFrontal = Image.FromFile(fotoDniFrontal);
                    Image imagenDorsal = Image.FromFile(fotoDniDorsal);
                    // Stream usado como buffer
                    // Se hace un MemoryStream para poder convertir el string de la imagen en un Array de bytes[].
                    MemoryStream memAux1 = new MemoryStream();
                    MemoryStream memAux2 = new MemoryStream();

                    // Se guarda la imagen en el buffer
                    imagenFrontal.Save(memAux1, ImageFormat.Jpeg);
                    imagenDorsal.Save(memAux2, ImageFormat.Jpeg);

                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.
                    comm.Parameters["@imagefrontal"].Value = memAux1.GetBuffer();
                    comm.Parameters["@imageDorsal"].Value = memAux2.GetBuffer();


                    conn.Close();
                    if (!(dniIsOK(dni)))
                    {
                        throw new Exception("Dni duplicado o incorrecto.");
                    }
                    activada = true;
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    //MessageBox.Show(ex.Message);
                }
            }
            return true;
        }        
        public bool isCuentaActivada()
        {
            if (activada)
            {
                //"Si, su cuenta se encuentra activa."
                return true;
            }
            return false;
        }

        /*
        private bool formatoImagen()
        {
            if (ImageFormat.GetType())
            {

            }
        }
        
        private bool EqualsFotoDni()
        {
            if ()
            {

            }
            else
            {
                throw new Exception("Las fotos del Dni no son iguales.");
            }
        }

        private bool dosFotos()
        {
            if (hayDosFotos)
            {
                return true;
            }
            else
            {
                throw new Exception("Es necesario que haya dos fotos, frontal y dorsal, del dni para activar la cuenta.");
            }

        }*/

        private bool dniIsOK(string dni)
        {
            if (dniDeBasedeDAtos.equals(dni))
            {
                bool comprobado = true;
                return comprobado;
            }
            else
            {
                throw new Exception("El dni ingresado no es igual...");
            }
        }
    }
}
/*
private bool equalsDni()
{
    if (dni = dni)
    {
        return true;
    }
    else
    {
        throw new Exception("El dni ingresado no corresponde al dni de la persona que ud creo antes"); // Ver bien esto. Como hacerlo mejor.
    }
}
}
}*/

/*{ 
 * public bool ActivacionCuenta(byte fotoDniFrontal, byte fotoDniDorsal, string dni) //Validar que SOLO sean imagenes.
        {
            string StrConn = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=dbHomeBank;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(StrConn))
            {
                try
                {
                    string rutaDeLaImagen = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    Metafile imgFrontal = new Metafile(@"dniFrontal");
                    formatoImagen();
                    //EqualsFotoDni();
                    dosFotos(); //Que se active solo al recibir dos fotos + dni verificado.
                    dniIsOK(string dni);
                    equalsDni();

                    //Mostrar en pantalla "Su cuenta ha sido activada correctamente!. Gracias por confiar en CatBank!.
                    return true;
                }
                catch (Exception fail)
                {
                    //"No se ha podido activar su cuenta. El error es el siguiente: \n"
                    //Mostrar.fail;
                    return false;
                }
            }
        }
}*/

/*string rutaDeLaImagen = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            * try{
                   Metafile imgFrontal = new Metafile(@"dniFrontal");
                   formatoImagen();
                   //EqualsFotoDni();
                   dosFotos(); //Que se active solo al recibir dos fotos + dni verificado.
                   dniIsOK(string dni);
                   equalsDni();

                   //Mostrar en pantalla "Su cuenta ha sido activada correctamente!. Gracias por confiar en CatBank!.
                   return true;
               }
               catch (Exception fail)
               {
                   //"No se ha podido activar su cuenta. El error es el siguiente: \n"
                   //Mostrar.fail;
                   return false;
               }
           */