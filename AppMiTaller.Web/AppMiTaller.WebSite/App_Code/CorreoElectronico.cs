using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Configuration;
using AppMiTaller.Web.BE;
using System.ComponentModel;

public class CorreoElectronico
{
    private string path_server;
    public CorreoElectronico()
    {        
    }
    public CorreoElectronico(string path_server)
    {
        this.path_server = path_server;
    }
    public enum Receptor
    {
        CLIENTE = 0,
        ASESOR_SERVICIO = 1,
        CALL_CENTER = 2,
        IMPRESION = 3
    }

    #region "- Envío de email a Cliente/Asesor/Call Center"
    public void EnviarCorreo_Cliente(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        CorreoElectronico oCorreoElectronico = new CorreoElectronico(System.Web.HttpContext.Current.Server.MapPath("~/"));
        bool flEnvio = oCorreoElectronico.EnviarMensajeCorreo(oDatos, oTipoCita, Parametros.PERSONA.CLIENTE);
        if (!flEnvio)
        {
            //"Error al enviar Correo-Cliente";
        }
    }
    public void EnviarCorreo_Asesor(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        CorreoElectronico oCorreoElectronico = new CorreoElectronico(System.Web.HttpContext.Current.Server.MapPath("~/"));
        bool flEnvio = oCorreoElectronico.EnviarMensajeCorreo(oDatos, oTipoCita, Parametros.PERSONA.ASESOR);
        if (!flEnvio)
        {
            //"Error al enviar Correo-Asesor");
        }
    }
    public void EnviarCorreo_CallCenter(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        CorreoElectronico oCorreoElectronico = new CorreoElectronico(System.Web.HttpContext.Current.Server.MapPath("~/"));
        bool flEnvio = oCorreoElectronico.EnviarMensajeCorreo(oDatos, oTipoCita, Parametros.PERSONA.CALL_CENTER);
        if (!flEnvio)
        {
            //"Error al enviar Correo-CallCenter";
        }
    }
    #endregion "- Envío de email a Cliente/Asesor/Call Center"

