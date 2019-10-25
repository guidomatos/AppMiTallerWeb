<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SRC_ActualizarCliente.aspx.cs" Inherits="SRC_ActualizarCliente" Async="true" %>

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
    
    <div>
        <div class="titulo_section">Datos del Cliente</div>
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
            <div class="col l12 x12">
                <button id="btnActualizarCliente">Actualizar</button>
                <button id="btnLimpiarDatos">Limpiar Datos</button>
            </div>
        </div>
    </div>
    
    <div id="divProgress_aux" class="Progress">
        <img alt="...Cargando..." src="img/loading.gif" style="position: absolute; left: 48%;
            top: 48%; vertical-align: middle;" />
    </div>
    
    <script type="text/javascript">
        var cliente;

        $(document).ready(function () {

            var main;

            const no_pagina = "SRC_ActualizarCliente.aspx";

            main = function () {
                var me = this;

                me.Globales = {
                    BtnActualizarCliente: '#btnActualizarCliente',
                    BtnLimpiarDatos: '#btnLimpiarDatos'
                },
                    me.Funciones = {

                        //funciones a usar dentro de la pagina
                        InicializarEventos: function () {
                            $(document).on("click", me.Globales.BtnActualizarCliente, me.Eventos.ActualizarCliente);
                            $(document).on("click", me.Globales.BtnLimpiarDatos, me.Eventos.LimpiarDatos);
                        },
                        InicializarAcciones: function () {

                            

                        },
                        ValidarDatosCliente: function () {

                            var msgValidacion = '';
                            var ddlTipoDoc = $("#cboTipoDocumento").val();
                            var nu_documento = $.trim($("#txtNroDocumento").val());
                            var nombres = $.trim($("#txtNombres").val());
                            var ape_paterno = $.trim($("#txtApePaterno").val());
                            var ape_materno = $.trim($("#txtApeMaterno").val());
                            var email = $.trim($("#txtEmailPersonal").val());
                            var celular = $.trim($("#txtNroCelular").val());

                            if (ddlTipoDoc == '') {
                                msgValidacion += 'Seleccione Tipo de Documento';
                            }

                            if (ddlTipoDoc == '01')  // DNI
                            {
                                if (!fc_ValidarDNI(nu_documento)) {
                                    msgValidacion += 'Número DNI incorrecto\n';
                                }
                            }
                            else if (ddlTipoDoc == '03')  // [RUC]
                            {
                                if (!fc_ValidarRUC(nu_documento)) {
                                    msgValidacion += 'Número RUC incorrecto\n';
                                }
                            }
                            else if (ddlTipoDoc == '04')  // [CE]
                            {
                                if (!fc_ValidarCE(nu_documento)) {
                                    msgValidacion += 'Número CE incorrecto\n';
                                }
                            }

                            if (nombres == "") { msgValidacion += 'Ingrese Nombre\n'; }
                            if (ape_paterno == "") { msgValidacion += 'Ingrese Apellido Paterno\n'; }
                            if (ape_materno == "") { msgValidacion += 'Ingrese Apellido Materno\n'; }

                            if (email != "") {
                                if (!fc_ValidarEmail(email)) {
                                    msgValidacion += 'Ingrese una dirección de e-mail válido\n';
                                }
                            } else {
                                msgValidacion += 'Ingrese una dirección de e-mail\n';
                            }



                            if (msgValidacion != '') {
                                fc_Alert(msgValidacion);
                                return false;
                            }

                        }
                    },
                    me.Eventos = {
                        //eventos de los elementos html (input, button, radiobutton, checkbutton)

                        ActualizarCliente: function () {

                            me.Funciones.ValidarDatosCliente();

                            return false;

                        },
                        LimpiarDatos: function () {

                        }
                    },
                    me.Inicializar = function () {
                        //funciones a usar ni bien se cargue la pagina
                        me.Funciones.InicializarEventos();
                        me.Funciones.InicializarAcciones();
                    }

            }

            cliente = new main();
            cliente.Inicializar();

        });
    </script>
    
</asp:Content>
