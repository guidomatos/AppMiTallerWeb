<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SRC_ReservarCita.aspx.cs" Inherits="SRC_ReservarCita" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="js/footable/footable.core.css" rel="stylesheet" type="text/css" />
    <link href="js/footable/footable.standalone.css" rel="stylesheet" type="text/css" />
    <script src="js/footable/footable.js" type="text/javascript"></script>
    <link href="css/magnific-popup/magnific-popup.css" rel="stylesheet" type="text/css" />
    <script src="js/magnific-popup/jquery.magnific-popup.min.js" type="text/javascript"></script>
    <link href="css/jcarousel/jcarousel.responsive.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jcarousel/jquery.jcarousel.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="bg_blue">
        <div id="divPage_Paso1">
            <div class="titulo_pasos">
                Paso 1 de 3: Reservar Horario.</div>
            <div class="titulo_section">
                1. Datos del Vehiculo</div>
            <div class="row" id="rowPlaca">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Placa %>:</span>
                </div>
                <div class="col l2 s7 x12">
                    <input id="txtPlaca" type="text" style="width: 70px;" maxlength="6" />
                </div>
                <div class="col l7 s12 x12">
                    <button id="btnBuscarVehiculoxPlaca" type="button" onclick="fn_GetVehiculo();">
                        <%=Parametros.N_VerificaNum %>
                    </button>
                    <!--
                    <label id="lblNoRecuerdo" style="font-weight:bold;"></label>
                    <label id="span_NoRecordAqui" class="enlace" style="font-weight:bold;" onclick="fn_OpenContacto();"></label>
                    -->
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">Marca Vehículo:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboMarca" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">Modelo Vehículo:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboModelo" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div id="div_AnioTipoVeh" style="display: none;">
                <div class="row">
                    <div class="col l3 s5 x12">
                        <span class="texto">
                            <%=Parametros.N_AnioVehiculo %>:</span>
                    </div>
                    <div class="col l9 s7 x12">
                        <select id="cboAño">
                            <option value="">
                                <%=Parametros.OBJECTO_SELECCIONE %></option>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3 s5 x12">
                        <span class="texto">
                            <%=Parametros.N_TipoVehiculo %>:</span>
                    </div>
                    <div class="col l9 s7 x12">
                        <select id="cboTipoCombustible">
                            <option value="">
                                <%=Parametros.OBJECTO_SELECCIONE%></option>
                        </select>
                    </div>
                </div>
            </div>
            <div class="titulo_section">
                2. Datos del servicio a solicitar</div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">Tipo Servicio:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboTipoServicio" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">Servicio Específico:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboServicioEspecifico" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
                </div>
            </div>
            <div class="row" id="divObservaciones">
                <div class="col l3 s5 x12">
                    <span class="texto">Observaciones:</span>
                </div>
                <div class="col l9 s7 x12">
                    <textarea id="txtObservaciones" rows="4" style="width: 100%;"></textarea>
                </div>
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
            <div class="row" style="display: none;">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Local %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <select id="cboUbicacion" style="width: 200px;">
                        <option value="">
                            <%=Parametros.OBJECTO_SELECCIONE %></option>
                    </select>
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
                        <button type="button" id="btnMapaTallerPR">
                        Ver Mapa de ubicación
                    </button>
                </div>
            </div>
            <div class="titulo_section">
                3. Datos de la reserva de cita: Fecha y horario</div>
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
                <div class="col l3 s12" style="font-size: 10px; color: #069;">
                    <img src="img/ocupado.png" alt="" style="position:relative; top:6px;" />
                    Horario reservado.
                </div>
                <div class="col l4 s12" style="font-size: 10px; color: #069;">
                    <img src="img/asesor_b.png" alt="" style="position:relative; top:6px;" />
                    Asesor no Disponible.
                </div>
            </div>
            <div class="row">
                <div class="col l12 x12">
                    <button type="button" onclick="fn_Continuar();">
                        Continuar</button>
                </div>
            </div>
        </div>
        <div id="divPage_Paso2" style="display: none;">
            <div class="titulo_pasos">
                Paso 2 de 3: Datos de Contacto.</div>
            <div class="titulo_section">
                4. Datos del Cliente</div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_TipoDocumento %>:</span>
                </div>
                <div class="col l2 s7 x12">
                    <select id="cboTipoDocumento">
                    </select>
                    <input id="txtNroDocumento" type="text" style="width: 70px;" maxlength="10" onpaste="return false;"
                        onblur="fn_VerificarDoc();" />
                </div>
                <div class="col l7 x12">
                    <button type="button" onclick="fn_VerificarDoc();">
                        <%=Parametros.N_VerificaDoc %>
                    </button>
                </div>
            </div>
            <div class="titulo_section">
                <label id="lblTextoDatosContacto">
                    Verifique sus datos a continuación y actualícelos si es necesario
                </label>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_Nombres %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtNombres" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_ApellidoPat %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtApePaterno" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_ApellidoMat %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtApeMaterno" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_EmailPersonal %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtEmailPersonal" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row" id="divEmailTrab">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_EmailTrabajo %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtEmailTrabajo" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row" id="divEmailAlter">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_EmailAlternativo %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtEmailAternativo" type="text" style="width: 150px;" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_TelefonoFijo %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <span class="texto">Código de Ciudad:</span>
                    <input id="txtCodTelefono" type="text" style="width: 20px;" maxlength="2" onpaste="return false;" onkeypress="javascript:return fc_SoloNumeros(event)" />
                    <span class="texto">Número Telefónico:</span>
                    <input id="txtNroTelefono" type="text" style="width: 150px;" onpaste="return false;" onkeypress="javascript:return fc_SoloNumeros(event)" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_TelefonoMovil %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="txtNroCelular" type="text" style="width: 150px;" onpaste="return false;" onkeypress="javascript:return fc_SoloNumeros(event)" />
                </div>
            </div>
            <div class="row">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        <%=Parametros.N_EnviarRecord %>:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="chkEmailCli" type="checkbox" class="chk_materialize filled-in" disabled="disabled"
                        checked="checked" />
                    <label for="chkEmailCli">
                        Por E-mail</label>
                </div>
            </div>
            <div class="row" id="divValeTaxi">
                <div class="col l3 s5 x12">
                    <span class="texto">
                        Vale Taxi:</span>
                </div>
                <div class="col l9 s7 x12">
                    <input id="chkValeTaxi" type="checkbox" class="chk_materialize filled-in" />
                    <label for="chkValeTaxi">
                        SI</label>
                </div>
            </div>
            <div id="divDatosRecord">
                <div class="row">
                    <div class="col l12">
                        <label class="titulo_section">
                            <%=Parametros.N_DatosRecord %></label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3 s5 x12">
                        <span class="texto">Día:</span>
                    </div>
                    <div class="col l9 s7 x12">
                        <select id="cboDiaContacto">
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3 s5 x12">
                        <span class="texto">Horario desde:</span>
                    </div>
                    <div class="col l9 s7 x12">
                        <select id="cboHIContacto">
                        </select>
                        <span class="texto">Hasta:</span>
                        <select id="cboHFContacto">
                        </select>
                    </div>
                </div>
            </div>
            <!--<div class="row">
                <div class="col l12 PieTextoConsulta">
                    <label id="lblTextoOferta">
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col l12">
                    <input type="radio" id="ind_acepto" name="indicador" checked="checked" value="1" />
                    <label for="ind_acepto">
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col l12">
                    <input type="radio" id="ind_noacepto" name="indicador" value="2" />
                    <label for="ind_noacepto">
                    </label>
                </div>
            </div>
            -->
            <div class="row">
                <div class="col l12">
                    <label id="lblTextoNota">
                    </label>
                </div>
            </div>
            <div class="row">
                <div class="col l12 x12">
                    <button type="button" onclick="fn_Reservar();">
                        Reservar Hora</button>
                </div>
            </div>
        </div>
        <div id="divPage_Paso3" style="display: none;">
            <div class="titulo_pasos">
                Paso 3 de 3: Resumen de Cita.</div>
            <div class="titulo_section">
                5. Reserva realizada
            </div>
            <div class="titulo_section">
                El Código de Reserva de Cita es:
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
                    <button id="btnImprimir" type="button">
                        Imprimir</button>
                </div>
                <div class="col l2 s12 x12">
                    <button id="btnConfirmar" type="button" onclick="fn_Confirmar()">Confirmar Cita</button>
                </div>
                <div class="col l2 s12 x12">
                    <button id="btnAnular" type="button" onclick="fn_AnularCita()">Anular Cita</button>
                </div>
                <div class="col l6 s12 x12">
                    <button id="btnReprogramar" type="button" onclick="fn_ReprogramarCita()">Reprogramar Cita</button>
                </div>
            </div>
        </div>
    </div>
    <div id="popup_ContactoCallCenter" class="white-popup mfp-with-anim mfp-hide" style="max-width:300px;">
        <div class="title_modal" style="font-weight:bold;text-align:center;text-decoration:underline;">Contacta a Call Center</div>
        <div class="row">
            <div class="col l4 s4 x12"><label style="font-weight:bold;">Días</label></div>
            <div class="col l8 s8 x12"><label id="lblCallDIa"></label></div>
        </div>
        <div class="row">
            <div class="col l4 s4 x12"><label style="font-weight:bold;">Horario:</label></div>
            <div class="col l8 s8 x12"><label id="lblCallHorario"></label></div>
        </div>
        <div class="row">
            <div class="col l4 s4 x12"><label style="font-weight:bold;">Teléfono(s):</label></div>
            <div class="col l8 s8 x12"><label id="lblCallTelefonos"></label></div>
        </div>
        <div class="row">
            <div class="col l4 s4 x12"><label style="font-weight:bold;">Email:</label></div>
            <div class="col l8 s8 x12"><label id="lblCallEmail"></label></div>
        </div>
    </div>
    <div id="mpCitaPend" title="Sistema de Reserva de Cita">
        <div id="mpCitaPend_General">
            <div id="mpCitaPend_Contenedor">
                <h2>
                    Esta
                    <%=Parametros.N_Placa %>
                    tiene una cita pendiente con los siguientes datos:</h2>
                <div style="border-bottom: #cccccc 1px dotted; margin: 5px 0px 10px 0px;">
                </div>
                <div class="row">
                    <div class="col l3">
                        Cliente:
                    </div>
                    <div class="col l9">
                        <label id="lblNomCliente_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Teléfono:
                    </div>
                    <div class="col l9">
                        <label id="lblTelfCli_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        <%=Parametros.N_Placa %>:
                    </div>
                    <div class="col l9">
                        <label id="lblPlaca_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Marca:
                    </div>
                    <div class="col l9">
                        <label id="lblMarca_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Modelo:
                    </div>
                    <div class="col l9">
                        <label id="lblModelo_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Código de Reserva:
                    </div>
                    <div class="col l9">
                        <label id="lblCodReserva_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Fecha Cita:
                    </div>
                    <div class="col l9">
                        <label id="lblFechaCita_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Hora Cita:
                    </div>
                    <div class="col l9">
                        <label id="lblHoraCita_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Servicio:
                    </div>
                    <div class="col l9">
                        <label id="lblServicio_CP">
                        </label>
                    </div>
                </div>
                <div class="row" style="display: none;">
                    <div class="col l3">
                        <%=Parametros.N_Local %>:
                    </div>
                    <div class="col l9">
                        <label id="lblTaller_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Dirección:
                    </div>
                    <div class="col l9">
                        <label id="lblDireccion_CP">
                        </label>
                    </div>
                </div>
                <div class="row">
                    <div class="col l3">
                        Asesor de Servicio:
                    </div>
                    <div class="col l9">
                        <label id="lblAesor_CP">
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divProgress_aux" class="Progress">
        <img alt="...Cargando..." src="img/loading.gif" style="position: absolute; left: 48%;
            top: 48%; vertical-align: middle;" />
    </div>
    <div id="popup_TxInformativo" class="white-popup mfp-with-anim mfp-hide">
    </div>
    <div id="mpPromociones" class="white-popup mfp-with-anim mfp-hide">
        <div id="mpPromociones_Titulo" class="titulo_pasos" style="text-align: center;">
            Taller:</div>
        <div id="divFotos_TextoInfo" class="jcarousel-wrapper" style="max-width: 300px;">
            <div id="divImagen" class="jcarousel" data-jcarousel="true">
            </div>
            <a href="#" class="jcarousel-control-prev" data-jcarouselcontrol="true"></a>
            <a href="#" class="jcarousel-control-next" data-jcarouselcontrol="true"></a>
            <div id="divImagenPagination"></div>
        </div>
        <div id="mpPromociones_General">
            <ul>
                <li><a href="#tabsmpPromociones_Promocion">Promociones</a></li>
                <li><a href="#tabsmpPromociones_Noticia">Noticias</a></li>
                <li><a href="#tabsmpPromociones_Dato">Datos</a></li>
            </ul>
            <div id="tabsmpPromociones_Promocion" style="max-height: 200px; overflow: auto;">
            </div>
            <div id="tabsmpPromociones_Noticia" style="max-height: 200px; overflow: auto;">
            </div>
            <div id="tabsmpPromociones_Dato" style="max-height: 200px; overflow: auto;">
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var no_pagina = "SRC_ReservarCita.aspx";
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
        var oComboTipoServicio = [];
        var oComboProvincia = [];
        var oComboDistrito = [];
        var oComboTaller = [];
        var fl_ubigeo_all = "1";
        var oRUT = '<%=ConfigurationManager.AppSettings["RUT"].ToString() %>';
        var oDNI = '<%=ConfigurationManager.AppSettings["DNI"].ToString() %>';
        var oRUC = '<%=ConfigurationManager.AppSettings["RUC"].ToString() %>';
        var MAX_RUT = 9;
        var MAX_DNI = 8;
        var MAX_RUC = 9;
        var MAX_CE = 20;
        var strDivSinHorario = "<div id='divSinHorario' style='background-color: #FFF; font-weight: bold; padding-top: 25px; padding-bottom:25px; text-align: center; font-size: 18px;'></div>";

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
        //#region Tab 1
        function fn_CargaInicial() {
            $("#txtPlaca").keydown(function (event) { fc_PressKey(13, "btnBuscarVehiculoxPlaca"); });
            this.Modal_Util.FormatModal("mpCitaPend", true, function () { });
            $("#mpPromociones_General").tabs();
            /*#region - Bloqueando controles*/
            $("#cboMarca").prop("disabled", true);
            $("#cboModelo").prop("disabled", true);
            $("#cboAño").prop("disabled", true);
            $("#cboTipoCombustible").prop("disabled", true);
            $("#cboTipoServicio").prop("disabled", true);
            if ("<%=Parametros.SRC_MostrarAnioTipoVehiculo %>" == "1") {
                $("#div_AnioTipoVeh").show();
            }
            /*#endregion - Bloqueando controles*/
            $("#btnMapaTallerPR").hide();
                var msg_Norecuerdo = '<%=ConfigurationManager.AppSettings["nRecuerde_1"].ToString()  %>';
                $("#lblNoRecuerdo").text(msg_Norecuerdo.replace("{aquí}", ""));
                $("#span_NoRecordAqui").text("aquí");

                $("#btnMapaTallerPR").text("Ver más información"); 
            //#region - Carga controles
            var strFiltros = "{'co_marca':'" + this.MP_co_marca_permitida + "'}";
            var strUrlServicio = no_pagina + "/Get_Inicial";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {

                $("#lblCallDIa").text(objResponse.oDatosContacto[0]);
                $("#lblCallHorario").text(objResponse.oDatosContacto[1]);
                $("#lblCallTelefonos").text(objResponse.oDatosContacto[2]);
                $("#lblCallEmail").text(objResponse.oDatosContacto[3]);

                this.oComboTipoServicio = objResponse.oComboTipoServicio;
                this.fc_FillCombo("cboTipoServicio", objResponse.oComboTipoServicio, TEXTO_SELECCIONE);
                this.fc_FillCombo("cboTipoDocumento", objResponse.oComboTipoDocumento, TEXTO_SELECCIONE);
                $("#cboTipoDocumento option[value='']").remove();
                setMaxLenthNroDocumento();
                this.fc_FillCombo("cboDiaContacto", objResponse.oDias, "---");
                this.fc_FillCombo("cboHIContacto", objResponse.oHorasIni, "---");
                this.fc_FillCombo("cboHFContacto", objResponse.oHorasFin, "---");
               
                $("#lblTextoOferta").html(objResponse.oTxtLegal[0]);
                $("label[for='ind_acepto']").text(objResponse.oTxtLegal[1]);
                $("label[for='ind_noacepto']").text(objResponse.oTxtLegal[2]);
                $("#lblTextoNota").text(objResponse.oTxtLegal[3]);
            });
            //#endregion - Carga controles

            
                $("#divEmailTrab").show();
                $("#divEmailAlter").hide();
                $("#divTallerMapa").show();
            

            if (PARM_14 == "1") $("#divDatosRecord").show();
            else $("#divDatosRecord").hide();
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
        function fn_MostrarPromocion(codTaller) {
            var strFiltros = "{'codTaller':" + codTaller + "}";
            var strUrlServicio = no_pagina + "/Get_ContenidoInfo";
            this.fc_CallService(strFiltros, strUrlServicio, function (objResponse) {
                var res = objResponse;
                if (res[0] != '0') {
                    $("#mpPromociones_Titulo").html("TALLER: " + res[0]);
                    $("#tabsmpPromociones_Promocion").html(res[1]); //PROMOCION
                    $("#tabsmpPromociones_Noticia").html(res[2]); //NOTICIA
                    var tbl = '';
                    tbl += '<table id="tblDatosT" width="420px" class="datos"><tbody>';
                    tbl += '<tr><td style="width:25%">Dirección:</td><td>' + res[5] + '</td></tr>';
                    tbl += '<tr><td>Teléfonos:</td><td>' + res[6] + '</td></tr>';
                    tbl += '<tr><td colspan="2" style="text-align:center;padding:0px;border: solid 1px #464646;height:200px;">';
                    tbl += '<img src="images/mapas/' + res[3] + '" alt="" width="100%" style="border:0;" />';
                    tbl += '</td></tr></tbody></table>';
                    $("#tabsmpPromociones_Dato").html(tbl);

                    if (res[4].indexOf("Actualmente no hay fotos disponibles") >= 0) {
                        $("#divFotos_TextoInfo").hide();
                        $("#divImagen").html("");

                        $.magnificPopup.open({
                            items: {
                                src: '#mpPromociones',
                                type: 'inline'
                            }
                            , removalDelay: 500,
                            mainClass: "mfp-zoom-in",
                            midClick: true
                        });
                    }
                    else {
                        $("#divFotos_TextoInfo").show();
                        $("#divImagen").html("<ul id='tabImagenes' style='left: 0px; top: 0px;'></ul>");
                        $("#tabImagenes").append(res[4].split("|")[0]);

                        $("#divImagenPagination").html("<p class='jcarousel-pagination' data-jcarouselpagination='true'></p>");
                        $("#divImagenPagination.jcarousel-pagination").append(res[4].split("|")[1]);

                        $.magnificPopup.open({
                            items: {
                                src: '#mpPromociones',
                                type: 'inline'
                            }
                            , removalDelay: 500,
                                mainClass: "mfp-zoom-in",
                                midClick: true
                            , callbacks: {
                                close: function () {
                                    $('.jcarousel').jcarousel('destroy');
                                }
                            }  
                        });

                        var jcarousel = $('.jcarousel');
                        jcarousel.on('jcarousel:reload jcarousel:create', function () {
                            var carousel = $(this), width = carousel.innerWidth();
                            if (width >= 600) {
                                width = width / 3;
                            } else if (width >= 350) {
                                width = width / 2;
                            }
                            carousel.jcarousel('items').css('width', Math.ceil(width) + 'px');
                        })
                        .jcarousel({
                            wrap: 'circular'
                        }).jcarouselAutoscroll({
                            interval: 3000,
                            target: '+=1',
                            autostart: true
                        });

                        $('.jcarousel-control-prev').jcarouselControl({
                            target: '-=1'
                        });

                        $('.jcarousel-control-next').jcarouselControl({
                            target: '+=1'
                        });

                        $('.jcarousel-pagination').on('jcarouselpagination:active', 'a', function () {
                            $(this).addClass('active');
                        }).on('jcarouselpagination:inactive', 'a', function () {
                            $(this).removeClass('active');
                        }).on('click', function (e) {
                            e.preventDefault();
                        })
                        .jcarouselPagination({
                            perPage: 1,
                            item: function (page) {
                                return '<a href="#' + page + '">' + page + '</a>';
                            }
                        });
                    }
                }
                else {
                    fc_Alert("Este taller no contiene un contenido informativo.");
                }

            });
        }
        function fn_GetVehiculo() {
            var nu_placa = fc_Trim($("#txtPlaca").val());
            var msg_retorno = "";
            if (nu_placa == "") { msg_retorno = "- Debe ingresar número de <%=Parametros.N_Placa %>"; }
            else if (nu_placa.length < 6) { msg_retorno = "- Número de <%=Parametros.N_Placa %> incorrecto." }

            if (msg_retorno != "") {
                fc_Alert(msg_retorno);
            }
            else {
                var parametros = new Array();
                parametros[0] = nu_placa;
                parametros[1] = this.MP_co_marca_permitida;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/Get_Vehiculo";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    this.fn_Limpiar_Paso1();
                    if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
                    this.fc_FillCombo("cboAño", objResponse.oComboAnio, TEXTO_SELECCIONE);
                    this.fc_FillCombo("cboTipoCombustible", objResponse.oComboTipoVeh, TEXTO_SELECCIONE);

                    if (objResponse.oCitaPendiente != null && objResponse.oCitaPendiente != "") {
                        this.Modal_Util.Open("mpCitaPend");
                        $("#lblNomCliente_CP").text(objResponse.oCitaPendiente.no_cliente);
                        $("#lblTelfCli_CP").text(objResponse.oCitaPendiente.nu_tel_fijo);
                        $("#lblPlaca_CP").text(objResponse.oCitaPendiente.nu_placa);
                        $("#lblMarca_CP").text(objResponse.oCitaPendiente.no_marca);
                        $("#lblModelo_CP").text(objResponse.oCitaPendiente.no_modelo);
                        $("#lblCodReserva_CP").text(objResponse.oCitaPendiente.cod_reserva_cita);
                        $("#lblFechaCita_CP").text(objResponse.oCitaPendiente.fecha_prog);
                        $("#lblHoraCita_CP").text(objResponse.oCitaPendiente.ho_inicio);
                        $("#lblServicio_CP").text(objResponse.oCitaPendiente.no_servicio);
                        $("#lblTaller_CP").text(objResponse.oCitaPendiente.no_taller);
                        $("#lblDireccion_CP").text(objResponse.oCitaPendiente.no_direccion);
                        $("#lblAesor_CP").text(objResponse.oCitaPendiente.no_asesor);
                    }

                    if (objResponse.fl_seguir == "1") {
                        if (objResponse.oTxtLegal != null) {
                            $("#lblTextoOferta").html(objResponse.oTxtLegal[0]);
                            $("label[for='ind_acepto']").text(objResponse.oTxtLegal[1]);
                            $("label[for='ind_noacepto']").text(objResponse.oTxtLegal[2]);
                        }

                        if (objResponse.oComboMarca != null && objResponse.oComboMarca != "") {
                            this.fc_FillCombo("cboMarca", objResponse.oComboMarca, TEXTO_SELECCIONE);
                            if (objResponse.oComboMarca.length == 1) {
                                $("#cboMarca").val(objResponse.oComboMarca[0].value);
                                $("#cboModelo").prop("disabled", false);
                            }
                        }
                        if (objResponse.oComboModelo != null && objResponse.oComboModelo != "") {
                            this.fc_FillCombo("cboModelo", objResponse.oComboModelo, TEXTO_SELECCIONE);
                        }

                        if (objResponse.oVehiculo != null && objResponse.oVehiculo != "") {
                            $("#cboModelo").val(objResponse.oVehiculo.nid_modelo).prop("disabled", true);
                            $("#cboModelo").trigger("change");
                            if (objResponse.oVehiculo.nu_anio == 0) { $("#cboAño").val("").prop("disabled", true); }
                            else { $("#cboAño").val(objResponse.oVehiculo.nu_anio).prop("disabled", true); }
                            $("#cboTipoCombustible").val(objResponse.oVehiculo.co_tipo).prop("disabled", true);

                            //Set datos de reserva
                            oCita.nid_vehiculo = objResponse.oVehiculo.nid_vehiculo;
                            oCita.nu_placa = objResponse.oVehiculo.nu_placa;
                            oCita.nu_vin = objResponse.oVehiculo.nu_vin;
                            oCita.nid_marca = objResponse.oVehiculo.nid_marca;
                            oCita.no_marca = $("#cboMarca option:selected").text();
                            oCita.nid_modelo = objResponse.oVehiculo.nid_modelo;
                            oCita.nu_anio = objResponse.oVehiculo.nu_anio;
                            oCita.co_tipo_veh = objResponse.oVehiculo.co_tipo;
                            oCita.co_modeloservicio_ax = objResponse.oVehiculo.co_modeloservicio_ax;
                            oCita.fl_campania_veh = objResponse.oVehiculo.fl_campania_veh;

                            //Quitar focus
                            $("#txtPlaca").blur();
                                this.oComboTipoServicio = objResponse.oComboTipoServicio;
                                this.fc_FillCombo("cboTipoServicio", objResponse.oComboTipoServicio, TEXTO_SELECCIONE);
                        }
                        else {
                            $("#cboModelo").trigger("change");
                        }
                    }
                });
            }
        }
        $("#cboModelo").change(function () {
            var nid_modelo = $(this).val();
            oCita.nid_modelo = nid_modelo;
            var fl_block = true;
            if (nid_modelo > 0) { fl_block = false; }
            $("#cboAño").prop("selectedIndex", 0).prop("disabled", fl_block);
            $("#cboTipoCombustible").prop("selectedIndex", 0).prop("disabled", fl_block);
            $("#cboTipoServicio").prop("selectedIndex", 0).prop("disabled", fl_block);
            $("#cboTipoServicio").trigger("change");
        });
        $("#cboTipoServicio").change(function () {
            var nid_tipo_servicio = $(this).val();
            if (nid_tipo_servicio > 0) {
                var objTipoServicios = $.grep(oComboTipoServicio, function (e) { return e.value == nid_tipo_servicio; });
                $("#txtObservaciones").val("");
                $("#divObservaciones").css("display", objTipoServicios[0].fl_visible_obs ? "block" : "none");

                var parametros = new Array();
                parametros[0] = nid_tipo_servicio;
                parametros[1] = oCita.nid_vehiculo;
                parametros[2] = oCita.nid_marca;
                parametros[3] = oCita.nid_modelo;
                parametros[4] = oCita.co_modeloservicio_ax;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/Get_Servicios";
                fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
                    this.fc_FillCombo("cboServicioEspecifico", objResponse.oComboServicios, TEXTO_SELECCIONE);

                    if (objResponse.tx_informativo != "") {
                        $('#popup_TxInformativo').html(objResponse.tx_informativo);
                        $.magnificPopup.open({
                            items: {
                                src: '#popup_TxInformativo',
                                type: 'inline'
                            }
                            , removalDelay: 500,
                            mainClass: "mfp-zoom-in",
                            midClick: true
                        });
                    }

                    $("#cboServicioEspecifico").trigger("change");
                });
            }
            else {
                fc_FillCombo("cboServicioEspecifico", [], TEXTO_SELECCIONE);
                $("#cboServicioEspecifico").trigger("change");
            }
        });
        $("#cboServicioEspecifico").change(function () {
            var nid_servicio = $(this).val();
            //Set datos de reserva
            oCita.nid_servicio = nid_servicio;

            oComboProvincia = [];
            oComboDistrito = [];
            if (nid_servicio > 0) {
                var parametros = new Array();
                parametros[0] = nid_servicio;
                parametros[1] = oCita.nid_marca;
                parametros[2] = oCita.nid_modelo;
                parametros[3] = oCita.nu_placa;
                parametros[4] = MP_co_marca_permitida;
                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                var strUrlServicio = no_pagina + "/Get_UbigeoDisponible";
                fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
                    var text_default = TEXTO_TODOS;
                    if (PARM_13 == "1") TEXTO_SELECCIONE;
                    if (objResponse.fl_seguir == "1") {

                        this.fc_FillCombo("cboDepartamento", objResponse.oComboDepartamento, text_default);
                        if (objResponse.oComboDepartamento.length == 1) {
                            $("#cboDepartamento").val(objResponse.oComboDepartamento[0].value);
                        }
                        oComboProvincia = objResponse.oComboProvincia;
                        oComboDistrito = objResponse.oComboDistrito;
                        $("#cboDepartamento").trigger("change");
                    }
                    else {
                        oComboProvincia = [];
                        oComboDistrito = [];
                        this.fc_FillCombo("cboDepartamento", [], text_default);
                        $("#cboDepartamento").trigger("change");
                    }
                });
            }
            else {
                fc_FillCombo("cboDepartamento", [], TEXTO_SELECCIONE);
                $("#cboDepartamento").trigger("change");
            }
        });
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
                    if (nid_taller_sel != undefined && nid_taller_sel != "") { $("#cboTaller").val(nid_taller_sel);}
                    if (objTalleres.length == 1) {
                        $("#cboTaller").val(objTalleres[0].value);

                        $("#btnMapaTallerPR").show();

                        var strMapaTaller = objTalleres[0].tx_mapa_taller;
                        if (strMapaTaller != "") {
                                var codTaller = fn_GetValue_Taller(objTalleres[0].value);
                                $("#btnMapaTallerPR").attr("onclick", "javascript:fn_MostrarPromocion(" + codTaller + ");");
                        }
                        else {
                                var codTaller = fn_GetValue_Taller(objTalleres[0].value);
                                $("#btnMapaTallerPR").attr("onclick", "javascript:fn_MostrarPromocion(" + codTaller + ");");
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

                fn_GetHorarioDisponibleTaller(fl_ver_horario);
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

                objTalleres = $.grep(oComboTaller, function (e) { return (e.nid_taller == this.oCita.nid_taller); });
                if (objTalleres[0].fl_taxi == "1") { $("#divValeTaxi").show(); }
                else { $("#divValeTaxi").hide(); }
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
        function fn_Limpiar_Paso1() {
            oComboProvincia = [];
            oComboDistrito = [];
            $("#cboMarca").prop("selectedIndex", 0).prop("disabled", true);
            $("#cboModelo").prop("selectedIndex", 0).prop("disabled", true);
            $("#cboModelo").trigger("change");
        }
        function fn_Continuar() {
            this.oCita.tx_observacion = $("#txtObservaciones").val();

            if (this.oCita.nu_placa == "" && this.oCita.nu_vin == "") {
                Mensaje("msgPlaca_1"); return false;
            }
            else if (this.oCita.nid_marca <= 0) {
                fc_Alert("Debe seleccionar una Marca."); return false;
            }
            else if (this.oCita.nid_modelo <= 0) {
                fc_Alert("Debe seleccionar un Modelo."); return false;
            }
            else if (this.fc_ExistDisplayControl("div_AnioTipoVeh")) {
                if (this.oCita.nu_anio <= 0) {
                    fc_Alert("<%=Parametros.msgSeleccioneAnio %>"); return false;
                }
                if (this.oCita.co_tipo_veh != "") {
                    fc_Alert("<%=Parametros.msgSeleccioneTipo %>"); return false;
                }
            }
            else if ($("#cboTipoServicio").val() == "") {
                fc_Alert("Debe seleccionar un Tipo de Servicio."); return false;
            }
            else if (this.oCita.nid_servicio <= 0) {
                fc_Alert("Debe seleccionar un Servicio."); return false;
            }
            else if (this.oCita.nid_asesor <= 0) {
                fc_Alert("<%=Parametros.msgSelFec %>"); return false;
            }
            else if (this.oCita.ho_inicio == "") {
                fc_Alert("<%=Parametros.msgSelFec %>"); return false;
            }
            else {
                $("body").scrollTop(0);
                $("#divPage_Paso1").hide();
                $("#divPage_Paso2").fadeIn();
            }
        }
        //#endregion
        //#region Tab 2
        $("#cboTipoDocumento").change(function () {
            setMaxLenthNroDocumento();
            $("#txtNroDocumento").val("");
            setDatosCliente(null);
        });
        function setMaxLenthNroDocumento() {
            var codTipo = $("#cboTipoDocumento").val();
            var maxLength;
            if (codTipo == oDNI) maxLength = MAX_DNI;
            else if (codTipo == oRUC) maxLength = MAX_RUC;
            else maxLength = MAX_CE;

            $("#txtNroDocumento").prop("maxlength", maxLength);
        }
        function setDatosCliente(objCliente) {
            if (objCliente == null) {
                this.oCita.nid_cliente = 0;
                this.oCita.co_tipo_documento = "";
                this.oCita.nu_documento = "";
                this.oCita.no_cliente = "";
                this.oCita.ape_paterno = "";
                this.oCita.ape_materno = "";
                this.oCita.no_correo_personal = "";
                this.oCita.no_correo_trabajo = "";
                this.oCita.no_correo_alternativo = "";
                this.oCita.nu_telefono_cod = "";
                this.oCita.nu_telefono = "";
                this.oCita.nu_celular_cod = "";
                this.oCita.nu_celular = "";
            }
            else {
                this.oCita.nid_cliente = objCliente.nid_cliente;
                this.oCita.co_tipo_documento = objCliente.co_tipo_documento;
                this.oCita.nu_documento = objCliente.nu_documento;
                this.oCita.no_cliente = objCliente.no_nombre;
                this.oCita.ape_paterno = objCliente.no_ape_paterno;
                this.oCita.ape_materno = objCliente.no_ape_materno;
                this.oCita.no_correo_personal = objCliente.no_email;
                this.oCita.no_correo_trabajo = objCliente.no_email_trabajo;
                this.oCita.no_correo_alternativo = objCliente.no_email_alter;
                this.oCita.nu_telefono_cod = objCliente.co_tel_fijo;
                this.oCita.nu_telefono = objCliente.nu_tel_fijo;
                this.oCita.nu_celular_cod = objCliente.co_tel_movil;
                this.oCita.nu_celular = objCliente.nu_tel_movil;
            }

            //Set datos control
            $("#lblTextoDatosContacto").text(objCliente == null ? "Verifique sus datos a continuación y actualícelos si es necesario" : objCliente.msgTextoVerificacion);

            if (this.oCita.nid_cliente > 0) {
                $("#cboTipoDocumento").val(this.oCita.co_tipo_documento);
                $("#txtNroDocumento").val(this.oCita.nu_documento);
            }
            $("#txtNombres").val(this.oCita.no_cliente);
            $("#txtApePaterno").val(this.oCita.ape_paterno);
            $("#txtApeMaterno").val(this.oCita.ape_materno);
            $("#txtEmailPersonal").val(this.oCita.no_correo_personal);
            $("#txtEmailTrabajo").val(this.oCita.no_correo_trabajo);
            $("#txtEmailAternativo").val(this.oCita.no_correo_alternativo);
            if (this.fc_ExistDisplayControl("txtCodTelefono")) {
                $("#txtCodTelefono").val(this.oCita.nu_telefono_cod);
                $("#txtNroTelefono").val(this.oCita.nu_telefono);
            }
            else {
                $("#txtNroTelefono").val((this.oCita.nu_telefono_cod == "" ? "" : (this.oCita.nu_telefono_cod + "-")) + "" + this.oCita.nu_telefono);
            }
            this.oCita.nu_celular_cod = "";
            $("#txtNroCelular").val(this.oCita.nu_celular);

            $("#chkValeTaxi").prop("checked", false);
        }
        function fn_VerificarDoc() {
            $("#txtTelMovilCli").prop("maxlength", parseInt("<%=Parametros.N_MaxLongitudTelfMovil %>"));
            if (!fn_ValidarDocumento()) return false;

            var codDoc = "01"; //por defecto
            if (this.fc_ExistDisplayControl("cboTipoDocumento"))
                codDoc = $("#cboTipoDocumento").val();
            var parametros = new Array();
            parametros[0] = codDoc;
            parametros[1] = $("#txtNroDocumento").val();
            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
            var strUrlServicio = no_pagina + "/Get_VerificarDoc";
            this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                this.setDatosCliente(objResponse);
                if (objResponse.msgNoEncontro == "1") {
                    fc_Alert("<%=Parametros.msgNoExisteDoc %>");
                }
                else if (objResponse.msgNoEncontro == "2") {
                    fc_Alert("<%=Parametros.msgNoExisteRUC %>");
                }
                else if (objResponse.msgNoEncontro == "3") {
                    fc_Alert("<%=Parametros.msgNoExisteCE %>");
                }
            });
        }
        function fn_ValidarDocumento() {
            var nu_documento = $("#txtNroDocumento").val();
            var ddlTipoDoc = "01"; //por defecto
            if (this.fc_ExistDisplayControl("cboTipoDocumento"))
                ddlTipoDoc = $("#cboTipoDocumento").val();

            if (this.fc_ExistDisplayControl("cboTipoDocumento") == false) {
                    if (!fc_ValidarDNI(nu_documento)) { //  DNI -> PERU
                        fc_Alert("Número DNI incorrecto.");
                        return false;
                    }
                
            }
            else if (ddlTipoDoc == '01')  // [ DNI - RUT ]
            {
                    if (!fc_ValidarDNI(nu_documento)) {
                        fc_Alert("Número DNI incorrecto.");
                        return false;
                    }
                
            }
            else if (ddlTipoDoc == '03')  // [RUC]
            {
                if (!fc_ValidarRUC(nu_documento)) {
                    fc_Alert("Número RUC incorrecto.");
                    return false;
                }
            }
            else if (ddlTipoDoc == '04')  // [CE]
            {
                if (!fc_ValidarCE(nu_documento)) {
                    fc_Alert("Número CE incorrecto.");
                    return false;
                }
            }
            return true;
        }
        function fn_Reservar() {
            this.oCita.co_tipo_documento = $("#cboTipoDocumento").val();
            this.oCita.nu_documento = fc_Trim($("#txtNroDocumento").val());
            this.oCita.no_cliente = fc_Trim($("#txtNombres").val());
            this.oCita.ape_paterno = fc_Trim($("#txtApePaterno").val());
            this.oCita.ape_materno = fc_Trim($("#txtApeMaterno").val());
            this.oCita.no_correo_personal = fc_Trim($("#txtEmailPersonal").val());
            this.oCita.no_correo_trabajo = fc_Trim($("#txtEmailTrabajo").val());
            this.oCita.no_correo_alternativo = fc_Trim($("#txtEmailAternativo").val());
            this.oCita.nu_telefono_cod = $("#txtCodTelefono").val();
            this.oCita.nu_telefono = $("#txtNroTelefono").val();
            this.oCita.nu_celular = $("#txtNroCelular").val();
            this.oCita.fl_recibir_info = ($("#ind_acepto").prop("checked") == true ? "1" : "0");
            this.oCita.fl_taxi = ($("#chkValeTaxi").prop("checked") == true ? "1" : "0");
            this.oCita.co_origen = MP_Origen;

            if (this.fn_ValidarDatosReservaCliente()) {
                var strParametros = "{'strParametros':" + JSON.stringify(this.oCita) + "}";
                var strUrlServicio = no_pagina + "/SaveReserva";
                this.fc_CallService(strParametros, strUrlServicio, function (objResponse) {
                    if (objResponse.fl_seguir == "1") {
                        var qs_marca = "";
                        if (this.MP_co_marca_permitida > 0) { qs_marca = "?co_marca=" + this.MP_co_marca_permitida; }
                        var UrlResumenCita = "SRC_ResumenCita.aspx" + qs_marca;
                        var form = $('<form action="' + UrlResumenCita + '" method="post" target="_self">' +
                        '<input type="hidden" name="nid_cita" value="' + objResponse.oDatosCita.nid_cita + '" />' +
                        '</form>');
                        $("body").append(form);
                        form.submit();
                    }
                    if (objResponse.msg_retorno != "") { fc_Alert(objResponse.msg_retorno); }
                });
            }
        }
        function fn_ValidarDatosReservaCliente() {
            if (!fn_ValidarDocumento()) return false;
            if (fc_Trim(this.oCita.no_cliente) == "") {
                Mensaje("msgNombres_1"); return false;
            }
            if (fc_Trim(this.oCita.ape_paterno) == "") {
                Mensaje("msgNoApePat_1"); return false;
            }
            if (fc_Trim(this.oCita.ape_materno) == "") {
                Mensaje("msgNoApeMat_1"); return false;
            }
            //Emails
            if (fc_Trim(this.oCita.no_correo_personal) != "") {
                if (!fc_ValidarEmail(this.oCita.no_correo_personal)) { fc_Alert("Ingrese una dirección de e-mail válido."); return false; }
            }
            if (this.fc_ExistDisplayControl("divEmailTrab") && fc_Trim(this.oCita.no_correo_trabajo) != "") {
                if (!fc_ValidarEmail(this.oCita.no_correo_trabajo)) { fc_Alert("Ingrese una dirección de e-mail válido."); return false; }
            }
            if (this.fc_ExistDisplayControl("divEmailAlter") && fc_Trim(this.oCita.no_correo_alternativo) != "") {
                if (!fc_ValidarEmail(this.oCita.no_correo_alternativo)) { fc_Alert("Ingrese una dirección de e-mail válido."); return false; }
            }

            if (fc_Trim(this.oCita.no_correo_personal) == "" && fc_Trim(this.oCita.no_correo_trabajo) == "") {
                fc_Alert("Debe ingresar al menos uno de los 2 e-mails."); return false;
            }


            if (fc_Trim(this.oCita.nu_telefono_cod) == "" && fc_Trim(this.oCita.nu_telefono) == "" && fc_Trim(this.oCita.nu_celular) == "") {
                Mensaje("msgNoNumFijoMovil_1"); return false;
            }
            if (fc_Trim(this.oCita.nu_telefono_cod) == "" && fc_Trim(this.oCita.nu_telefono) != "") {
                Mensaje("msgNoCodTelfFijo_1"); return false;
            }
            if (fc_Trim(this.oCita.nu_telefono) == "" && fc_Trim(this.oCita.nu_telefono_cod) != "") {
                Mensaje("msgNoNumTelfFijo_1"); return false;
            }


            return true;
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
        //#endregion
        function Mensaje(msg) {
            fc_Alert(ReadConfigSettings(msg));
        }
        function ReadConfigSettings(key) {
            var srtSMS = "";
            switch (key) {
                case "codPais": srtSMS = '<%=ConfigurationManager.AppSettings["CodPais"].ToString() %>'; break;
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
                case "msgNoCodTelfMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfMovil_1"].ToString() %>'; break;
                case "msgNoCodTelfMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoCodTelfMovil_2"].ToString() %>'; break;
                case "msgNoNumTelfMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfMovil_1"].ToString() %>'; break;
                case "msgNoNumTelfMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumTelfMovil_2"].ToString() %>'; break;
                case "msgNoNumFijoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_1"].ToString() %>'; break;
                case "msgNoNumFijoMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_2"].ToString() %>'; break;
                case "msgNoNumFijoMovil_1": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_1"].ToString() %>'; break;
                case "msgNoNumFijoMovil_2": srtSMS = '<%=ConfigurationManager.AppSettings["msgNoNumFijoMovil_2"].ToString() %>'; break;
            }
            return srtSMS;
        }
        function getParentQueryStringValue(key) {
            if (document.referrer != "") return unescape(document.referrer.replace(new RegExp("^(?:.*[&\\?]" + escape(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
            else return "";
        }
        function fn_OpenContacto() {
            $.magnificPopup.open({
                items: {
                    src: '#popup_ContactoCallCenter',
                    type: 'inline'
                }
                , removalDelay: 500,
                mainClass: "mfp-zoom-in",
                midClick: true
            });
        }
    </script>
</asp:Content>
