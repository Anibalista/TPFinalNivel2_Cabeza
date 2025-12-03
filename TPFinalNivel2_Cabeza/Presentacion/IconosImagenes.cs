using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Presentacion
{
    public static class IconosImagenes
    {
        public static readonly Dictionary<string, string> ImagenesPorDefecto = new Dictionary<string, string>
        {
            { "SinImagen",  Path.Combine(Application.StartupPath, "imagenes", "Sin_Imagen_Logo.png") },
            { "ImagenNoEncontrada", Path.Combine(Application.StartupPath, "imagenes", "Imagen_no_encontrada_logo.png") },
            { "ImagenError", Path.Combine(Application.StartupPath, "imagenes", "icono_error.png") }
        };
    }
}
