﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SRC_AnularCita.aspx.cs" Inherits="SRC_AnularCita" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bg_blue">
        <div class="titulo">Anular Cita</div>
        <div id="divPage_Consulta">
            <div id="DivDato1" class="row">
                <div class="col l3 s5 x12">
                    <label class="texto">Seleccione Placa</label>
                </div>
                <div class="col l2 s7 x12">
                    <select id="cboPlaca" style="width: 200px;">
                        <option value=""><%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
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
                        <label id="LblDoc">
                            DNI:</label>
                        <input type="text" id="txtCliDoc" maxlength="20" class="cajatexto" readonly="readonly"
                            style="display: none;" />
                        <label id="lblCliDoc">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="LblTelMov">
                            Teléfono Móvil:
                        </label>
                        <input type="text" id="txtCliTelCel" maxlength="15" class="cajatexto" onkeypress="javascript:return fc_SoloNumeros(event)"
                            style="display: none;" />
                        <label id="lblCliTelCel">
                        </label>
                    </div>
                    <div style="display: flex;">
                        <label id="lblTextoEmail1">
                            E-mail:
                        </label>
                        <input type="text" id="txtCliEmail" maxlength="255" class="cajatexto" style="display: none;" />
                        <label id="lblCliEmail">
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
                    <button id="BtnAnular" type="button" onclick="fn_ConfirmarAnulacion();">
                        Confirmar Anulación
                    </button>
                </div>
            </div>
        </div>
        <div id="divPage_Confirmacion" style="display: none;">
            <div class="row">
                <div class="col l12">
                    <label class="titulo_section">
                        ¿ Está usted seguro de Anular la Cita ?
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
        <div id="divPage_Respuesta" style="display: none;">
            <div class="row">
                <div class="col l12">
                    <label class="titulo">
                        La Cita quedó Anulada
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col l12">
                    Gracias por utilizar el Sistema de Reserva de Cita.
                </div>
            </div>
            <div class="row">
                <div class="col l12">
                    <button id="hlHome" type="button" onclick="javascript:window.location.href='SRC_Home.aspx'"
                        class="botonVerificador">
                        Ir al Home</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "SRC_AnularCita.aspx";
        var id_cliente = 0;
        var TEXTO_SELECCIONE = "<%=Parametros.OBJECTO_SELECCIONE %>";
        var PRM_12 = "<%=Parametros.GetValor(Parametros.PARM._12) %>";
        var PRM_14 = "<%=Parametros.GetValor(Parametros.PARM._14) %>";
        var PRM_15 = "<%=Parametros.GetValor(Parametros.PARM._15) %>";
        var oCitaDetalle;
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
        fn_CargaInicial();
        function fn_CargaInicial() {

            if (sessionStorage.getItem('loginId')) {
                id_cliente = JSON.parse(sessionStorage.getItem("loginId"));
            } else {
                location.href = 'SRC_Home.aspx';
                return false;
            }

            //#region - Carga controles
            var strFiltros = "{'nid_cliente':'" + id_cliente + "'}";
            var strUrlServicio = no_pagina + "/Get_Inicial";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {

                this.fc_FillCombo("cboPlaca", objResponse.oComboPlaca, TEXTO_SELECCIONE);
            });
            //#endregion - Carga controles

            JQGrid_Util.AutoWidthResponsive(idGrilla_Bandeja);

            var no_Home = "<%=Parametros.N_EtiquetaHome %>";
            $("#hlHome").html(no_Home);

            var URL_Home = "javascript:window.location.href='SRC_Home.aspx'";
            $("#hlHome").attr("onclick", URL_Home);

        }
        function fn_ValidarConsulta() {
            var nu_placa = $.trim($('#cboPlaca').val());
            if (nu_placa == '') {
                fc_Alert('Debe seleccionar una placa');
                return false;
            }

            return true;

        }
        function fn_Consultar() {
            if (fn_ValidarConsulta()) {

                var nu_placa;
                nu_placa = $.trim($("#cboPlaca").val());

                var parametros = new Array();
                parametros[0] = nu_placa;
                parametros[1] = id_cliente;

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
                $("#BtnAnular").focus();
                return false;
            }
            else if (parseInt(obj_nu_estado) == 8) {
                Mensaje("msgYaVencCita_1");
                $("#BtnAnular").focus();
                return false;
            }
            else if (parseInt(obj_nu_estado) == 3) {
                Mensaje("msgYaAnulCita_1");
                $("#BtnAnular").focus();
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

                if (fl_confirm == true) {
                    this.fn_ConfirmarAnulacion();
                }

                //#region - "Datos del Cliente"
                $("#lblCliEmail").html("<a href='mailto:" + objResponse.no_correo + "'>" + objResponse.no_correo + "</a>");
                $("#txtCliEmail").val(objResponse.no_correo);

                if (objResponse.nu_celular_c != "" || objResponse.nu_celular_c != null) {
                    if (objResponse.nu_celular_c.indexOf("-") >= 0) {
                        strMovilNum = objResponse.nu_celular_c.split('-')[1];
                    }
                    else
                        strMovilNum = objResponse.nu_celular_c;
                }

                $("#txtCliTelCel").val(strMovilNum);
                $("#lblCliTelCel").text(strMovilNum);
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
                    $("#btnVerMapa").attr("onclick", "javascript:foto('" + strRutaMapa + "','" + objResponse.no_taller + "');")
                }
                else {
                    $("#btnVerMapa").attr("onclick", "javascript:fc_Alert('<%=Parametros.msgNoMapa %>');")
                }
                //#endregion - "Datos de Hora de Cita"

                $("#txtObservacion").val(objResponse.tx_observacion);
                $("#lblTextoObservFijo").text(objResponse.tx_observacion);

                if (objResponse.flg_estado_botones == 0) {
                    $("#btnActCliente,#btnVerMapa").attr("disabled", true);
                }
                else {
                    $("#btnActCliente,#btnVerMapa").removeAttr("disabled");
                }
                //#endregion - "Datos de Recordatorio"
                //#region - "Habilita botones según estado"
                var nu_estado = objResponse.nu_estado;
                if (parseInt(nu_estado) == 1) {
                    if (PRM_12 == "0") {
                        $("#div_btnConfirmarCita").show()
                    }
                    $("#div_btnReprogramarCita,#div_btnAnularCita").css("display", "block");
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
        /*#endregion VARIABLES GENERALES*/

        function fn_edicionDatosCliente(blnEditar) {

            if (!blnEditar) {
                $("#txtCliEditNom,#txtCliEditApeP,#txtCliEditApeM").css("display", "none");
                $("#lblCliNombre").css("display", "block");
                $("#txtCliNombre").css("display", "none");
                $("#txtCliDoc").removeAttr("readonly");

                $("#txtCliDoc,#txtCliNombre,#txtCliTelCel").css("display", "none");
                $("#lblCliDoc,#lblCliNombre,#lblCliTelCel").css("display", "block");

                $("#btnGrabarCliente,#btnCancActualiza,#txtCliEmail").css("display", "none");
                $("#lblCliEmail,#btnActCliente").css("display", "block");
            }
            else {
                $("#txtCliEditNom,#txtCliEditApeP,#txtCliEditApeM").css("display", "block");
                $("#lblCliNombre").css("display", "none");
                $("#txtCliNombre").css("display", "none");

                $("#txtCliDoc,#txtCliTelCel").css("display", "block");
                $("#lblCliDoc,#lblCliNombre,#lblCliTelCel").css("display", "none");

                $("#btnGrabarCliente,#btnCancActualiza,#txtCliEmail").css("display", "block");
                $("#lblCliEmail,#btnActCliente").css("display", "none");
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
            $("#txtCliTelCel").val(strMovilNum);
            $("#txtCliEmail").val($("#lblCliEmail").text());
            fn_edicionDatosCliente(false);
        }
        function fn_GrabarCliente() {
            NomCom = $("#txtCliEditNom").val();
            ApePat = $("#txtCliEditApeP").val();
            ApeMat = $("#txtCliEditApeM").val();
            NumDoc = $("#txtCliDoc").val();
            CliMov = $("#txtCliTelCel").val();
            CliEma = $("#txtCliEmail").val();

            if (CliEma != "") {
                if (fc_ValidarEmail(CliEma) == false) {
                    fc_Alert("E-mail Personal incorrecto.");
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
            parametros[6] = CliMov;
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/ActualizarDatosCliente";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) { });

            $("#lblCliNombre").text(NomCom + " " + ApePat + " " + ApeMat);
            $("#lblCliDoc").text(NumDoc);
            $("#lblCliEmail").text(CliEma);
            $("#lblCliTelCel").text(CliMov);
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
                case "msgYaVencCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaVencCita_1"].ToString() %>'; break;
                case "msgYaAnulCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaAnulCita_1"].ToString() %>'; break;
                case "msgYaConfCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgYaConfCita_1"].ToString() %>'; break;
                case "codPais": srtSMS = '<%=ConfigurationManager.AppSettings["CodPais"].ToString() %>'; break;
                case "nDatoConsulta1_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta1_1"].ToString() %>'; break;
                case "nDatoConsulta2_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta2_1"].ToString() %>'; break;
                case "nDatoConsulta3_1": srtSMS = '<%=ConfigurationManager.AppSettings["nDatoConsulta3_1"].ToString() %>'; break;
                case "msgPlaca_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgPlaca_1"].ToString() %>'; break;
                case "msgDep_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgDep_1"].ToString() %>'; break;
                case "msgProv_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgProv_1"].ToString() %>'; break;
                case "msgDist_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgDist_1"].ToString() %>'; break;
                case "msgNombres_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNombres_1"].ToString() %>'; break;
                case "msgNoApePat_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApePat_1"].ToString() %>'; break;
                case "msgNoApeMat_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoApeMat_1"].ToString() %>'; break;
                case "msgNoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoMovil_1"].ToString() %>'; break;
                case "msgNoEmail_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoEmail_1"].ToString() %>'; break;
                case "msgNoDia_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDia_1"].ToString() %>'; break;
                case "msgNoHora_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHora_1"].ToString() %>'; break;
                case "msgNoHoraIni_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraIni_1"].ToString() %>'; break;
                case "msgNoHoraFin_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoHoraFin_1"].ToString() %>'; break;
                case "msgNoCodRes_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodRes_1"].ToString() %>'; break;
                case "msgNoDoc_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoDoc_1"].ToString() %>'; break;
                case "msgNoNumTelfMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfMovil_1"].ToString() %>'; break;
                case "msgNoNumFijoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_1"].ToString() %>'; break;
                case "msgNoCita_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCita_1"].ToString() %>'; break;
            }
            return srtSMS;
        }

        function fn_ConfirmarAnulacion() {
            $("body").scrollTop(0);
            $("#divPage_DatosRegistro").hide();
            $("#divPage_Confirmacion").fadeIn();
        }
        function fn_SiEstoySeguro() {
            $("body").scrollTop(0);

            if (parseInt(this.oCitaDetalle.nu_estado) == 6) {
                Mensaje("msgYaConfCita_1");
                $("#BtnAnular").focus();
                return false;
            }
            else if (parseInt(this.oCitaDetalle.nu_estado) == 3) {
                Mensaje("msgYaAnulCita_1");
                $("#BtnAnular").focus();
                return false;
            }
            else {
                var parametros = new Array();
                parametros[0] = this.oCitaDetalle.nu_estado;
                parametros[1] = this.oCitaDetalle.nid_cita;
                parametros[2] = this.oCitaDetalle.nid_estado;
                parametros[3] = this.oCitaDetalle.nid_asesor;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/ConfirmarAnulacion";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    var result = objResponse.d;
                    if (result == 0) { fc_Alert('Error') }
                    else if (result == -1) { fc_Alert('Error al reasignar') }
                    else if (result == -2) { fc_Alert('Error al reasignar - Consultar con el administrador') }
                    else if (result == -3) {
                        fc_Alert('"<%=Parametros.msgNoExisteCita %>"');
                        $("#btnAnular").focus();
                        $(location).attr('href', "SRC_Home.aspx");
                    }
                    else if (result == -4) {
                        fc_Alert('"<%=Parametros.msgEstaCambio %>"');
                        $("#divPage_Confirmacion").hide();
                        $("#divPage_DatosRegistro").hide();
                        $("#btnActCliente").css("display", "none");
                        $("#btnAnular").css("display", "none");
                        $("#hlHome").css("display", "block");
                    }
                    else { //OK
                        $("#lblEstadoCita").text("<%=Parametros.msgAnulCita %>");
                        $("#divPage_Confirmacion").hide();
                        $("#divPage_DatosRegistro").hide();
                        $("#divPage_Respuesta").fadeIn();
                        $("#hlHome").css("display", "block");
                    }
                });
            }
        }
        function fn_NoEstoySeguro() {
            $("body").scrollTop(0);
            $("#divPage_DatosRegistro").fadeIn();
            $("#divPage_Confirmacion").hide();
        }
    </script>
</asp:Content>
