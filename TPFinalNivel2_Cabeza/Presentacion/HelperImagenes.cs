using System;
using System.Configuration;
using System.Drawing;
using System.IO;
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

        public static string CopiarImagenSeleccionada(string urlOrigen, string nombre, string urlSecundaria = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(urlOrigen) || !File.Exists(urlOrigen))
                    return "";
                //Lo quito porque no pude probar bien el tema de los locks
                if (urlOrigen == urlSecundaria)
                    return urlSecundaria; // La imagen ya es la misma (no se cambia)
                

                string carpetaDestino = ConfigurationManager.AppSettings["images-folder"];
                Directory.CreateDirectory(carpetaDestino);


                string extension = Path.GetExtension(urlOrigen);
                string destino = Path.Combine(carpetaDestino, nombre + extension);

                // Tuve muchos problemas con esta funcionalidad
                // pero era porque la dejaba cargada en un PictureBox del frmGestion
                //Esta parte me ayudé con IA (copilot) para evitar problemas de locks al copiar
                //Mi idea es que si el usuario le quiere cambiar la imagen del producto
                //tambien la cambie en su carpeta 

                string[] extensionesPosibles = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                foreach (var ext in extensionesPosibles)
                {
                    string posible = Path.Combine(carpetaDestino, nombre + ext);
                    if (File.Exists(posible))
                    {
                        File.Delete(posible); // Eliminar la versión anterior
                    }
                }
                File.Copy(urlOrigen, destino, true);
                return destino;
            }
            catch
            {
                throw;
            }
        }

        public static void CargarImagenSinLock(PictureBox pb, string ruta)
        {
            if (pb.Image != null)
            {
                pb.Image.Dispose();
                pb.Image = null;
            }

            using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
            using (var imgTemp = Image.FromStream(fs))
            {
                pb.Image = new Bitmap(imgTemp);
            }
        }

        public static void EliminarImagen(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta))
                return;
            if (ruta.StartsWith("http"))
                return;
            try
            {
                if (File.Exists(ruta))
                {
                    File.Delete(ruta);
                }
            }
            catch (Exception)
            {
                throw new Exception("No se eliminó ninguna imagen.\nSi tenía una copia en el disco elimínela manualmente");
            }
        }
    }
}
