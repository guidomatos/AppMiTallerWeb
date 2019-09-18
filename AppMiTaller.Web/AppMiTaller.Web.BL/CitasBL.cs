using System;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;
using System.Collections.Generic;
using System.Drawing;
using ZXing.QrCode;

namespace AppMiTaller.Web.BL
{
    public class CitasBL
    {
        public CitasBE Obtiene_Texto_Legal(Int32 IdEmpresa, Int32 nid_marca)
        {
            return new CitasDA().Obtiene_Texto_Legal(IdEmpresa, nid_marca);
        }
        public CitasBE Obtiene_Validacion_Km(string patente, int nid_servicio, int nid_marca)
        {
            return new CitasDA().Obtiene_Validacion_Km(patente, nid_servicio, nid_marca);
        }
        
        public Int32 Confirmar(CitasBE ent)
        {
            return new CitasDA().Confirmar(ent);
        }
        public Int32 Anular(CitasBE ent)
        {
            return new CitasDA().Anular(ent);
        }
        public Int32 Reprogramar(CitasBE ent)
        {
            return new CitasDA().Reprogramar(ent);
        }
        public String InsertarCita(CitasBE ent)
        {
            return new CitasDA().InsertarCita(ent);
        }
        public String AsignarClienteColaEspera(CitasBE ent)
        {
            return new CitasDA().AsignarClienteColaEspera(ent);
        }
        public String GetCitaColaEspera(CitasBE ent)
        {
            return new CitasDA().GetCitaColaEspera(ent);
        }
        public CitasBEList Listar_Datos_Cita(CitasBE ent)
        {
            return new CitasDA().Listar_Datos_Cita(ent);
        }
        public CitasBEList VerificarCitasPedientesPlaca(CitasBE ent)
        {
            return new CitasDA().VerificarCitasPedientesPlaca(ent);
        }
        public CitasBEList BuscarCitaPorCodigo(CitasBE ent)
        {
            return new CitasDA().BuscarCitaPorCodigo(ent);
        }
        public CitasBEList ListarHorarioRecord()
        {
            return new CitasDA().ListarHorarioRecord();
        }
        public CitasBEList Listar_Ubigeos_Disponibles(CitasBE ent)
        {
            return new CitasDA().Listar_Ubigeos_Disponibles(ent);
        }
        public CitasBEList ListarTalleresDisponibles_PorFecha(CitasBE ent)
        {
            return new CitasDA().ListarTalleresDisponibles_PorFecha(ent);
        }
        public CitasBEList ListarHorarioExcepcional_Talleres(CitasBE ent)
        {
            return new CitasDA().ListarHorarioExcepcional_Talleres(ent);
        }
        public CitasBEList ListarAsesoresDisponibles_PorFecha(CitasBE ent)
        {
            return new CitasDA().ListarAsesoresDisponibles_PorFecha(ent);
        }
        public CitasBEList ListarCitasAsesores(CitasBE ent)
        {
            return new CitasDA().ListarCitasAsesores(ent);
        }
        public string GetNombreImagenQR(string placa)
        {
            String imgQRCode = String.Concat("img_QR_", placa, "_", DateTime.Now.ToString("yyyyMMddhhmmss"), ".png");
            return imgQRCode;
        }
        public string GetNombreImagenQRWithText(string imagen)
        {
            return imagen.Replace("_QR_", "_QRTEXT_");
        }
        public string SaveImageQRText(string rutaguarda, string nombreimagen, string placa, DateTime fecha, string hora, string marca, string modelo, string color, bool saveQRPNG)
        {
            int proporcionqr = 100;
            int anchotexto = 200;
            int anchototal = anchotexto + proporcionqr;
            int alturatexto = 20;
            string nombreimagentext = GetNombreImagenQRWithText(nombreimagen);
            Bitmap QR = GetBitMapQR(placa, proporcionqr);
            string rutaQRCode = "";
            if (saveQRPNG)
            {
                rutaQRCode = rutaguarda + nombreimagen;
                QR.Save(@rutaQRCode, System.Drawing.Imaging.ImageFormat.Png);
            }
            Bitmap Text = GetBitMapText(anchotexto, proporcionqr, fecha, hora, placa, marca, modelo, color);

            rutaQRCode = rutaguarda + nombreimagentext;
            Bitmap QRText = GetBitMapQRText(anchotexto, proporcionqr, alturatexto, QR, Text);
            QRText.Save(@rutaQRCode, System.Drawing.Imaging.ImageFormat.Png);

            return nombreimagen;
        }
        public Bitmap GetBitMapQR(string placa, int proporcionqr)
        {
            QRCodeWriter qr = new QRCodeWriter();
            IDictionary<ZXing.EncodeHintType, object> hints = new Dictionary<ZXing.EncodeHintType, object>();
            hints.Add(ZXing.EncodeHintType.CHARACTER_SET, "UTF-8");
            hints.Add(ZXing.EncodeHintType.MARGIN, 0);
            string strMensaje = placa;
            var matrix = qr.encode(strMensaje, ZXing.BarcodeFormat.QR_CODE, proporcionqr, proporcionqr, hints);
            ZXing.BarcodeWriter w = new ZXing.BarcodeWriter();
            w.Format = ZXing.BarcodeFormat.QR_CODE;
            System.Drawing.Bitmap imgQR = w.Write(matrix);

            return imgQR;
        }

