<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SRC_ReprogramarCita.aspx.cs" Inherits="SRC_ReprogramarCita" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="js/footable/footable.core.css" rel="stylesheet" type="text/css" />
    <link href="js/footable/footable.standalone.css" rel="stylesheet" type="text/css" />
    <script src="js/footable/footable.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bg_blue">
        <div class="titulo">
            Reprogramar Cita</div>
        <div id="divPage_Consulta">
            <div id="DivDato1" class="row">
                <div class="col l3 s5 x12">
                    <label id="lblDato1" class="texto">
                    </label>
                </div>
                <div class="col l2 s7 x12">
                    <input id="txtDato1" type="text" style="width: 100px;" maxlength="9" onkeypress="javascript:return fc_SoloLetrasNumeros(event);" />
                </div>
                <div class="col l7 s12 x12">
                    <span class="ayuda">
                        <label id="lblTextoFormatoDoc1">
                        </label>
                        <%=Parametros.N_DatosObligatorio() %></span>
                </div>
            </div>
            <div id="DivDato2" class="row">
                <div class="col l3 s5 x12">
                    <label id="lblDato2" class="texto">
                    </label>
                </div>
                <div class="col l2 s7 x12">
                    <input id="txtDato2" type="text" style="width: 100px;" maxlength="9" onkeypress="javascript:return fc_SoloLetrasNumeros(event);" />
                </div>
                <div class="col l7 s12 x12">
                    <span class="ayuda">
                        <label id="lblTextoFormatoDoc2">
                        </label>
                    </span>
                </div>
            </div>
            <div id="DivDato3" class="row">
                <div class="col l3 s5 x12">
                    <label id="lblDato3" class="texto">
                    </label>
                </div>
                <div class="col l2 s7 x12">
                    <input id="txtDato3" type="text" style="width: 100px;" maxlength="6" onkeypress="javascript:return fc_SoloLetrasNumeros(event);" />
                </div>
                <div class="col l7 s12 x12">
                    <span class="ayuda">
                        <label id="lblTextoFormatoDoc3">
                        </label>
                    </span>
                </div>
            </div>
            <div class="row">
                <div class="col l12 x12">
                    <button type="button" onclick="fn_Consultar();">Consultar Cita</button>
                </div>
            </div>
            <div class="row">
                <div class="col l12">
                    <label id="lblTextoSeleccioneCita" class="titulo_section">
                    </label>
                    <table id="grvBandeja">
                    </table>
                    <div id="grvBandeja_Pie">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col l12 PieTextoConsulta">
                    <span>
                        <%=Parametros.N_TextoPieConsulta() %></span>
                </div>
            </div>
        </div>
        <div id="divPage_DatosRegistro" style="display: none;">
            <div id="divReprogramadoOK" style="display: none;">
                <div class="row">
                    <div class="col l12">
                        <label id="lblCabEstado1" class="titulo">
                            La Cita fue Reprogramada</label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l12">
                        <label id="lblCabEstado2">
                            Sus nuevos datos son:</label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col l6 s12">
                    <span class="titulo_section">Cliente</span>
                    <div style="display: flex;">
                        <input type="text" id="txtCliNombre" class="cajatexto" readonly="readonly" style="display: none;" />
                        <input type="text" id="txtCliEditNom" class="cajatexto" onkeypress="javascript:return SoloLetrasEspacio(event)"
                            style="display: none; max-width: 140px;" />
                        <input type="text" id="txtCliEditApeP" class="cajatexto" onkeypress="javascript:return SoloLetrasEspacio(event)"
                            style="display: none; max-width: 110px;" />
                        <input type="text" id="txtCliEditApeM" class="cajatexto" onkeypress="javascript:return SoloLetrasEspacio(event)"
                            style="display: none; max-width: 110px;" />
                        <label id="lblCliNombre">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="LblDoc">DNI:</label>
                        <input type="text" id="txtCliDoc" maxlength="20" class="cajatexto" readonly="readonly"
                            style="display: none;" />
                        <label id="lblCliDoc">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="LblTelFij">
                            Teléfono Fijo:
                        </label>
                        <input type="text" id="txtCliCodTelFijo" maxlength="4" class="cajatexto" onkeypress="javascript:return fc_SoloNumeros(event)"
                            style="display: none; max-width: 35px;" />
                        <input type="text" id="txtCliTelFijo" maxlength="46" class="cajatexto" onkeypress="javascript:return fc_SoloNumeros(event)"
                            style="display: none;" />
                        <label id="lblCliTelFijo">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="LblTelMov">
                            Teléfono Móvil:
                        </label>
                        <input type="text" id="txtCliCodTelCel" maxlength="2" class="cajatexto" onkeypress="javascript:return fc_SoloNumeros(event)"
                            style="display: none;" />
                        <input type="text" id="txtCliTelCel" maxlength="15" class="cajatexto" onkeypress="javascript:return fc_SoloNumeros(event)"
                            style="display: none;" />
                        <label id="lblCliTelCel">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="lblTextoEmail1">
                            E-mail Personal:
                        </label>
                        <input type="text" id="txtCliEmail" maxlength="255" class="cajatexto" style="display: none;" />
                        <label id="lblCliEmail">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="lblTextoEmail2" style="display: none">
                            E-mail Trabajo:
                        </label>
                        <input type="text" id="txtCliEmailTrab" maxlength="255" class="cajatexto" style="display: none;" />
                        <label id="lblCliEmailTrab" style="display: none">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="lblTextoEmail3" style="display: none">
                            E-mail Alternativo:
                        </label>
                        <input type="text" id="txtCliEmailAlter" maxlength="255" class="cajatexto" style="display: none;" />
                        <label id="lblCliEmailAlter" style="display: none">
                        </label>
                    </div>
                    <div>
                        <input id="btnGrabarCliente" type="button" onclick="fn_GrabarCliente()" value="Grabar datos"
                            class="botonBlanco" />
                    </div>
                    <div>
                        &nbsp;</div>
                    <div>
                        &nbsp;</div>
                    <span class="titulo_section">Vehículo</span>
                    <div>
                        <label id="lblTextoRPlaca">
                            Placa:
                        </label>
                        <label id="lblPlaca">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoMarca">
                            Marca:
                        </label>
                        <label id="lblMarca">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoModelo">
                            Modelo:
                        </label>
                        <label id="lblModelo">
                        </label>
                    </div>
                    <div>
                        &nbsp;</div>
                    <div>
                        &nbsp;</div>
                    <div style="display: flex;">
                        <input type="button" id="btnActCliente" value="Actualizar datos" onclick="fn_actualizarcliente()"
                            class="botonBlanco" />
                        <input type="button" id="btnCancActualiza" value="Cancelar actualización" onclick="fn_cancelaract()"
                            class="botonBlanco" />
                    </div>
                </div>
                <div class="col l6 s12">
                    <span class="titulo_section">Cita</span>
                    <div>
                        <label id="lblFechaCita">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoRAsesor">
                        </label>
                        <label id="lblAsesor">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoLocalC">
                        </label>
                        <label id="lblLocalC">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoDireccion">
                            Dirección:
                        </label>
                        <label id="lblDireccion">
                        </label>
                    </div>
                    <div>
                        <label id="lblTextoTelefonoT">
                            Teléfono:
                        </label>
                        <label id="lblTelfTaller">
                        </label>
                    </div>
                    <div>
                        <input type="button" id="btnVerMapa" value="Ver mapa" class="botonBlanco" />
                    </div>
                    <div>
                        &nbsp;</div>
                    <div>
                        &nbsp;</div>
                    <span class="titulo_section">Recordatorio</span>
                    <div>
                        <label>
                            Las notificaciones se enviarán:
                        </label>
                        &nbsp;&nbsp;
                        <input type="checkbox" id="chkEmailRes" checked="checked" disabled="disabled" /><label>
                            Por E-mail</label>
                    </div>
                    <div id="DatosRecordR" style="display: none;">
                        <div>
                            <label id="Label43">
                                Horario para contacto con Call Center.</label>
                        </div>
                        <div>
                            <label id="Label24">
                                Dia
                            </label>
                            <select id="ddlCliDia" style="max-width: 90px; max-height: 20px;">
                            </select>,
                            <select id="ddlHorarioIniR" style="max-width: 90px; max-height: 20px;">
                            </select>hasta
                            <select id="ddlHorarioFinR" style="max-width: 90px; max-height: 20px;">
                            </select>
                        </div>
                    </div>
                    <div>
                        <label id="lblTextoObserv">
                            Observaciones:
                        </label>
                        <input type="text" id="txtObservacion" style="display: none;" />
                        <label id="lblTextoObservFijo">
                        </label>
                    </div>
                </div>
            </div>
           <div class="row">
                <div class="col l12 x12">
                    <button id="BtnReprogramar" type="button" onclick="fn_ConfirmarReprogramacion();">
                        Confirmar Reprogramación
                    </button>
                </div>
            </div>
        </div>
        <div id="divPage_NuevosDatos" style="display: none;">
            <div class="titulo_section">
                Horario Actual: <label id="lblHorarioActual"></label>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Departamento %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboDepartamento" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Provincia %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboProvincia" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Distrito %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboDistrito" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Local %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboUbicacion" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                    <button type="button" id="btnMapaTallerPR">
                        Ver Mapa de ubicación</button>
                </div>
            </div>
            <div id="divTallerMapa" class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Taller %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboTaller" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <%--<hr />--%>
            <div id="divselhora" class="divselhora">
            </div>
            <div class="row">
                <div class="col l2 m3 s5 x12">
                    <span class="texto">Fecha de inicio:</span>
                </div>
                <div class="col l2 m9 s7 x12">
                    <input id="txtFecInicio" type="text" style="width: 80px;" disabled="disabled" onchange="fn_ChangedFecha();" />
                </div>
                <div class="col l2 m3 s5 x12">
                    <span class="texto">Hora inicio reserva:</span>
                </div>
                <div class="col l2 m3 s7 x12">
                    <select id="cboHoraInicioReserva" style="width: 70px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
                <div class="col l2 m3 s5 x12">
                    <span class="texto">Hora término reserva:</span>
                </div>
                <div class="col l2 m3 s7 x12">
                    <select id="cboHoraFinalReserva" style="width: 70px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <%--<hr />--%>
            <div class="row">
                <div class="col l12">
                    <div id="divGrvUbicacion" style="width: 100%;">
                    </div>
                    <div style="width: 100%;">
                        <table id="grvReserva">
                        </table>
                        <div id="grvReserva_Pie">
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col l5 s12" style="font-size: 10px; color: #069;">
                    <img src="img/disponible.png" alt="" style="position:relative; top:6px;" />
                    Horario disponible para reserva de cita.
                </div>
                <div class="col l7 s12" style="font-size: 10px; color: #069;">
                    <img src="img/ocupado.png" alt="" style="position:relative; top:6px;" />
                    Horario reservado.
                </div>
            </div>
            <div class="row">
                <div class="col l12 x12">
                    <button type="button" onclick="fn_Reprogramar();">Reprogramar Cita</button>
                </div>
            </div>
        </div>
        <div id="divPage_Confirmacion" style="display: none;">
            <div class="row">
                <div class="col l12">
                    <label class="titulo_section">
                        ¿ Está usted seguro de Reprogramar la Cita ?
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col l3 m4 s6 x12">
                    <button type="button" onclick="fn_SiEstoySeguro();">
                        Si, estoy seguro.</button>
                </div>
                <div class="col l9 m8 s6 x12">
                    <button type="button" onclick="fn_NoEstoySeguro();">
                        No estoy seguro.</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "SRC_ReprogramarCita.aspx";
        var TEXTO_SELECCIONE = "<%=Parametros.OBJECTO_SELECCIONE %>";
        var TEXTO_TODOS = "<%=Parametros.OBJECTO_TODOS %>";
        var oCita = { nid_cita: 0, co_reserva: "", nu_estado: "", nid_vehiculo: 0, nu_placa: "", nu_vin: "", nid_marca: 0, no_marca: "", nid_modelo: 0, nu_anio: 0, co_tipo_veh: "", co_modeloservicio_ax: "", fl_campania_veh: "0"
		    , nid_servicio: 0, tx_observacion: "", nid_taller: 0, nid_asesor: 0, fe_programada: "", ho_inicio: "", qt_intervalo_atenc: ""
		    , nid_cliente: 0, co_tipo_documento: "", nu_documento: "", no_cliente: "", ape_paterno: "", ape_materno: "", no_correo_personal: ""
		    , no_correo_trabajo: "", no_correo_alternativo: "", nu_telefono_cod: "", nu_telefono: "", nu_celular_cod: "", nu_celular: ""
            , qt_intervalo_taller: 0
        };
        var imgURL_Hora_Separada = "<%=imgURL_HORA_SEPARADA %>";
        var imgURL_Hora_Libre = "<%=imgURL_HORA_LIBRE %>";
        var PARM_13 = "<%=Parametros.GetValor(Parametros.PARM._13)%>";
        var PARM_14 = "<%=Parametros.GetValor(Parametros.PARM._14) %>";
        var oComboProvincia = [];
        var oComboDistrito = [];
        var oComboTaller = [];
        var fl_ubigeo_all = "1";
        var PRM_12 = "<%=Parametros.GetValor(Parametros.PARM._12) %>";
        var PRM_15 = "<%=Parametros.GetValor(Parametros.PARM._15) %>";
        var oCitaDetalle;
        var strDivSinHorario = "<div id='divSinHorario' style='background-color: #FFF; font-weight: bold; padding-top: 25px; padding-bottom:25px; text-align: center; font-size: 18px;'></div>";

        /*#region - Variables Grilla Bandeja*/
        var idGrilla_Bandeja = "#grvBandeja";
        var idPieGrilla_Bandeja = "#grvBandeja_Pie";
        var strCabecera_Bandeja = ['Seleccionar', 'Taller', 'Fecha - Hora', 'Servicio', 'Asesor de Servicio', 'Estado'];
        var ModelCol_Bandeja = [
                            { name: 'seleccionar', index: 'seleccionar', align: "center", width: 70 },
                            { name: 'no_taller', index: 'no_taller', align: "left", width: 150, sortable: true },
                            { name: 'fe_inicio', index: 'fe_inicio', align: "center", width: 100, sortable: true },
                            { name: 'nu_servicio', index: 'nu_servicio', align: "left", width: 200, sortable: true },
                            { name: 'no_asesor', index: 'no_asesor', align: "left", width: 200, sortable: true },
                            { name: 'co_estado', index: 'co_estado', align: "center", width: 90, sortable: true }
                            ];
        /*#endregion - Variables Grilla Bandeja*/

        var oHorario_Cabecera, oHorario_ModelCol, oHorarioDisponible;
        /*#region - Variables Grilla Reserva*/
        var idGrilla_Reserva = "#grvReserva";
        var idPieGrilla_Reserva = "#grvReserva_Pie";
        var strCabecera_Reserva = ['Punto Red', 'Servicio Técnico', 'Calidad Servicio', 'Dirección'];
        var ModelCol_Reserva = [
                            { name: 'no_ubica', index: 'no_ubica', width: 130, sortable: false },
                            { name: 'no_taller', index: 'no_taller', width: 130, sortable: false },
                            { name: 'calidad_servicio', index: 'calidad_servicio', width: 100, sortable: false, align: 'center' },
                            { name: 'di_ubica', index: 'di_ubica', width: 170, sortable: false }
                            ];
        /*#endregion - Variables Grilla Reserva*/
        fn_CargaInicial();
        function fn_CargaInicial() {
            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);

                $("#txtDato3").prop("maxlength", 7);
                $("#txtDato1").prop("maxlength", 9);
            

            var no_Home = "<%=Parametros.N_EtiquetaHome %>";
            $("#hlHome").html(no_Home);

            var URL_Home = "javascript:window.location.href='SRC_Home.aspx'";
            $("#hlHome").attr("onclick", URL_Home);	

                $("#DivDato3").hide();
                $("#lblDato1").html("<%=Parametros.N_DatoConsulta2 %>" + ":");
                $("#lblDato2").html("<%=Parametros.N_DatoConsulta3 %>" + ":");

                $("#txtDato1").addClass(ESTILO_TXT_2).attr("MaxLength", 20);
                $("#txtDato2").addClass(ESTILO_TXT_2).attr("MaxLength", 7);

                $("#txtDato1").attr("onkeypress", "return fc_SoloLetrasNumeros(event)");
                $("#txtDato2").attr("onkeypress", "return fc_SoloLetrasNumeros(event)").attr("onpaste", "return false");

                $("#lblTextoFormatoDoc1").text("<%=Parametros.N_FormatoDoc %>");
                $("#lblTextoDatoObligatorio").text("<%=Parametros.N_DatosObligatorio() %>");

                $("#divTallerMapa").show();
            
        }
        function fn_ValidarConsulta() {
            var CodRes = "";
            var NroDoc = "";
            var NroPla = "";
            NroDoc = $("#txtDato1").val();
            NroPla = $("#txtDato2").val();

            if (NroDoc.length == 0 && NroPla.length == 0) {
                fc_Alert("Debes ingresar el " + ReadConfigSettings("nDatoConsulta2_1") + " y el " + ReadConfigSettings("nDatoConsulta3_1") + ".");
                return false;
            }
            if (NroDoc.length == 0) {
                fc_Alert("Debes ingresar el " + ReadConfigSettings("nDatoConsulta2_1")); $("#txtDato1").focus(); return false;
            }
            if (NroPla.length < 6) {
                fc_Alert("Debes ingresar el " + ReadConfigSettings("nDatoConsulta3_1")); $("#txtDato2").focus(); return false;
            }
            return true;

        }
        function fn_Consultar() {
            if (fn_ValidarConsulta() == true) {
                var CodRes;
                var NroDoc;
                var NroPla;

                    NroDoc = fc_Trim($("#txtDato1").val());
                    NroPla = fc_Trim($("#txtDato2").val());
                
                var parametros = new Array();
                parametros[0] = CodRes;
                parametros[1] = NroDoc;
                parametros[2] = NroPla;
                var strUrlServicio = no_pagina + "/Get_Bandeja";
                var strFiltros = "{'strFiltros':" + JSON.stringify(parametros) + "}";
                var JQGrid_Opciones_Bandeja = JQGrid_Opciones_Default;
                JQGrid_Opciones_Bandeja.pageSize = 10;
                JQGrid_Opciones_Bandeja.fl_paginar = true;
                JQGrid_Opciones_Bandeja.fl_multiselect = false;
                JQGrid_Opciones_Bandeja.height = 230;
                this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                    JQGrid_Util.GetTabla_Local(idGrilla_Bandeja, idPieGrilla_Bandeja, strCabecera_Bandeja, ModelCol_Bandeja
                    , JQGrid_Opciones_Bandeja, objResponse, function () { }, function () { }, function () {
                        var GrillaCount = JQGrid_Util.getCountRegistros(idGrilla_Bandeja);
                        if (GrillaCount == "" || GrillaCount == null || GrillaCount == 0) {
                            Mensaje("msgNoCita_1");
                            $("#lblTextoSeleccioneCita").text("");
                        }
                        else {
                            $("#lblTextoSeleccioneCita").text("<%=Parametros.N_SeleccionarCita %>");
                            if (GrillaCount == 1) {
                                $("#ImgSeleccionar").trigger("click");
                            }
                        }
                    });
                });
            }
        }
        function fn_SeleccionaCita(obj_nid_cita, obj_nu_estado, fl_confirm) {
            if (parseInt(obj_nu_estado) == 6) {
                Mensaje("msgYaAtendCita_1");
                $("#BtnReprogramar").focus();
                return false;
            }
            else if (parseInt(obj_nu_estado) == 8) {
                Mensaje("msgYaVencCita_1");
                $("#BtnReprogramar").focus();
                return false;
            }
            else if (parseInt(obj_nu_estado) == 3) {
                Mensaje("msgYaAnulCita_1");
                $("#BtnReprogramar").focus();
                return false;
            }
            else { }

            fn_edicionDatosCliente(false);
            
            var parametros = new Array();
            parametros[0] = obj_nid_cita;
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_DetalleCita";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                $("#divPage_Consulta").hide();
                $("#divPage_DatosRegistro").fadeIn();

                this.oCitaDetalle = objResponse;
                this.oCita.nid_modelo = this.oCitaDetalle.nid_modelo;
                this.oCita.nid_servicio = this.oCitaDetalle.nid_servicio;

                if (fl_confirm == true) {
                    this.fn_ConfirmarReprogramacion();
                }

                //#region - "Datos del Cliente"
                $("#lblCliEmailAlter").html("<a href='mailto:" + objResponse.no_correo_alter + "'>" + objResponse.no_correo_alter + "</a>");
                $("#lblCliEmailTrab").html("<a href='mailto:" + objResponse.no_correo_trabajo + "'>" + objResponse.no_correo_trabajo + "</a>");
                $("#lblCliEmail").html("<a href='mailto:" + objResponse.no_correo + "'>" + objResponse.no_correo + "</a>");
                $("#txtCliEmailAlter").val(objResponse.no_correo_alter);
                $("#txtCliEmailTrab").val(objResponse.no_correo_trabajo);
                $("#txtCliEmail").val(objResponse.no_correo);

                if (objResponse.nu_celular_c != "" || objResponse.nu_celular_c != null) {
                    if (objResponse.nu_celular_c.indexOf("-") >= 0) {
                        strMovilCod = objResponse.nu_celular_c.split('-')[0];
                        strMovilNum = objResponse.nu_celular_c.split('-')[1];
                    }
                    else
                        strMovilNum = objResponse.nu_celular_c;
                }

                if (objResponse.nu_telefono_c != "" || objResponse.nu_telefono_c != null) {
                    if (objResponse.nu_telefono_c.indexOf("-") >= 0) {
                        strTelfCod = objResponse.nu_telefono_c.split('-')[0];
                        strTelfNum = objResponse.nu_telefono_c.split('-')[1];
                    }
                    else
                        strTelfNum = objResponse.nu_telefono_c;
                }

                $("#txtCliCodTelFijo").val(strTelfCod);
                $("#txtCliCodTelFijo").css("display", "none");
                $("#txtCliTelFijo").val(strTelfNum);
                $("#lblCliTelFijo").text(strTelfCod == "" ? strTelfNum : (strTelfCod + "-" + strTelfNum));

                $("#txtCliCodTelCel").val(strMovilCod);
                $("#txtCliCodTelCel").css("display", "none");
                $("#txtCliTelCel").val(strMovilNum);
                $("#lblCliTelCel").text(strMovilCod == "" ? strMovilNum : (strMovilCod + "-" + strMovilNum));

                $("#txtCliDoc").val(objResponse.nu_documento);
                $("#lblCliDoc").text(objResponse.nu_documento);

                if (objResponse.co_tipo_cliente == "0002") {
                    $("#txtCliNombre").val(objResponse.no_razon_social);
                    $("#lblCliNombre").text(objResponse.no_razon_social);
                }
                else {
                    $("#txtCliNombre").val(objResponse.no_cliente + " " + objResponse.no_ape_paterno + " " + objResponse.no_ape_materno);
                    $("#lblCliNombre").text(objResponse.no_cliente + " " + objResponse.no_ape_paterno + " " + objResponse.no_ape_materno);
                }

                $("#txtCliEditNom").val(objResponse.no_cliente);
                $("#txtCliEditApeP").val(objResponse.no_ape_paterno);
                $("#txtCliEditApeM").val(objResponse.no_ape_materno);

                var strCodDoc = objResponse.co_tipo_documento;
                $("#txtCliDoc").prop("MaxLength", strCodDoc == "01" ? 8 : (strCodDoc == "03" ? 9 : 20));
                //#endregion - "Datos del Cliente"
                //#region - "Datos del Vehiculo"
                $("#lblTextoRPlaca").text("<%=Parametros.N_Placa %>");
                var nu_placa = objResponse.nu_placa;
                if (objResponse.nu_placa != "") {
                    nu_placa = nu_placa.substr(0, 2) + " " + nu_placa.substr(2, 2) + " " + nu_placa.substr(4, 2);
                }
                $("#lblPlaca").text(nu_placa);
                $("#lblModelo").text(objResponse.no_modelo);
                $("#lblMarca").text(objResponse.no_marca);
                //#endregion - "Datos del Vehiculo"                
                //#region - "Datos de Cita"
                $("#lblFechaCita").text(objResponse.fecha_prog_format);
                $("#lblTextoRAsesor").text("<%=Parametros.N_Asesor %>" + ": ");
                $("#lblAsesor").text(objResponse.no_asesor);
                $("#lblTextoLocalC").text("<%=Parametros.N_Local %>" + ": ");
                $("#lblLocalC").text(objResponse.no_ubica);
                $("#lblUbicacion").text(objResponse.no_taller);
                $("#lblDireccion").text(objResponse.no_direccion_t + " - " + objResponse.no_distrito);
                $("#lblTelfTaller").text(objResponse.nu_telefono_t);
                var strMapaTaller = objResponse.tx_mapa_taller;
                if (strMapaTaller != "") {
                    var strRutaMapa = '<%=ConfigurationManager.AppSettings["RutaMapasBO"].ToString()  %>' + strMapaTaller;
                    $("#btnVerMapa").attr("onclick", "javascript:foto('" + strRutaMapa + "','" + objResponse.no_taller + "');");
                    $("#btnMapaTallerPR").attr("onclick", "javascript:foto('" + strRutaMapa + "','" + objResponse.no_taller + "');");
                }
                else {
                    $("#btnVerMapa").attr("onclick", "javascript:fc_Alert('<%=Parametros.msgNoMapa %>');");
                    $("#btnMapaTallerPR").attr("onclick", "javascript:fc_Alert('<%=Parametros.msgNoMapa %>');");
                }
                //#endregion - "Datos de Hora de Cita"

                $("#txtObservacion").val(objResponse.tx_observacion);
                $("#lblTextoObservFijo").text(objResponse.tx_observacion);

                if (objResponse.flg_estado_botones == 0) {
                    $("#btnActCliente,#btnVerMapa,#btnActRecordatorio").attr("disabled", true);
                }
                else {
                    $("#btnActCliente,#btnVerMapa,#btnActRecordatorio").removeAttr("disabled");
                }
                //#endregion - "Datos de Recordatorio"
                //#region - "Habilita botones según estado"
                var nu_estado = objResponse.nu_estado;
                if (parseInt(nu_estado) == 1) {
                    if (PRM_12 == "0") {
                        $("#div_btnConfirmarCita").show()
                    }
                    $("#div_btnReprogramarCita,#div_btnAnularCita").css("display", "");
                }
                else if (parseInt(nu_estado) == 4) {
                    $("#div_btnConfirmarCita").hide();
                    $("#div_btnReprogramarCita,#div_btnAnularCita").show()
                }
                else if (parseInt(nu_estado) == 3) {
                    $("#div_btnConfirmarCita,#div_btnReprogramarCita,#div_btnAnularCita").hide();
                }
                else if (parseInt(nu_estado) == 8) {
                    $("#div_btnConfirmarCita,#div_btnReprogramarCita,#div_btnAnularCita").hide();
                }
                else if (parseInt(nu_estado) == 6) {
                    $("#div_btnConfirmarCita,#div_btnReprogramarCita,#div_btnAnularCita").hide();
                }
                else if (parseInt(nu_estado) == 2) {
                    if (PRM_12 == "0") {
                        $("#div_btnConfirmarCita").show();
                    }
                    $("#div_btnReprogramarCita,#div_btnAnularCita").show();
                }
                //#endregion - "Habilita botones segúne estado"
            });
        }
        //#region - "Funcion para ver foto del mapa del taller"
        var ventana;
        var cont = 0;
        var titulopordefecto = "Defecto";
        function foto(mapa, titulo) {
            if (cont == 1) { ventana.close(); ventana = null }
            if (titulo == null) titulo = titulopordefecto;
            ventana = window.open('', 'ventana', 'toolbar=no,status=no,location=no,directories=0,menubar=no,scrollbars=no,resizable=0,width=50%,height=50%');
            ventana.document.write('<html><head><title>' + titulo + '</title></head><body style="overflow:hidden" marginwidth="0" marginheight="0" topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0" scroll="no" onUnload="opener.cont=0"><img src="' + mapa + '" onLoad="opener.redimensionar(this.width, this.height)">');
            ventana.document.close();
            cont++;
        }
        function redimensionar(ancho, alto) {
            ventana.resizeTo(ancho + 12, alto + 28);
            ventana.moveTo((screen.width - ancho) / 2, (screen.height - alto) / 2);
        }
        //#endregion - "Funcion para ver foto del mapa del taller"
        /*#region VARIABLES GENERALES*/       
        var strTelfCod = "";
        var strMovilCod = "";
        var strMovilNum = "";
        var strTelfNum = "";
        var ESTILO_TXT_2 = "cajaRut";
        var ESTILO_TXT_3 = "cajaCodigo";

        /*Variables utilizadas en REPROGRAMARCITA*/
        var Obj_Seleccione = "<%=Parametros.OBJECTO_SELECCIONE %>";
        var ListaCodDpto = "";
        var ListaNomDpto = "";
        var ListaCodProv = "";
        var ListaNomProv = "";
        var ListaCodDist = "";
        var ListaNomDist = "";
        var ListaNidUbic = "";
        var ListaNomUbic = "";
        var len, opt = '<option></option>';
        var v_Fecha_Reserva = "";
        /*Variables grilla dinamica*/
        var imgURL_Hora_Separada = "<%=imgURL_HORA_SEPARADA %>";
        var imgURL_Hora_Libre = "<%=imgURL_HORA_LIBRE %>";
        /****************************/
        /*****************************************/
        /*#endregion VARIABLES GENERALES*/

        function fn_edicionDatosCliente(blnEditar) {
            
                if (blnEditar == false) {
                    $("#txtCliEditNom,#txtCliEditApeP,#txtCliEditApeM,#txtCliCodTelFijo").css("display", "none");
                    $("#lblCliNombre").css("display", "");
                    $("#txtCliNombre").css("display", "none");
                    $("#txtCliDoc").removeAttr("readonly");

                    $("#txtCliDoc,#txtCliNombre,#txtCliTelFijo,#txtCliTelCel,#txtCliEmailTrab,#txtCliEmailAlter").css("display", "none");
                    $("#lblCliDoc,#lblCliNombre,#lblCliTelFijo,#lblCliTelCel,#lblTextoEmail2,#lblTextoEmail3").css("display", "");

                    $("#btnGrabarCliente,#btnCancActualiza,#txtCliEmail,#txtCliEmailAlter,#txtCliEmailTrab").css("display", "none");
                    $("#lblCliEmail,#lblCliEmailAlter,#lblCliEmailTrab,#btnActCliente").css("display", "");
                }
                else {
                    $("#txtCliEditNom,#txtCliEditApeP,#txtCliEditApeM,#txtCliCodTelFijo").css("display", "");
                    $("#lblCliNombre").css("display", "none");
                    $("#txtCliNombre").css("display", "none");

                    $("#txtCliDoc,#txtCliTelFijo,#txtCliTelCel").css("display", "");
                    $("#lblCliDoc,#lblCliNombre,#lblCliTelFijo,#lblCliTelCel").css("display", "none");

                    $("#btnGrabarCliente,#btnCancActualiza,#txtCliEmail,#txtCliEmailTrab,#txtCliEmailAlter").css("display", "");
                    $("#lblCliEmail,#lblCliEmailAlter,#lblCliEmailTrab,#btnActCliente").css("display", "none");
                }
            
        }
        function fn_actualizarcliente() {
            fn_edicionDatosCliente(true);
        }
        function fn_cancelaract() {
            $("#txtCliEditNom").val(this.oCitaDetalle.no_cliente);
            $("#txtCliEditApeP").val(this.oCitaDetalle.no_ape_paterno);
            $("#txtCliEditApeM").val(this.oCitaDetalle.no_ape_materno);
            $("#txtCliDoc").val($("#lblCliDoc").text());
            $("#txtCliCodTelFijo").val(strTelfCod);
            $("#txtCliTelCel").val(strMovilNum);
            $("#txtCliTelFijo").val(strTelfNum);
            $("#txtCliEmail").val($("#lblCliEmail").text());
            $("#txtCliEmailAlter").val($("#lblCliEmailAlter").text());
            $("#txtCliEmailTrab").val($("#lblCliEmailTrab").text());
            fn_edicionDatosCliente(false);
        }
        function fn_GrabarCliente() {
            NomCom = $("#txtCliEditNom").val();
            ApePat = $("#txtCliEditApeP").val();
            ApeMat = $("#txtCliEditApeM").val();
            NumDoc = $("#txtCliDoc").val();
            CliFij = ($("#txtCliCodTelFijo").css('display') == "block" ? $("#txtCliCodTelFijo").val() + "-" : "") + $("#txtCliTelFijo").val();
            CliMov = ($("#txtCliCodTelCel").css('display') == "block" ? $("#txtCliCodTelCel").val() + "-" : "") + $("#txtCliTelCel").val();
            CliEma = $("#txtCliEmail").val();
            CliEtr = $("#txtCliEmailTrab").val();
            CliEal = $("#txtCliEmailAlter").val();

            if (CliEma != "") {
                if (!fc_ValidarEmail(CliEma)) {
                    fc_Alert("E-mail Personal incorrecto.");
                    return;
                }
            }
            if (CliEtr != "") {
                if (!fc_ValidarEmail(CliEtr)) {
                    fc_Alert("E-mail Trabajo incorrecto.");
                    return;
                }
            }
            if (CliEal != "") {
                if (!fc_ValidarEmail(CliEal)) {
                    fc_Alert("E-mail Alternativo incorrecto.");
                    return;
                }
            }

            var parametros = new Array();
            parametros[0] = this.oCitaDetalle.nid_cliente;
            parametros[1] = NomCom;
            parametros[2] = ApePat;
            parametros[3] = ApeMat;
            parametros[4] = NumDoc;
            parametros[5] = CliEma;
            parametros[6] = CliEtr;
            parametros[7] = CliEal;
            parametros[8] = CliFij;
            parametros[9] = CliMov;
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/ActualizarDatosCliente";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) { });

            $("#lblCliNombre").text(NomCom + " " + ApePat + " " + ApeMat);
            $("#lblCliDoc").text(NumDoc);
            $("#lblCliEmail").text(CliEma);
            $("#lblCliEmailTrab").text(CliEtr);
            $("#lblCliEmailAlter").text(CliEal);
            $("#lblCliTelFijo").text(CliFij);
            $("#lblCliTelCel").text(CliMov);

            strTelfNum = $("#txtCliTelFijo").val();
            strTelfCod = $("#txtCliCodTelFijo").val();
            strMovilNum = $("#txtCliTelCel").val();

            fn_edicionDatosCliente(false);
        }
        
        function Mensaje(msg) {
            fc_Alert(ReadConfigSettings(msg));
            return true;
        }
        function ReadConfigSettings(key) {
            var srtSMS = "";
            switch (key) {
                case "msgYaAtendCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaAtendCita_1"].ToString() %>'; break;
                case "msgYaAtendCita_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaAtendCita_2"].ToString() %>'; break;
                case "msgYaVencCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaVencCita_1"].ToString() %>'; break;
                case "msgYaVencCita_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaVencCita_2"].ToString() %>'; break;
                case "msgYaAnulCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaAnulCita_1"].ToString() %>'; break;
                case "msgYaAnulCita_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaAnulCita_2"].ToString() %>'; break;
                case "msgYaConfCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaConfCita_1"].ToString() %>'; break;
                case "msgYaConfCita_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaConfCita_2"].ToString() %>'; break;
                case "codPais": srtSMS = '<%=ConfigurationManager.AppSettings["CodPais"].ToString() %>'; break;
                case "nDatoConsulta1_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta1_1"].ToString() %>'; break;
                case "nDatoConsulta1_2": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta1_2"].ToString() %>'; break;
                case "nDatoConsulta2_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta2_1"].ToString() %>'; break;
                case "nDatoConsulta2_2": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta2_2"].ToString() %>'; break;
                case "nDatoConsulta3_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta3_1"].ToString() %>'; break;
                case "nDatoConsulta3_2": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta3_2"].ToString() %>'; break;
                case "msgPlaca_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgPlaca_1"].ToString() %>'; break;
                case "msgPlaca_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgPlaca_2"].ToString() %>'; break;
                case "msgDep_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgDep_1"].ToString() %>'; break;
                case "msgDep_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgDep_2"].ToString() %>'; break;
                case "msgProv_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgProv_1"].ToString() %>'; break;
                case "msgProv_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgProv_2"].ToString() %>'; break;
                case "msgDist_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgDist_1"].ToString() %>'; break;
                case "msgDist_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgDist_2"].ToString() %>'; break;
                case "msgNombres_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNombres_1"].ToString() %>'; break;
                case "msgNombres_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNombres_1"].ToString() %>'; break;
                case "msgNoApePat_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApePat_1"].ToString() %>'; break;
                case "msgNoApePat_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApePat_2"].ToString() %>'; break;
                case "msgNoApeMat_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApeMat_1"].ToString() %>'; break;
                case "msgNoApeMat_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApeMat_2"].ToString() %>'; break;
                case "msgNoNumTelfFijo_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfFijo_1"].ToString() %>'; break;
                case "msgNoNumTelfFijo_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfFijo_2"].ToString() %>'; break;
                case "msgNoCodTelfFijo_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfFijo_1"].ToString() %>'; break;
                case "msgNoCodTelfFijo_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfFijo_2"].ToString() %>'; break;
                case "msgNoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoMovil_1"].ToString() %>'; break;
                case "msgNoMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoMovil_2"].ToString() %>'; break;
                case "msgNoEmail_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoEmail_1"].ToString() %>'; break;
                case "msgNoEmail_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoEmail_2"].ToString() %>'; break;
                case "msgNoDia_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDia_1"].ToString() %>'; break;
                case "msgNoDia_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDia_2"].ToString() %>'; break;
                case "msgNoHora_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHora_1"].ToString() %>'; break;
                case "msgNoHora_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHora_2"].ToString() %>'; break;
                case "msgNoHoraIni_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraIni_1"].ToString() %>'; break;
                case "msgNoHoraIni_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraIni_2"].ToString() %>'; break;
                case "msgNoHoraFin_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraFin_1"].ToString() %>'; break;
                case "msgNoHoraFin_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraFin_2"].ToString() %>'; break;
                case "msgNoCodRes_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodRes_1"].ToString() %>'; break;
                case "msgNoCodRes_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodRes_2"].ToString() %>'; break;
                case "msgNoDoc_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDoc_1"].ToString() %>'; break;
                case "msgNoDoc_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDoc_2"].ToString() %>'; break;
                case "msgNoCodTelfMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfMovil_1"].ToString() %>'; break;
                case "msgNoCodTelfMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfMovil_2"].ToString() %>'; break;
                case "msgNoNumTelfMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfMovil_1"].ToString() %>'; break;
                case "msgNoNumTelfMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfMovil_2"].ToString() %>'; break;
                case "msgNoNumFijoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_1"].ToString() %>'; break;
                case "msgNoNumFijoMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_2"].ToString() %>'; break;
                case "msgNoCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCita_1"].ToString() %>'; break;
                case "msgNoCita_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCita_2"].ToString() %>'; break;
            }
            return srtSMS;
        }
                
        function fn_ConfirmarReprogramacion() {
            $("body").scrollTop(0);
            $("#divPage_DatosRegistro").hide();
            $("#divPage_NuevosDatos").fadeIn();

            $("#divselhora").empty();
            //-------------------
            $("#lblHorarioActual").text(oCitaDetalle.no_asesor + " - " + oCitaDetalle.fecha_prog_format);

            var parametros = new Array();
            parametros[0] = oCitaDetalle.nid_servicio;
            parametros[1] = oCitaDetalle.nid_modelo;
            parametros[2] = MP_co_marca_permitida;
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_UbigeoDisponible";
            fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
                var text_default = TEXTO_TODOS;
                if (PARM_13 == "1") TEXTO_SELECCIONE;
                this.fc_FillCombo("cboDepartamento", objResponse.oComboDepartamento, text_default);
                if (objResponse.oComboDepartamento.length == 1) {
                    $("#cboDepartamento").val(objResponse.oComboDepartamento[0].value);
                }
                oComboProvincia = objResponse.oComboProvincia;
                oComboDistrito = objResponse.oComboDistrito;
                //Setea ubigeo actual
                $("#cboDepartamento").val(oCitaDetalle.coddpto);
                $("#cboDepartamento").trigger("change", [oCitaDetalle.codprov_value, oCitaDetalle.coddist_value, oCitaDetalle.nid_ubica_value
                    , oCitaDetalle.nid_taller_value, undefined]);
            });
        }
        function fn_Reprogramar() {
            if ($("#divselhora").text() == "") {
                fc_Alert("<%=Parametros.msgSelFec %>");
            }
            else {
                $("body").scrollTop(0);
                $("#divPage_NuevosDatos").hide();
                $("#divPage_Confirmacion").fadeIn();
            }
        }
        function fn_SiEstoySeguro() {
            var parametros = new Array();
            parametros[0] = oCitaDetalle.nid_cita;
            parametros[1] = oCitaDetalle.nid_estado;
            parametros[2] = oCita.nid_taller;
            parametros[3] = oCita.fe_programada;
            parametros[4] = oCita.ho_inicio;
            parametros[5] = oCita.nid_asesor;
            parametros[6] = oCita.qt_intervalo_atenc;
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/SaveReprogramacion";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }

                if (objResponse.fl_seguir == "1") {
                    $("body").scrollTop(0);

                    $("#divPage_Confirmacion").hide();
                    $("#divPage_DatosRegistro").show();

                    fn_SeleccionaCita(oCitaDetalle.nid_cita, oCitaDetalle.nu_estado);
                    $("#BtnReprogramar").hide();
                    $("#btnActCliente").hide();
                    $("#divReprogramadoOK").show();
                }
                else if (objResponse.fl_ir_home == "1") {
                    window.location.href = "SRC_Home.aspx";
                }
            });
        }
        function fn_NoEstoySeguro() {
            $("body").scrollTop(0);
            $("#divPage_DatosRegistro").fadeIn();
            $("#divPage_Confirmacion").hide();
            fn_SeleccionaCita(oCitaDetalle.nid_cita, oCitaDetalle.nu_estado);
        }

        //-------------
        function fn_GetValue_Prov() {
            var codprov_value = $("#cboProvincia").val();
            var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;
            return codprov;
        }
        function fn_GetValue_Dist() {
            var coddist_value = $("#cboDistrito").val();
            var coddist = coddist_value.length > 2 ? coddist_value.substr(4, 2) : coddist_value;
            return coddist;
        }
        function fn_GetValue_Ubicacion() {
            var nid_ubica_value = $("#cboUbicacion").val();
            var nid_ubica = nid_ubica_value.length > 6 ? nid_ubica_value.substr(6) : nid_ubica_value;
            return nid_ubica;
        }
        function fn_GetValue_Taller() {
            var nid_taller_value = $("#cboTaller").val();
            var arr_ubi_taller_aux = nid_taller_value.split("$");
            var nid_taller;
            if (arr_ubi_taller_aux.length > 1) { nid_taller = arr_ubi_taller_aux[1]; }
            else { nid_taller = nid_taller_value; }
            return nid_taller;
        }
        var PRM_SELECTED;
        $("#cboDepartamento").change(function (event, co_prov_sel, co_dist_sel, nid_ubica_sel, nid_taller_sel, fl_ver_horario) {
            var coddpto = $(this).val();
            if (coddpto != "") {
                var objProvincias = $.grep(oComboProvincia, function (e) { return e.coddpto == coddpto; });
                var text_default = TEXTO_TODOS;
                if (PARM_13 == "2") text_default = TEXTO_SELECCIONE;
                fc_FillCombo("cboProvincia", objProvincias, text_default);
                if (co_prov_sel != undefined && co_prov_sel != "") { $("#cboProvincia").val(co_prov_sel); }
                if (objProvincias.length == 1) {
                    $("#cboProvincia").val(objProvincias[0].value);
                }
                $("#cboProvincia").trigger("change", [co_dist_sel, nid_ubica_sel, nid_taller_sel, fl_ver_horario]);
            }
            else if (fl_ubigeo_all == "1") {
                fc_FillCombo("cboProvincia", oComboProvincia, TEXTO_TODOS);
                if (co_prov_sel != undefined && co_prov_sel != "") { $("#cboProvincia").val(co_prov_sel); }
                $("#cboProvincia").trigger("change", [co_dist_sel, nid_ubica_sel, nid_taller_sel, fl_ver_horario]);
            }
            else {
                fc_FillCombo("cboProvincia", [], TEXTO_SELECCIONE);
                $("#cboProvincia").trigger("change");
            }
        });
        $("#cboProvincia").change(function (event, co_dist_sel, nid_ubica_sel, nid_taller_sel, fl_ver_horario) {
            var codprov_value = $(this).val();
            var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;
            var coddpto = $("#cboDepartamento").val();
            if (coddpto == "" && codprov_value.length > 2) {
                $("#cboDepartamento").val(codprov_value.substr(0, 2));
                $("#cboDepartamento").trigger("change", [codprov_value, undefined, undefined, undefined, undefined]);
                return;
            }
            else {
                if (coddpto != "") {
                    var objDistritos;
                    if (codprov != "") objDistritos = $.grep(oComboDistrito, function (e) { return (e.coddpto == coddpto && e.codprov == codprov); });
                    else objDistritos = $.grep(oComboDistrito, function (e) { return (e.coddpto == coddpto); });

                    var text_default = TEXTO_TODOS;
                    if (PARM_13 == "3") text_default = TEXTO_SELECCIONE;
                    fc_FillCombo("cboDistrito", objDistritos, text_default);
                    if (co_dist_sel != undefined && co_dist_sel != "") { $("#cboDistrito").val(co_dist_sel); }
                    if (objDistritos.length == 1) {
                        $("#cboDistrito").val(objDistritos[0].value);
                    }
                    $("#cboDistrito").trigger("change", [nid_ubica_sel, nid_taller_sel, fl_ver_horario]);
                }
                else if (fl_ubigeo_all == "1") {
                    fc_FillCombo("cboDistrito", oComboDistrito, TEXTO_TODOS);
                    if (co_dist_sel != undefined && co_dist_sel != "") { $("#cboDistrito").val(co_dist_sel); }
                    $("#cboDistrito").trigger("change", [nid_ubica_sel, nid_taller_sel, fl_ver_horario]);
                }
                else {
                    fc_FillCombo("cboDistrito", [], TEXTO_SELECCIONE);
                    $("#cboDistrito").trigger("change");
                }
            }
        });
        $("#cboDistrito").change(function (event, nid_ubica_sel, nid_taller_sel, fl_ver_horario) {
            var coddist_value = $(this).val();
            var coddist = coddist_value.length > 2 ? coddist_value.substr(4, 2) : coddist_value;

            var coddpto = $("#cboDepartamento").val();
            var codprov_value = $("#cboProvincia").val();
            var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;

            if ((coddpto == "" || codprov_value == "") && coddist_value.length > 2) {
                $("#cboDepartamento").val(coddist_value.substr(0, 2));
                if (codprov_value == "") { codprov_value = coddist_value.substr(0, 4); }
                $("#cboDepartamento").trigger("change", [codprov_value, coddist_value, undefined, undefined, undefined]);
                return;
            }
            else {
                var qt_dptos = $("#cboDepartamento option").length;
                var fl_exist_dpto = "1";
                if (qt_dptos == 1 && coddpto == "") fl_exist_dpto = "0";
                if (oCita.nid_servicio > 0 && fl_exist_dpto == "1" && (coddist != "" || fl_ubigeo_all == "1")) {
                    var parametros = new Array();
                    parametros[0] = oCita.nid_modelo;
                    parametros[1] = oCita.nid_servicio;
                    parametros[2] = coddpto;
                    parametros[3] = codprov;
                    parametros[4] = coddist;
                    var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                    var strUrlServicio = no_pagina + "/Get_UbicacionDisponible";
                    fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                        if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }

                        var text_default = TEXTO_TODOS;
                        if (PARM_13 == "4") text_default = TEXTO_SELECCIONE;
                        this.fc_FillCombo("cboUbicacion", objResponse.oComboUbicacion, text_default);
                        if (nid_ubica_sel != undefined && nid_ubica_sel != "") { $("#cboUbicacion").val(nid_ubica_sel); }
                        if (objResponse.oComboUbicacion.length == 1) {
                            $("#cboUbicacion").val(objResponse.oComboUbicacion[0].value);
                        }

                        this.oComboTaller = objResponse.oComboTaller;
                        this.fc_FillCombo("cboTaller", this.oComboTaller, text_default);

                        $("#cboUbicacion").trigger("change", [nid_taller_sel, fl_ver_horario]);
                    });
                }
                else {
                    fc_FillCombo("cboUbicacion", [], TEXTO_SELECCIONE);
                    oComboTaller = [];
                    $("#cboUbicacion").trigger("change");
                }
            }
        });
        var IntervaloT;
        $("#cboUbicacion").change(function (event, nid_taller_sel, fl_ver_horario) {
            var nid_ubica_value = $(this).val();
            var nid_ubica = nid_ubica_value.length > 6 ? nid_ubica_value.substr(6) : nid_ubica_value;

            var coddpto = $("#cboDepartamento").val();
            var codprov_value = $("#cboProvincia").val();
            var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;
            var coddist_value = $("#cboDistrito").val();
            var coddist = coddist_value.length > 2 ? coddist_value.substr(4, 2) : coddist_value;

            if ((coddpto == "" || codprov_value == "" || coddist_value == "") && nid_ubica_value.length > 6) {
                $("#cboDepartamento").val(nid_ubica_value.substr(0, 2));
                if (codprov_value == "") { codprov_value = nid_ubica_value.substr(0, 4); }
                if (coddist_value == "") { coddist_value = nid_ubica_value.substr(0, 6); }
                $("#cboDepartamento").trigger("change", [codprov_value, coddist_value, nid_ubica_value, undefined, undefined]);
                return;
            }
            else {
                $("#btnMapaTallerPR").hide();
                $("#divTallerMapa").show();
                if (coddpto != "") {
                    var objTalleres;
                    if (nid_ubica != "") objTalleres = $.grep(oComboTaller, function (e) { return (e.nid_ubica == nid_ubica); });
                    else if (coddist != "") objTalleres = $.grep(oComboTaller, function (e) { return (e.coddpto == coddpto && e.codprov == codprov && e.coddist == coddist); });
                    else if (codprov != "") objTalleres = $.grep(oComboTaller, function (e) { return (e.coddpto == coddpto && e.codprov == codprov); });
                    else objTalleres = $.grep(oComboTaller, function (e) { return (e.coddpto == coddpto); });

                    var text_default = TEXTO_TODOS;
                    if (PARM_13 == "5") text_default = TEXTO_SELECCIONE;
                    fc_FillCombo("cboTaller", objTalleres, text_default);
                    if (nid_taller_sel != undefined && nid_taller_sel != "") { $("#cboTaller").val(nid_taller_sel); }
                    if (objTalleres.length == 1) {
                        $("#cboTaller").val(objTalleres[0].value);

                        $("#btnMapaTallerPR").show();
                        $("#divTallerMapa").hide();

                        var strMapaTaller = objTalleres[0].tx_mapa_taller;
                        if (strMapaTaller != "") {
                            var strRutaMapa = '<%=ConfigurationManager.AppSettings["RutaMapasBO"].ToString()  %>' + strMapaTaller;
                            $("#btnMapaTallerPR").attr("onclick", "javascript:foto('" + strRutaMapa + "','" + objTalleres[0].nombre + "');");
                        }
                        else {
                            $("#btnMapaTallerPR").attr("onclick", "javascript:alert('<%=Parametros.msgNoMapa %>');");
                        }
                    }
                    $("#cboTaller").trigger("change", [fl_ver_horario]);
                }
                else if (fl_ubigeo_all == "1") {
                    fc_FillCombo("cboTaller", oComboTaller, TEXTO_TODOS);
                    if (nid_taller_sel != undefined && nid_taller_sel != "") { $("#cboTaller").val(nid_taller_sel); }
                    $("#cboTaller").trigger("change", [fl_ver_horario]);
                }
                else {
                    fc_FillCombo("cboTaller", [], TEXTO_SELECCIONE);
                    $("#cboTaller").trigger("change");
                }
            }
        });
        $("#cboTaller").change(function (event, fl_ver_horario) {
            if (fl_ver_horario != "0") {
                //Set datos de reserva - Taller
                oCita.nid_taller = 0;
                oCita.fe_programada = "";
                oCita.qt_intervalo_taller = 0;
                //Set datos de reserva - Asesor
                oCita.nid_asesor = 0;
                oCita.ho_inicio = "";
                oCita.qt_intervalo_atenc = 0;

                $("#txtFecInicio").val("");
                $("#txtFecInicio").datepicker("destroy");
            }

            var nid_taller_value = $(this).val();
            var arr_ubi_taller_aux = nid_taller_value.split("$");
            var nid_taller;
            if (arr_ubi_taller_aux.length > 1) { nid_taller = arr_ubi_taller_aux[1]; }
            else { nid_taller = nid_taller_value; }

            //Set datos de reserva
            oCita.nid_taller = nid_taller;

            var coddpto = $("#cboDepartamento").val();
            var codprov_value = $("#cboProvincia").val();
            var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;
            var coddist_value = $("#cboDistrito").val();
            var coddist = coddist_value.length > 2 ? coddist_value.substr(4, 2) : coddist_value;
            var nid_ubica_value = $("#cboUbicacion").val();
            var nid_ubica = nid_ubica_value.length > 6 ? nid_ubica_value.substr(6) : nid_ubica_value;

            if ((coddpto == "" || codprov_value == "" || coddist_value == "" || nid_ubica_value == "") && arr_ubi_taller_aux.length > 1) {
                $("#cboDepartamento").val(arr_ubi_taller_aux[0].substr(0, 2));
                if (codprov_value == "") { codprov_value = arr_ubi_taller_aux[0].substr(0, 4); }
                if (coddist_value == "") { coddist_value = arr_ubi_taller_aux[0].substr(0, 6); }
                if (nid_ubica_value == "") { nid_ubica_value = arr_ubi_taller_aux[0]; }

                $("#cboDepartamento").trigger("change", [codprov_value, coddist_value, nid_ubica_value, nid_taller_value, fl_ver_horario]);
                return;
            }
            else {
                fn_GetHorarioDisponibleTaller(fl_ver_horario);
            }
        });
        var id_img_select = "";
        function fn_SetHoraTaller(RowID, no_columna, id_img, keys) {
            if (id_img != id_img_select) {
                $("img[idfoo='" + id_img + "']").attr("src", imgURL_Hora_Separada);
                if (id_img_select != "") {
                    $("img[idfoo='" + id_img_select + "']").attr("src", imgURL_Hora_Libre);
                }
                id_img_select = id_img;

                var coddpto = keys.split("|")[0];
                var codprov_value = keys.split("|")[1];
                var coddist_value = keys.split("|")[2];
                var nid_ubica_value = keys.split("|")[3];
                var nid_taller_value = keys.split("|")[4];
                var qt_intervalo_taller = keys.split("|")[5];

                var hora_ini_preseleccion = no_columna.split("_")[1];

                var codprov = codprov_value.length > 2 ? codprov_value.substr(2, 2) : codprov_value;
                var coddist = coddist_value.length > 2 ? coddist_value.substr(4, 2) : coddist_value;
                var arr_ubi_taller_aux = nid_taller_value.split("$");
                var nid_ubica;
                var nid_taller;
                if (arr_ubi_taller_aux.length > 1) {
                    nid_ubica = arr_ubi_taller_aux[0].substr(6);
                    nid_taller = arr_ubi_taller_aux[1];
                }
                else {
                    nid_ubica = nid_ubica_value;
                    nid_taller = nid_taller_value;
                }

                //Set datos de reserva
                this.oCita.nid_taller = nid_taller;
                this.oCita.fe_programada = $("#txtFecInicio").val();
                this.oCita.qt_intervalo_taller = qt_intervalo_taller;

                $("#cboTaller").val(nid_taller_value);
                var fl_ver_horario = "0";
                $("#cboTaller").trigger("change", [fl_ver_horario]);

                fn_GetHorarioDisponibleAsesor(hora_ini_preseleccion);
            }
        }
        function fn_SetHoraAsesor(RowID, no_columna, id_img, keys) {
            if (id_img != id_img_select) {
                $("img[idfoo='" + id_img + "']").attr("src", imgURL_Hora_Separada);
                if (id_img_select != "") {
                    $("img[idfoo='" + id_img_select + "']").attr("src", imgURL_Hora_Libre);
                }
                id_img_select = id_img;

                var nid_asesor = keys.split("$")[0];
                var ho_inicio = keys.split("$")[1];
                var qt_intervalo_atenc = keys.split("$")[2];
                var strSeleccion = keys.split("$")[3];

                $("#divselhora").text(strSeleccion);
                //Set datos de reserva
                this.oCita.nid_asesor = nid_asesor;
                this.oCita.ho_inicio = no_columna;
                this.oCita.qt_intervalo_atenc = qt_intervalo_atenc;
            }
        }
        function fn_ChangedFecha() {
            this.oCita.fe_programada = $("#txtFecInicio").val();
            if (this.oCita.nid_taller > 0) fn_GetHorarioDisponibleAsesor(undefined);
            else fn_GetHorarioDisponibleTaller(undefined);
        }
        function fn_GetHorarioDisponibleTaller(fl_ver_horario) {
            //Set datos de reserva
            $("#divselhora").empty();
            oCita.nid_asesor = 0;
            oCita.ho_inicio = "";
            oCita.qt_intervalo_atenc = "";

            var coddpto = $("#cboDepartamento").val();
            var codprov = fn_GetValue_Prov();
            var coddist = fn_GetValue_Dist();
            var nid_ubica = fn_GetValue_Ubicacion();
            var nid_taller = fn_GetValue_Taller();

            if (this.oCita.nid_servicio <= 0) {
                $("#txtFecInicio").val("");
                $("#txtFecInicio").datepicker("destroy");
            }
            fc_FillCombo("cboHoraInicioReserva", [], TEXTO_SELECCIONE);
            fc_FillCombo("cboHoraFinalReserva", [], TEXTO_SELECCIONE);

            $("#divGrvUbicacion").empty();

            if (nid_taller != "") PRM_SELECTED = "5";
            else if (nid_ubica != 0) PRM_SELECTED = "4";
            else if (coddist != "") PRM_SELECTED = "3";
            else if (codprov != "") PRM_SELECTED = "2";
            else if (coddpto != "") PRM_SELECTED = "1";
            else PRM_SELECTED = "";

            if (fl_ver_horario == "1" || fl_ver_horario == undefined) {
                if (oCita.nid_servicio > 0 && coddpto != "" && (PARM_13 <= PRM_SELECTED || fl_ubigeo_all == "1")) {
                    var parametros = new Array();
                    parametros[0] = oCita.nid_modelo;
                    parametros[1] = oCita.nid_servicio;
                    parametros[2] = coddpto;
                    parametros[3] = codprov;
                    parametros[4] = coddist;
                    parametros[5] = nid_ubica;
                    parametros[6] = nid_taller;
                    parametros[7] = $("#txtFecInicio").val(); //fe_atencion
                    var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                    var strUrlServicio = no_pagina + "/Get_HorarioDisponible";

                    $("#divProgress_aux").show();
                    fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                        $("#divProgress_aux").hide();

                        if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }

                        if ($("#txtFecInicio").val() == "") {
                            $("#txtFecInicio").datepicker("destroy");
                            $("#txtFecInicio").val(objResponse.sfe_reserva);
                            var DatePicker_Opciones = DatePicker_Opciones_Default;
                            DatePicker_Opciones.minDate = objResponse.sfe_reserva;
                            DatePicker_Opciones.maxDate = objResponse.sfe_max_reserva;
                            DatePicker_Opciones.fl_enabled_textbox = false;
                            this.fc_FormatFecha("txtFecInicio", DatePicker_Opciones, "", "");
                        }

                        id_img_select = "";
                        if (objResponse.fl_seguir == "1") {
                            this.fc_FillCombo("cboHoraInicioReserva", objResponse.oComboHoraInicio, TEXTO_SELECCIONE);
                            this.fc_FillCombo("cboHoraFinalReserva", objResponse.oComboHoraInicio, TEXTO_SELECCIONE);
                            $("#cboHoraInicioReserva option[value='']").remove();
                            $("#cboHoraFinalReserva option[value='']").remove();
                            $("#cboHoraFinalReserva").prop("selectedIndex", $("#cboHoraFinalReserva option").length - 1);

                            oHorario_Cabecera = objResponse.oHorario_Cabecera;
                            oHorario_ModelCol = objResponse.oHorario_ModelCol;
                            oHorarioDisponible = objResponse.oHorarioDisponible;
                            IntervaloT = objResponse.IntervaloT;

                            $("#divGrvUbicacion").empty();
                            $("#divGrvUbicacion").append(objResponse.tbl_Footable);
                            $("#grvUbicacion").footable();
                        }
                        else if (objResponse.fl_seguir == "2") {
                            this.oCita.fe_programada = $("#txtFecInicio").val();
                            this.fn_GetHorarioDisponibleAsesor(undefined);
                        }
                        else if (objResponse.fl_seguir == "0") {
                            $("#divGrvUbicacion").empty();
                            $("#divGrvUbicacion").append(strDivSinHorario);
                            $("#divSinHorario").text(objResponse.msg_retorno);
                        }
                    });
                }
            }
        }
        function fn_GetHorarioDisponibleAsesor(hora_ini_preseleccion) {
            //Set datos de reserva
            $("#divselhora").empty();
            oCita.nid_asesor = 0;
            oCita.ho_inicio = "";
            oCita.qt_intervalo_atenc = "";

            if (this.oCita.nid_servicio <= 0) {
                $("#txtFecInicio").val("");
                $("#txtFecInicio").datepicker("destroy");
            }

            if (fl_cambio_x_horario != true) {
                fc_FillCombo("cboHoraInicioReserva", [], TEXTO_SELECCIONE);
                fc_FillCombo("cboHoraFinalReserva", [], TEXTO_SELECCIONE);
            }
            fl_cambio_x_horario = false;

            $("#divGrvUbicacion").empty();

            //Carga Horario de Asesores
            var parametros = new Array();
            parametros[0] = oCita.nid_modelo;
            parametros[1] = oCita.nid_servicio;
            parametros[2] = $("#cboDepartamento").val();
            parametros[3] = fn_GetValue_Prov();
            parametros[4] = fn_GetValue_Dist();
            parametros[5] = fn_GetValue_Ubicacion();
            parametros[6] = this.oCita.nid_taller;
            parametros[7] = this.oCita.fe_programada;
            parametros[8] = (hora_ini_preseleccion == undefined ? "" : hora_ini_preseleccion);
            parametros[9] = this.oCita.qt_intervalo_taller;
            parametros[10] = IntervaloT;
            parametros[11] = $("#cboHoraInicioReserva").val();
            parametros[12] = $("#cboHoraFinalReserva").val();
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_HorarioDisponible_Asesor";
            fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }

                id_img_select = "";
                if (objResponse.fl_seguir == "1") {
                    $("#txtFecInicio").val(objResponse.sfe_reserva);

                    if (objResponse.oComboHoraInicio.length > 0) {
                        this.fc_FillCombo("cboHoraInicioReserva", objResponse.oComboHoraInicio, TEXTO_SELECCIONE);
                        this.fc_FillCombo("cboHoraFinalReserva", objResponse.oComboHoraInicio, TEXTO_SELECCIONE);
                        $("#cboHoraInicioReserva option[value='']").remove();
                        $("#cboHoraFinalReserva option[value='']").remove();
                        $("#cboHoraFinalReserva").prop("selectedIndex", $("#cboHoraFinalReserva option").length - 1);
                    }

                    $("#divGrvUbicacion").empty();
                    $("#divGrvUbicacion").append(objResponse.tbl_Footable);
                    $("#grvUbicacion").footable();
                }
                else if (objResponse.fl_seguir == "0") {
                    $("#divGrvUbicacion").empty();
                    $("#divGrvUbicacion").append(strDivSinHorario);
                    $("#divSinHorario").text(objResponse.msg_retorno);
                }
            });
        }
        var fl_cambio_x_horario = false;
        $("#cboHoraFinalReserva").change(function () {
            var ho_final = $("#cboHoraInicioReserva").val();
            var ho_inicio = $(this).val();

            if ($("#cboHoraInicioReserva").prop("selectedIndex") >= $("#cboHoraFinalReserva").prop("selectedIndex")) {
                fc_Alert("La hora final debe ser mayor que la hora inicial.");
                return;
            }

            fl_cambio_x_horario = true;

            if (oCita.nid_taller > 0) fn_GetHorarioDisponibleAsesor(undefined);
            else fn_GetHorarioDisponibleTaller(undefined);
        });
        $("#cboHoraInicioReserva").change(function () {
            var ho_inicio = $(this).val();
            var ho_final = $("#cboHoraFinalReserva").val();

            if ($("#cboHoraInicioReserva").prop("selectedIndex") >= $("#cboHoraFinalReserva").prop("selectedIndex")) {
                fc_Alert("La hora inicial debe ser menor que la hora final.");
                return;
            }

            fl_cambio_x_horario = true;

            if (oCita.nid_taller > 0) fn_GetHorarioDisponibleAsesor(undefined);
            else fn_GetHorarioDisponibleTaller(undefined);
        });
    </script>
</asp:Content>
