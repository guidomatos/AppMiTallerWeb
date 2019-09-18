<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SRC_ResumenCita.aspx.cs" Inherits="SRC_ResumenCita" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="bg_blue">
        <div id="divPage_Paso3">
            <div class="titulo_pasos">
                Paso 3 de 3: Resumen de Cita.</div>
            <div class="titulo_section">
                5. Reserva realizada</div>
            <div class="titulo_section">
                El Código de Reserva de es:
                <label id="lblCodCita">
                </label>
            </div>
            <div class="row col">
                Ud. ha reservado una Cita:
            </div>
            <div class="row col">
                Servicio Técnico:
                <label id="lblTallerCita">
                </label>
            </div>
            <div class="row col">
                Fecha:
                <label id="lblFechaCita" class="titulo_section">
                </label>
            </div>
            <div class="row col">
                Hora:
                <label id="lblHoraCita" class="titulo_section">
                </label>
            </div>
            <div class="row col">
                Asesor de Servicio:
                <label id="lblAsesorCita">
                </label>
            </div>
            <div class="row col" style="padding-top: 20px;">
                Para reprogramar o anular su Cita, utilice el código asignado.
            </div>
            <div class="row col" style="padding-top: 20px;">
                <b>Los datos de su cita fueron enviados por correo electrónico</b>
            </div>
            <div class="row col" style="padding-top: 20px;">
                <b>DATOS DE CONTACTO PARA CONSULTAS</b>
            </div>
            <div class="row col">
                <label id="lblTelfTaller">
                </label>
            </div>
            <div class="row col">
                <label id="lblTelfAsesor">
                </label>
            </div>
            <div class="row col">
                <label id="lblTelCallCenter">
                </label>
            </div>
            <div class="row">
                <div class="col l2 s12 x12">
                    <button id="btnImprimir" type="button" style="display:none">Imprimir</button>
                </div>
                <div id="divbtnConfirmar" class="col l2 s12 x12">
                    <button id="btnConfirmar" type="button" onclick="fn_Confirmar()" style="display:none">Confirmar Cita</button>
                </div>
                <div class="col l2 s12 x12">
                    <button id="btnAnular" type="button" onclick="fn_AnularCita()" style="display:none">Anular Cita</button>
                </div>
                <div class="col l6 s12 x12">
                    <button id="btnReprogramar" type="button" onclick="fn_ReprogramarCita()" style="display:none">Reprogramar Cita</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "SRC_ResumenCita.aspx";
        var oCita = { nid_cita: 0, nu_estado: "" };
        function fn_GetResumen(obj_nid_cita) {
            var strParametros = "{'codC':" + obj_nid_cita + "}";
            var strUrlServicio = no_pagina + "/Get_Resumen";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                if (objResponse.fl_seguir == "1") {
                    this.oCita.nid_cita = objResponse.oDatosCita.nid_cita;
                    this.oCita.nu_estado = objResponse.oDatosCita.nu_estado;

                    $("#lblCodCita").html(objResponse.oDatosCita.co_reserva);
                    $("#lblTallerCita").html(objResponse.oDatosCita.no_taller);
                    $("#lblAsesorCita").html(objResponse.oDatosCita.no_asesor);
                    $("#lblFechaCita").html(objResponse.oDatosCita.fe_programada);
                    $("#lblHoraCita").html(objResponse.oDatosCita.ho_programada);
                    $("#lblTelfTaller").html(objResponse.oDatosCita.nu_telf_taller);
                    $("#lblTelfAsesor").html(objResponse.oDatosCita.nu_cel_asesor);
                    $("#lblTelCallCenter").html(objResponse.oDatosCita.nu_telf_callcenter);
                    $("#btnImprimir").attr("onclick", "javascript:fn_PopupDetalleCita('" + objResponse.oDatosCita.template_impresion + "');")


                    //$("#btnConfirmar").css("display", (objResponse.oDatosCita.fl_confirmar == true ? "block" : "none"));
                    //$("#divbtnConfirmar").css("display", (objResponse.oDatosCita.fl_confirmar == true ? "block" : "none"));
                }
                if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
            });
        }
        function fn_Confirmar() {
            var qs_marca = "";
            if (this.MP_co_marca_permitida > 0) { qs_marca = "?co_marca=" + this.MP_co_marca_permitida; }
            var UrlConfirmar = "SRC_ConfirmarCita.aspx" + qs_marca;
            var form = $('<form action="' + UrlConfirmar + '" method="post" target="_self">' +
                        '<input type="hidden" name="nid_cita" value="' + this.oCita.nid_cita + '" />' +
                        '<input type="hidden" name="nu_estado" value="' + this.oCita.nu_estado + '" />' +
                        '</form>');
            $("body").append(form);
            form.submit();
        }
        function fn_AnularCita() {
            var qs_marca = "";
            if (this.MP_co_marca_permitida > 0) { qs_marca = "?co_marca=" + this.MP_co_marca_permitida; }
            var UrlAnular = "SRC_AnularCita.aspx" + qs_marca;
            var form = $('<form action="' + UrlAnular + '" method="post" target="_self">' +
                        '<input type="hidden" name="nid_cita" value="' + this.oCita.nid_cita + '" />' +
                        '<input type="hidden" name="nu_estado" value="' + this.oCita.nu_estado + '" />' +
                        '</form>');
            $("body").append(form);
            form.submit();
        }
        function fn_ReprogramarCita() {
            var qs_marca = "";
            if (this.MP_co_marca_permitida > 0) { qs_marca = "?co_marca=" + this.MP_co_marca_permitida; }
            var UrlReprogramar = "SRC_ReprogramarCita.aspx" + qs_marca;
            var form = $('<form action="' + UrlReprogramar + '" method="post" target="_self">' +
                        '<input type="hidden" name="nid_cita" value="' + this.oCita.nid_cita + '" />' +
                        '<input type="hidden" name="nu_estado" value="' + this.oCita.nu_estado + '" />' +
                        '</form>');
            $("body").append(form);
            form.submit();
        }
        function fn_PopupDetalleCita(strHTML) {
            var ventana = window.open('', 'ventana', 'toolbar=no,status=no,location=no,directories=0,menubar=no,scrollbars=no,resizable=no,width=620px,height=650px');
            ventana.document.write(strHTML);
            ventana.document.close();
        }
    </script>
</asp:Content>