        public Bitmap GetBitMapText(int anchotexto, int proporcionqr, DateTime fecha, string hora, string placa, string marca, string modelo, string color)
        {
            int fuente = 9;
            Font drawFont = new Font("Arial", fuente, FontStyle.Regular);
            System.Drawing.Bitmap imgTxt = new Bitmap(anchotexto, proporcionqr);
            string fechaformateada = fecha.ToString("dd/MM/yyyy");
            string texto = ""
                            + MySubstring(
                                        //"Placa: " + 
                                        placa) + "\n"
                            + MySubstring(
                                        //"Marca: " + 
                                        marca) + "\n"
                            + MySubstring(
                                        //"Modelo: "+ 
                                        modelo) + " \n"
                            + MySubstring(
                                        //"Color: " + 
                                        color) + "\n"
                            + MySubstring(fechaformateada + " " + FormatoHora(hora));
            RectangleF rectf = new RectangleF(0, 0, anchotexto, proporcionqr);
            Graphics g = Graphics.FromImage(imgTxt);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.DrawString(texto, drawFont, Brushes.Black, rectf);
            g.Flush();

            return imgTxt;
        }

        public Bitmap GetBitMapQRText(int anchotexto, int proporcionqr, int alturatexto, Bitmap QR, Bitmap Text)
        {
            System.Drawing.Bitmap imgBase = new System.Drawing.Bitmap(anchotexto, proporcionqr);
            //get a graphics object from the image so we can draw on it
            using (System.Drawing.Graphics g2 = System.Drawing.Graphics.FromImage(imgBase))
            {
                //set background color
                g2.Clear(System.Drawing.Color.White);

                g2.DrawImage(QR, new System.Drawing.Rectangle(0, 0, proporcionqr, proporcionqr));
                g2.DrawImage(Text, new System.Drawing.Rectangle(proporcionqr, alturatexto, anchotexto, proporcionqr));

                return imgBase;
            }
        }
        public static string MySubstring(string texto)
        {

            int corte = 17;
            if (texto.Length > corte)
            {
                return texto.Substring(0, corte);
            }
            else
            {
                return texto;
            }
        }

        public string FormatoHora(string strHora)
        {
            string strHF = strHora;
            try
            {
                string strHoraF = Convert.ToDateTime(strHora).ToString("hh:mm");
                Int32 strHoraF1 = Convert.ToInt32(strHora.Replace(":", ""));
                strHF = strHoraF + ((strHoraF1 < 1200) ? " a.m." : " p.m.");
            }
            catch (Exception)
            {
                strHF = strHora;
            }
            return strHF;
        }
    }
}