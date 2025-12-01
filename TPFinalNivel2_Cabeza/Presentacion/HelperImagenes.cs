using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public static class HelperImagenes
    {
        //trato de mantener la modulariad siempre que puedo

        public static string ObtenerImagenSeleccionada(string imagen)
        {
            if (string.IsNullOrEmpty(imagen))
                return IconosImagenes.ImagenesPorDefecto["SinImagen"];
            try
            {
                if (imagen.StartsWith("http"))
                    return imagen;
                else
                    return File.Exists(imagen) ? imagen : IconosImagenes.ImagenesPorDefecto["ImagenNoEncontrada"];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string SeleccionarImagen()
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            archivo.Title = "Seleccionar imagen";
            try
            {
                if (archivo.ShowDialog() == DialogResult.OK)
                {
                    return archivo.FileName;
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }

        }

        public static string CopiarImagenSeleccionada(string urlOrigen, string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(urlOrigen) || !File.Exists(urlOrigen))
                    return "";

                string carpetaDestino = ConfigurationManager.AppSettings["images-folder"];
                Directory.CreateDirectory(carpetaDestino);

                string extension = Path.GetExtension(urlOrigen);
                string destino = Path.Combine(carpetaDestino, nombre + extension);

                //Esta parte me ayudé con IA (copilot) para evitar problemas de locks al copiar
                //Mi idea es que si el usuairo le quiere cambiar la imagen del producto tambien la cambie en su carpeta
                // Copiar con FileStream para evitar locks
                using (var fsOrigen = new FileStream(urlOrigen, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
                {
                    fsOrigen.CopyTo(fsDestino);
                }

                return destino;
            }
            catch
            {
                throw;
            }
        }
    }
}
