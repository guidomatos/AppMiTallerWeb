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
        <div class="titulo_section">Detalle del Cliente</div>
        <div class="row" style="display:none;">
            <div class="col l3 s5 x12">
                <span class="texto">Tipo persona:</span>
            </div>
            <div class="col l9 s7 x12">
                <select id="cboTipoPersona">
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">
                    <%=Parametros.N_TipoDocumento %>:</span>
            </div>
            <div class="col l4 s7 x12">
                <select id="cboTipoDocumento">
                </select>
                <input id="txtNroDocumento" type="text" maxlength="10" onpaste="return false;"/>
            </div>
            <div class="col l5 x12">
                <button id="btnConsultarCliente" style="display:none">Consultar</button>
            </div>
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
                <span class="texto">Celular:</span>
            </div>
            <div class="col l9 s7 x12">
                <input id="txtNroCelular" type="text" style="width: 150px;" maxlength="9" onpaste="return false;"/>
            </div>
        </div>
        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">E-mail:</span>
            </div>
            <div class="col l9 s7 x12">
                <input id="txtEmailPersonal" type="text" style="width: 150px;" />
            </div>
        </div>
        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">Direcci&oacute;n:</span>
            </div>
            <div class="col l9 s7 x12">
                <input id="txtDireccion" type="text" style="width: 300px;" />
            </div>
        </div>

        <div class="titulo_section">Detalle del Veh&iacute;culo</div>

        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">Nro. Placa:</span>
            </div>
            <div class="col l9 s7 x12">
                <input id="txtNroPlaca" type="text" style="width: 150px;" maxlength="6"/>
            </div>
        </div>
        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">Marca:</span>
            </div>
            <div class="col l9 s7 x12">
                <select id="cboMarca">
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col l3 s5 x12">
                <span class="texto">Modelo:</span>
            </div>
            <div class="col l9 s7 x12">
                <select id="cboModelo">
                </select>
            </div>
        </div>
        <div class="row">
            <div class="col l12 x12">
                <button id="btnActualizarCliente">Registrar Ahora</button>
                <button id="btnLimpiarDatos">Limpiar Datos</button>
                <button id="btnCancelar">Cancelar</button>
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
            const TEXTO_SELECCIONE = "<%=Parametros.OBJECTO_SELECCIONE %>";
            const oDNI = '<%=ConfigurationManager.AppSettings["DNI"].ToString() %>';
            const oRUC = '<%=ConfigurationManager.AppSettings["RUC"].ToString() %>';
            const MAX_DNI = 8;
            const MAX_RUC = 11;
            const MAX_CE = 11;

            var id_cliente = 0;

            main = function () {
                var me = this;

                me.Globales = {
                    BtnConsultarCliente: '#btnConsultarCliente',
                    BtnActualizarCliente: '#btnActualizarCliente',
                    BtnLimpiarDatos: '#btnLimpiarDatos',
                    BtnCancelar: '#btnCancelar',
                    CboTipoDocumento: '#cboTipoDocumento',
                    TxtNroDocumento: '#txtNroDocumento',
                    TxtNroCelular: '#txtNroCelular',
                    CboMarca: '#cboMarca',
                    CboModelo: '#cboModelo'
                },
                    me.Funciones = {

                        //funciones a usar dentro de la pagina
                        InicializarEventos: function () {
                            $(document).on("click", me.Globales.BtnActualizarCliente, me.Eventos.ActualizarCliente);
                            $(document).on("click", me.Globales.BtnLimpiarDatos, me.Eventos.LimpiarDatos);
                            $(document).on("click", me.Globales.BtnCancelar, me.Eventos.Cancelar);
                            $(document).on("change", me.Globales.CboTipoDocumento, me.Eventos.SeleccionarTipoDocumento);
                            //$(document).on("blur", me.Globales.TxtNroDocumento, me.Eventos.ConsultarClientePorDocumento);
                            $(document).on("click", me.Globales.BtnConsultarCliente, me.Eventos.ConsultarClientePorDocumento);
                            $(document).on("keypress", me.Globales.TxtNroCelular, me.Eventos.ValidarIngresoCelular);
                            $(document).on("keypress", me.Globales.TxtNroDocumento, me.Eventos.ValidarIngresoDocumento);
                            $(document).on("change", me.Globales.CboMarca, me.Eventos.SeleccionarMarca);
                        },
                        InicializarAcciones: function () {

                            me.Funciones.CargarControles();
                            me.Funciones.CargarDatosClienteLogin();

                        },
                        ValidarNumeroDocumento: function () {

                            var msgValidacion = '';
                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            var nu_documento = $.trim($(me.Globales.TxtNroDocumento).val());

                            if (nu_documento == '') {
                                msgValidacion += 'Ingrese Nro. Documento\n';
                            } else {
                                if (co_tipo_documento == '01')  // DNI
                                {
                                    if (!fc_ValidarDNI(nu_documento)) {
                                        msgValidacion += 'Número DNI incorrecto\n';
                                    }
                                }
                                else if (co_tipo_documento == '03')  // [RUC]
                                {
                                    if (!fc_ValidarRUC(nu_documento)) {
                                        msgValidacion += 'Número RUC incorrecto\n';
                                    }
                                }
                                else if (co_tipo_documento == '04')  // [Pasaporte]
                                {
                                    if (!fc_ValidarCE(nu_documento)) {
                                        msgValidacion += 'Número CE incorrecto\n';
                                    }
                                }
                            }

                            return msgValidacion;

                        },
                        ValidarDatosCliente: function () {

                            var msgValidacion = '';

                            //var co_tipo_persona = $('#cboTipoPersona').val();
                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            var nu_documento = $.trim($(me.Globales.TxtNroDocumento).val());
                            var nombres = $.trim($("#txtNombres").val());
                            var ape_paterno = $.trim($("#txtApePaterno").val());
                            var ape_materno = $.trim($("#txtApeMaterno").val());
                            var celular = $.trim($(me.Globales.TxtNroCelular).val());
                            var email = $.trim($("#txtEmailPersonal").val());

                            if (co_tipo_documento == '') {
                                msgValidacion += 'Seleccione Tipo de Documento\n';
                            }

                            if (nu_documento == '') {
                                msgValidacion += 'Ingrese Nro. Documento\n';
                            } else {
                                msgValidacion += me.Funciones.ValidarNumeroDocumento();
                            }

                            if (nombres == "") { msgValidacion += 'Ingrese Nombre\n'; }
                            if (ape_paterno == "") { msgValidacion += 'Ingrese Apellido Paterno\n'; }
                            if (ape_materno == "") { msgValidacion += 'Ingrese Apellido Materno\n'; }

                            if (celular == "") {
                                msgValidacion += 'Ingrese Nro. Celular\n';
                            } else {
                                if (celular.length != 9) {
                                    msgValidacion += 'Ingrese Nro. Celular de 9 d&iacute;gitos\n';
                                }
                            }

                            if (email != "") {
                                if (!fc_ValidarEmail(email)) {
                                    msgValidacion += 'Ingrese E-mail v&aacutelido\n';
                                }
                            } else {
                                msgValidacion += 'Ingrese E-mail\n';
                            }

                            return msgValidacion;

                        },
                        ValidarDatosVehiculo: function () {
                            var msgValidacion = '';

                            var nu_placa = $('#txtNroPlaca').val();
                            var id_marca = $(me.Globales.CboMarca).val();
                            var id_modelo = $(me.Globales.CboModelo).val();

                            if (nu_placa == '') {
                                msgValidacion += 'Ingrese Nro. Placa\n';
                            }

                            if (id_marca == '') {
                                msgValidacion += 'Seleccione Marca\n';
                            }

                            if (id_modelo == '') {
                                msgValidacion += 'Seleccione Modelo\n';
                            }

                            return msgValidacion;
                        },
                        CargarControles: function () {

                            var strFiltros = null;
                            var strUrlServicio = no_pagina + "/Get_Inicial";
                            fc_CallService(strFiltros, strUrlServicio, function (objResponse) {

                                fc_FillCombo("cboTipoPersona", objResponse.oComboTipoPersona, TEXTO_SELECCIONE);
                                fc_FillCombo("cboTipoDocumento", objResponse.oComboTipoDocumento, TEXTO_SELECCIONE);
                                $(me.Globales.CboTipoDocumento + " option[value='']").remove();
                                me.Funciones.setMaxLenthNroDocumento();

                                fc_FillCombo("cboMarca", objResponse.oComboMarca, TEXTO_SELECCIONE);
                                if (objResponse.oComboMarca.length == 1) {
                                    $("#cboMarca").val(objResponse.oComboMarca[0].value);
                                }
                            });

                            $(me.Globales.CboModelo).append("<option value=''>" + TEXTO_SELECCIONE + "</option>");

                        },
                        setMaxLenthNroDocumento: function () {

                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            var maxLength;
                            if (co_tipo_documento == oDNI) maxLength = MAX_DNI;
                            else if (co_tipo_documento == oRUC) maxLength = MAX_RUC;
                            else maxLength = MAX_CE;

                            $(me.Globales.TxtNroDocumento).prop("maxlength", maxLength);

                        },
                        setDatosCliente: function (objCliente) {

                            var nid_cliente = 0;
                            var co_tipo_documento = "";
                            var nu_documento = "";
                            var no_cliente = "";
                            var ape_paterno = "";
                            var ape_materno = "";
                            var nu_celular = "";
                            var no_correo_personal = "";
                            var tx_direccion = "";

                            var nid_vehiculo = 0;
                            var nu_placa = "";
                            var nid_marca = 0;
                            var nid_modelo = 0;

                            if (objCliente != null) {
                                nid_cliente = objCliente.nid_cliente;
                                co_tipo_documento = objCliente.co_tipo_documento;
                                nu_documento = objCliente.nu_documento;
                                no_cliente = objCliente.no_nombre;
                                ape_paterno = objCliente.no_ape_paterno;
                                ape_materno = objCliente.no_ape_materno;
                                nu_celular = objCliente.nu_tel_movil;
                                no_correo_personal = objCliente.no_email;
                                tx_direccion = objCliente.tx_direccion;
                                nid_vehiculo = objCliente.nid_vehiculo;
                                nu_placa = objCliente.nu_placa;
                                nid_marca = objCliente.nid_marca;
                                nid_modelo = objCliente.nid_modelo;
                            }

                            if (nid_cliente > 0) {

                                co_tipo_documento = $.trim(co_tipo_documento);

                                $(me.Globales.CboTipoDocumento).val(co_tipo_documento);
                                $(me.Globales.TxtNroDocumento).val(nu_documento);
                            }

                            $("#txtNombres").val(no_cliente);
                            $("#txtApePaterno").val(ape_paterno);
                            $("#txtApeMaterno").val(ape_materno);
                            $(me.Globales.TxtNroCelular).val(nu_celular);
                            $("#txtEmailPersonal").val(no_correo_personal);
                            $("#txtDireccion").val(tx_direccion);

                            $('#txtNroPlaca').val(nu_placa);
                            $(me.Globales.CboMarca).val(nid_marca);
                            $(me.Globales.CboMarca).trigger('change');
                            $(me.Globales.CboModelo).val(nid_modelo);
                            console.log(nid_marca);
                            console.log(nid_modelo);

                            return false;

                        },
                        CargarDatosClienteLogin: function () {
                            if (sessionStorage.getItem('loginId')) {
                                id_cliente = JSON.parse(sessionStorage.getItem("loginId"));
                            }

                            if (id_cliente != 0) {

                                var parametros = new Array();
                                parametros[0] = id_cliente;
                                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                                var strUrlServicio = no_pagina + "/Get_ConsultarClientePorId";

                                fc_CallService(strParametros, strUrlServicio, function (objResponse) {

                                    me.Funciones.setDatosCliente(objResponse);

                                    $(me.Globales.CboTipoDocumento).prop("disabled", true);
                                    $(me.Globales.TxtNroDocumento).prop("disabled", true);

                                });

                            }

                        }
                    },
                    me.Eventos = {
                        //eventos de los elementos html (input, button, radiobutton, checkbutton)

                        SeleccionarTipoDocumento: function (event) {

                            me.Funciones.setMaxLenthNroDocumento();
                            $(me.Globales.TxtNroDocumento).val("");
                            //me.Funciones.setDatosCliente(null);

                        },
                        ConsultarClientePorDocumento: function (event) {

                            $(me.Globales.TxtNroCelular).prop("maxlength", parseInt("<%=Parametros.N_MaxLongitudTelfMovil %>"));

                            var msgValidacionDocumento = me.Funciones.ValidarNumeroDocumento();

                            if (msgValidacionDocumento != '') {
                                fc_Alert(msgValidacionDocumento);
                                return false;
                            }

                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            var parametros = new Array();
                            parametros[0] = co_tipo_documento;
                            parametros[1] = $.trim($(me.Globales.TxtNroDocumento).val());
                            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                            var strUrlServicio = no_pagina + "/Get_ConsultarClientePorDocumento";

                            fc_CallService(strParametros, strUrlServicio, function (objResponse) {

                                me.Funciones.setDatosCliente(objResponse);
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

                        },
                        ActualizarCliente: function (event) {

                            var msgValidacion = '';
                            msgValidacion += me.Funciones.ValidarDatosCliente();
                            msgValidacion += me.Funciones.ValidarDatosVehiculo();

                            if (msgValidacion != '') {
                                fc_Alert(msgValidacion);
                                return false;
                            }

                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            var nu_documento = $.trim($(me.Globales.TxtNroDocumento).val());
                            var nombres = $.trim($("#txtNombres").val());
                            var ape_paterno = $.trim($("#txtApePaterno").val());
                            var ape_materno = $.trim($("#txtApeMaterno").val());
                            var celular = $.trim($(me.Globales.TxtNroCelular).val());
                            var email = $.trim($("#txtEmailPersonal").val());
                            var direccion = $.trim($("#txtDireccion").val());
                            var nu_placa = $.trim($("#txtNroPlaca").val());
                            var id_marca = $(me.Globales.CboMarca).val();
                            var id_modelo = $(me.Globales.CboModelo).val();
                            var no_clave_web = "";

                            var parametros = new Array();
                            parametros[0] = co_tipo_documento;
                            parametros[1] = id_cliente;
                            parametros[2] = nu_documento;
                            parametros[3] = nombres;
                            parametros[4] = ape_paterno;
                            parametros[5] = ape_materno;
                            parametros[6] = celular;
                            parametros[7] = email;
                            parametros[8] = direccion;
                            parametros[9] = nu_placa;
                            parametros[10] = id_marca;
                            parametros[11] = id_modelo;
                            parametros[12] = no_clave_web;

                            var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                            var strUrlServicio = no_pagina + "/ActualizarClienteWeb";
                            fc_CallService(strParametros, strUrlServicio, function (objResponse) {

                                console.log(objResponse);

                                if (objResponse.resultado > 0) {
                                    fc_Alert('Se registró su acceso correctamente. Verifique su correo con los datos de acceso');

                                    setTimeout(function () {
                                        location.href = 'SRC_Home.aspx';
                                    }, 2000);
                                    
                                } else {
                                    if (objResponse.resultado == -5) {
                                        fc_Alert('No se puede actualizar. Nro. Documento ya existe');
                                    } else if (objResponse.resultado == -6) {
                                        fc_Alert('No se puede actualizar. Cliente no es propietario del vehículo');
                                    } else {
                                        fc_Alert('No se puede actualizar. Consulte con administrador');
                                    }
                                }

                            });

                            return false;

                        },
                        LimpiarDatos: function (event) {
                            $(me.Globales.CboTipoDocumento).val('01');
                            $(me.Globales.TxtNroDocumento).val('');
                            $("#txtNombres").val('');
                            $("#txtApePaterno").val('');
                            $("#txtApeMaterno").val('');
                            $(me.Globales.TxtNroCelular).val('');
                            $("#txtEmailPersonal").val('');

                            $(me.Globales.CboMarca).val('');
                            $(me.Globales.CboMarca).trigger('change');
                            return false;
                        },
                        Cancelar: function (event) {
                            location.href = 'SRC_Home.aspx';
                            return false;
                        },
                        ValidarIngresoCelular: function (event) {

                            return fc_SoloNumeros(event);

                        },
                        ValidarIngresoDocumento: function (event) {

                            var co_tipo_documento = $(me.Globales.CboTipoDocumento).val();
                            if (co_tipo_documento == '01')  // DNI
                            {
                                return fc_SoloNumeros(event);
                            }
                            else if (co_tipo_documento == '03')  // [RUC]
                            {
                                return fc_SoloNumeros(event);
                            }
                            else if (co_tipo_documento == '04')  // [Pasaporte]
                            {
                                return true;
                            }
                            
                        },
                        SeleccionarMarca: function (event) {
                            var id_marca = $(me.Globales.CboMarca).val();

                            if (id_marca != '') {
                                var parametros = new Array();
                                parametros[0] = id_marca;
                                var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                                var strUrlServicio = no_pagina + "/Get_Modelo";

                                fc_CallService(strParametros, strUrlServicio, function (objResponse) {

                                    fc_FillCombo("cboModelo", objResponse.oComboModelo, TEXTO_SELECCIONE);

                                });
                            } else {
                                $(me.Globales.CboModelo).html('');
                                $(me.Globales.CboModelo).append("<option value=''>" + TEXTO_SELECCIONE + "</option>");
                            }

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