    private string GetFechaLarga(DateTime dt)
    {
        return dt.ToString("D", System.Globalization.CultureInfo.CurrentCulture);
    }
    private string FormatoHora(string strHora)
    {
        string strHF = strHora;
        try
        {
            string strHoraF = Convert.ToDateTime(strHora).ToString("hh:mm");
            Int32 strHoraF1 = Convert.ToInt32(strHora.Replace(":", ""));
            strHF = strHoraF + (((strHoraF1 < 1200)) ? " a.m." : " p.m.");
        }
        catch (Exception)
        {
            strHF = strHora;
        }
        return strHF;
    }
    private Int32 getDiaSemana(DateTime dtFecha)
    {
        Int32 intDia = 0;
        switch (dtFecha.DayOfWeek)
        {
            case DayOfWeek.Monday: intDia = 1; break;
            case DayOfWeek.Tuesday: intDia = 2; break;
            case DayOfWeek.Wednesday: intDia = 3; break;
            case DayOfWeek.Thursday: intDia = 4; break;
            case DayOfWeek.Friday: intDia = 5; break;
            case DayOfWeek.Saturday: intDia = 6; break;
            case DayOfWeek.Sunday: intDia = 7; break;
        }
        return intDia;
    }
    private string getNombreDiaSemana(Int32 intDia)
    {
        string strDia = string.Empty;
        switch (intDia)
        {
            case 1: strDia = "Lunes"; break;
            case 2: strDia = "Martes"; break;
            case 3: strDia = "Mi&eacute;rcoles"; break;
            case 4: strDia = "Jueves"; break;
            case 5: strDia = "Viernes"; break;
            case 6: strDia = "S&aacute;bado"; break;
            case 7: strDia = "Domingo"; break;
        }
        return strDia;
    }
    public StringBuilder CargarPlantilla_Imprimir(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        StringBuilder strBodyHTML = new StringBuilder();
        string strRutaPlantilla = Path.Combine(this.path_server, ConfigurationManager.AppSettings["PlantillaImprimir"]);
        try
        {
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {
                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string flDatosRecorda = Parametros.GetValor(Parametros.PARM._14).ToString();
                string strTipoCita = string.Empty;
                switch (oTipoCita)
                {
                    case Parametros.EstadoCita.REGISTRADA: strTipoCita = "Reserva"; break;
                    case Parametros.EstadoCita.REPROGRAMADA: strTipoCita = "Reprogramacion"; break;
                    case Parametros.EstadoCita.REASIGNADA: strTipoCita = "Asignaci&oacute;n"; break;
                    case Parametros.EstadoCita.ANULADA: strTipoCita = "Anulacion"; break;
                }
                string strTextoPie = Parametros.N_TextoPieCorreo;
                string strNumCallCenter = Parametros.N_TelefonoCallCenter;
                string strVerNota = oDatos.fl_nota;
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("{Cliente}", oDatos.no_cliente.Trim().ToUpper() + " " + oDatos.no_ape_paterno.Trim().ToUpper() + " " + oDatos.no_ape_materno.Trim().ToUpper());                    
                    linea = linea.Replace("{TipoCita}", strTipoCita);
                    linea = linea.Replace("{TipoPlaca}", Parametros.N_Placa + ": ");
                    linea = linea.Replace("{NumPlaca}", oDatos.nu_placa.ToUpper());
                    linea = linea.Replace("{Marca}", oDatos.no_marca.ToUpper());
                    linea = linea.Replace("{Modelo}", oDatos.no_modelo.ToUpper());
                    linea = linea.Replace("{DiaHoraCita}", GetFechaLarga(Convert.ToDateTime(oDatos.fecha_prog)) + " - " + FormatoHora(oDatos.ho_inicio_c));
                    linea = linea.Replace("{TextoAsesor}", Parametros.N_Asesor + ": ");
                    linea = linea.Replace("{Asesor}", oDatos.no_asesor);
                    linea = linea.Replace("{MovilAsesor}", oDatos.nu_telefono_a);
                    linea = linea.Replace("{Servicio}", oDatos.no_servicio.Trim().ToUpper());
                    linea = linea.Replace("{Taller}", oDatos.no_taller);
                    linea = linea.Replace("{TextoLocal}", Parametros.N_Local + ": ");
                    linea = linea.Replace("{PuntoRed}", oDatos.no_ubica);
                    linea = linea.Replace("{Direccion}", oDatos.no_direccion_t + " - " + oDatos.no_distrito.Trim());
                    linea = linea.Replace("{Telefono}", oDatos.nu_telefono_t);
                    linea = linea.Replace("{CodReserva}", oDatos.cod_reserva_cita);
                    linea = linea.Replace("{FormaRecordatorio}", "- Por Email");
                    linea = linea.Replace("{TextoPieCorreo}", strTextoPie);
                    linea = linea.Replace("{UrlTaller}", oDatos.tx_url_taller.Trim());
                    linea = linea.Replace("{CallCenter}", strNumCallCenter);
                    linea = linea.Replace("{blVerNota}", strVerNota.Equals("1") ? "inline" : "none");
                    strBodyHTML.Append(linea);
                }
                
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-2");
        }
        return strBodyHTML;
    }
    public StringBuilder CargarPlantilla_Cliente(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        StringBuilder strBodyHTML = new StringBuilder();
        string strRutaPlantilla = Path.Combine(this.path_server, ConfigurationManager.AppSettings["PlantillaCorreo"]);
        try
        {
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {
                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string flDatosRecorda = Parametros.GetValor(Parametros.PARM._14).ToString();
                string strTipoCita = string.Empty;
                switch (oTipoCita)
                {
                    case Parametros.EstadoCita.REGISTRADA: strTipoCita = "Reserva"; break;
                    case Parametros.EstadoCita.REPROGRAMADA: strTipoCita = "Reprogramacion"; break;
                    case Parametros.EstadoCita.REASIGNADA: strTipoCita = "Asignaci&oacute;n"; break;
                    case Parametros.EstadoCita.ANULADA: strTipoCita = "Anulacion"; break;
                }
                string strTextoPie = Parametros.N_TextoPieCorreo;
                string strNumCallCenter = Parametros.N_TelefonoCallCenter;
                string strVerNota = oDatos.fl_nota;
                string linea = null;                
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("{Cliente}", oDatos.no_cliente.Trim().ToUpper() + " " + oDatos.no_ape_paterno.Trim().ToUpper() + " " + oDatos.no_ape_materno.Trim().ToUpper());
                    linea = linea.Replace("{TipoCita}", strTipoCita);
                    linea = linea.Replace("{TipoPlaca}", Parametros.N_Placa + ": ");
                    linea = linea.Replace("{NumPlaca}", oDatos.nu_placa.ToUpper());
                    linea = linea.Replace("{Marca}", oDatos.no_marca.ToUpper());
                    linea = linea.Replace("{Modelo}", oDatos.no_modelo.ToUpper());
                    linea = linea.Replace("{DiaHoraCita}", GetFechaLarga(Convert.ToDateTime(oDatos.fecha_prog)) + " - " + FormatoHora(oDatos.ho_inicio_c));
                    linea = linea.Replace("{TextoAsesor}", Parametros.N_Asesor + ": ");
                    linea = linea.Replace("{Asesor}", oDatos.no_asesor);
                    linea = linea.Replace("{MovilAsesor}", oDatos.nu_telefono_a);
                    linea = linea.Replace("{Servicio}", oDatos.no_servicio.Trim().ToUpper());
                    linea = linea.Replace("{Taller}", oDatos.no_taller);
                    linea = linea.Replace("{TextoLocal}", Parametros.N_Local + ": ");
                    linea = linea.Replace("{PuntoRed}", oDatos.no_ubica);
                    linea = linea.Replace("{Direccion}", oDatos.no_direccion_t + " - " + oDatos.no_distrito.Trim());
                    linea = linea.Replace("{Telefono}", oDatos.nu_telefono_t);
                    linea = linea.Replace("{CodReserva}", oDatos.cod_reserva_cita);
                    linea = linea.Replace("{FormaRecordatorio}", "- Por Email");
                    linea = linea.Replace("{TextoPieCorreo}", strTextoPie);
                    linea = linea.Replace("{UrlTaller}", oDatos.tx_url_taller.Trim());
                    linea = linea.Replace("{CallCenter}", strNumCallCenter);
                    linea = linea.Replace("{blVerNota}", strVerNota.Equals("1") ? "inline" : "none");
                    strBodyHTML.Append(linea);
                }

                reader.Close();
            }
        }
        catch (Exception ex)
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-2");
        }
        return strBodyHTML;
    }
    private StringBuilder CargarPlantilla_Asesor(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        StringBuilder strBodyHTML = new StringBuilder();
        string strRutaPlantilla = Path.Combine(this.path_server, ConfigurationManager.AppSettings["PlantillaCorreoAsesor"]);
        try
        {
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {
                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string strTipoCita = string.Empty;
                switch (oTipoCita)
                {
                    case Parametros.EstadoCita.REGISTRADA: strTipoCita = "Reserva"; break;
                    case Parametros.EstadoCita.REPROGRAMADA: strTipoCita = "Reprogramacion"; break;
                    case Parametros.EstadoCita.REASIGNADA: strTipoCita = "Asignaci&oacute;n"; break;
                    case Parametros.EstadoCita.ANULADA: strTipoCita = "Anulacion"; break;
                }
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("{Asesor}", oDatos.no_asesor.Trim().ToUpper());
                    linea = linea.Replace("{TipoCita}", strTipoCita);
                    linea = linea.Replace("{FechaCita}", GetFechaLarga(Convert.ToDateTime(oDatos.fecha_prog)).ToUpper());
                    linea = linea.Replace("{HoraCita}", FormatoHora(oDatos.ho_inicio_c));
                    linea = linea.Replace("{Cliente}", oDatos.no_cliente.Trim().ToUpper() + " " + oDatos.no_ape_paterno.Trim().ToUpper() + " " + oDatos.no_ape_materno.Trim().ToUpper());
                    linea = linea.Replace("{Servicio}", oDatos.no_servicio.ToUpper());
                    linea = linea.Replace("{TipoPlaca}", Parametros.N_Placa + ":");
                    linea = linea.Replace("{Placa}", oDatos.nu_placa.ToUpper());
                    linea = linea.Replace("{Marca}", oDatos.no_marca);
                    linea = linea.Replace("{Modelo}", oDatos.no_modelo);
                    strBodyHTML.Append(linea);
                }
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-1");
        }
        return strBodyHTML;
    }
    private StringBuilder CargarPlantilla_CallCenter(CitasBE oDatos, Parametros.EstadoCita oTipoCita)
    {
        StringBuilder strBodyHTML = new StringBuilder();
        string strRutaPlantilla = Path.Combine(this.path_server, ConfigurationManager.AppSettings["PlantillaCorreoCallCenter"]);
        try
        {
            if (!File.Exists(strRutaPlantilla))
                strBodyHTML.Append("-1");
            else
            {
                FileStream stream = new FileStream(strRutaPlantilla, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string strTipoCita = string.Empty;
                switch (oTipoCita)
                {
                    case Parametros.EstadoCita.REGISTRADA: strTipoCita = "Reserva"; break;
                    case Parametros.EstadoCita.REPROGRAMADA: strTipoCita = "Reprogramacion"; break;
                    case Parametros.EstadoCita.REASIGNADA: strTipoCita = "Asignaci&oacute;n"; break;
                    case Parametros.EstadoCita.ANULADA: strTipoCita = "Anulacion"; break;
                }
                string linea = null;
                while (reader.Peek() > -1)
                {
                    linea = reader.ReadLine().ToString();
                    linea = linea.Replace("{Asesor}", oDatos.no_asesor.Trim().ToUpper());
                    linea = linea.Replace("{TipoCita}", strTipoCita);
                    linea = linea.Replace("{FechaCita}", GetFechaLarga(Convert.ToDateTime(oDatos.fecha_prog)).ToUpper());
                    linea = linea.Replace("{HoraCita}", FormatoHora(oDatos.ho_inicio_c));
                    linea = linea.Replace("{Cliente}", oDatos.no_cliente.Trim().ToUpper() + " " + oDatos.no_ape_paterno.Trim().ToUpper() + " " + oDatos.no_ape_materno.Trim().ToUpper());
                    linea = linea.Replace("{Servicio}", oDatos.no_servicio.ToUpper());
                    linea = linea.Replace("{TipoPlaca}", Parametros.N_Placa + ":");
                    linea = linea.Replace("{Placa}", oDatos.nu_placa.ToUpper());
                    linea = linea.Replace("{Marca}", oDatos.no_marca);
                    linea = linea.Replace("{Modelo}", oDatos.no_modelo);
                    strBodyHTML.Append(linea);
                }
                reader.Close();
            }
        }
        catch
        {
            strBodyHTML = new StringBuilder();
            strBodyHTML.Append("-1");
        }
        return strBodyHTML;
    }


    private string _no_error;
    public string no_error
    {
        get { return _no_error; }
        set { _no_error = value; }
    }
    //static bool mailSent = false;
    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        MailMessage mail = (MailMessage)e.UserState;
        string no_asunto = mail.Subject;
        if (e.Error != null)
        {
            //mailSent = false;
        }
        else if (e.Cancelled)
        {
            //mailSent = false;
        }
        else
        {
            //mailSent = true;
        }
    }

    public bool EnviarMensajeCorreo(CitasBE oDatos, Parametros.EstadoCita oTipoCita, Parametros.PERSONA oPersona)
    {
        bool flEnvio = true;
        Int32 intResp = 0;
        StringBuilder strHTML = new StringBuilder();
        switch (oPersona)
        {
            case Parametros.PERSONA.CLIENTE: strHTML = CargarPlantilla_Cliente(oDatos, oTipoCita); break;
            case Parametros.PERSONA.ASESOR: strHTML = CargarPlantilla_Asesor(oDatos, oTipoCita); break;
            case Parametros.PERSONA.CALL_CENTER: strHTML = CargarPlantilla_CallCenter(oDatos, oTipoCita); break;
            case Parametros.PERSONA.IMPRIMIR: strHTML = CargarPlantilla_Imprimir(oDatos, oTipoCita); break;
        }
        //Validando retorno del HTML
        if (strHTML.ToString().Equals("-1") || strHTML.ToString().Equals("-2"))
        {
            //-1 Error al cargar la Plantilla
            //-2 Error al rrellenar Plantilla
            intResp = Int32.Parse(strHTML.ToString());
            flEnvio = false;
        }
        else
        {
            MailMessage oEmail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            try
            {
                string strAsunto = string.Empty;
                switch (oTipoCita)
                {
                    case Parametros.EstadoCita.REGISTRADA: strAsunto = "SubjectCitaReserv"; break;
                    case Parametros.EstadoCita.REPROGRAMADA: strAsunto = "SubjectCitaReprog"; break;
                    case Parametros.EstadoCita.REASIGNADA: strAsunto = "SubjectCitaAsigna"; break;
                    case Parametros.EstadoCita.ANULADA: strAsunto = "SubjectCitaAnula"; break;
                    
                }
                oEmail.From = new MailAddress(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["DisplayName"]);


                switch (oPersona)
                {

                    case Parametros.PERSONA.CLIENTE:
                        if (!(oDatos.no_correo.Trim().ToString().Equals(""))) { oEmail.To.Add(oDatos.no_correo.Trim()); }
                            if (!(oDatos.no_correo_trabajo.Trim().ToString().Equals(""))) { oEmail.To.Add(oDatos.no_correo_trabajo.Trim()); }
                        
                        break;
                    case Parametros.PERSONA.ASESOR:
                        oEmail.To.Add(oDatos.no_correo_asesor.Trim());
                        break;
                    case Parametros.PERSONA.CALL_CENTER:
                        oEmail.To.Add(oDatos.no_correo_callcenter.Trim());
                        break;
                }
                System.Collections.Specialized.NameValueCollection nvc = (System.Collections.Specialized.NameValueCollection)ConfigurationManager.GetSection("groupAGP/sectionEmail");
                oEmail.Subject = ConfigurationManager.AppSettings[strAsunto];
                oEmail.Body = strHTML.ToString();
                oEmail.IsBodyHtml = true;
                oEmail.Priority = System.Net.Mail.MailPriority.High;
                smtp.Host = nvc[0].ToString();
                smtp.Port = Int32.Parse(nvc[1].ToString());
                smtp.Credentials = new System.Net.NetworkCredential(nvc[2].ToString(), nvc[3].ToString());
                smtp.EnableSsl = true;

                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                object userState = oEmail;
                try
                {
                    //smtp.Send(oEmail);
                    smtp.SendAsync(oEmail, userState);
                }
                catch (Exception ex)
                {
                    no_error = string.Format("{0}|{1}", ex.Message, (ex.InnerException != null ? ex.InnerException.Message : string.Empty));
                    //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
                }
                finally
                { }
            }
            catch
            {
                flEnvio = false;
                //System.Web.HttpContext.Current.Response.Write("1 > " + ex.Message);
            }
            finally
            {
                oEmail = null;
                smtp = null;
            }
        }
        return flEnvio;
    }

}