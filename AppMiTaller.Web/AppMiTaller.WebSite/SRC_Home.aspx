<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SRC_Home.aspx.cs" Inherits="SRC_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="bienvenido_home">
            <div>
                <h1 id="msgBienvenida">Acceder al Sistema</h1>
            </div>

            <div id="divLogin">
                <div class="row">
                    <div class="col l2 s5 x12">
                        <span class="texto">Usuario:</span>
                    </div>
                    <div class="col l10 s7 x12">
                        <input id="txtUsuario" type="text" style="width:95px;" maxlength="20" autocomplete="off" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l2 s5 x12">
                        <span class="texto">Contraseña:</span>
                    </div>
                    <div class="col l10 s7 x12">
                        <input id="txtClave" type="password" size="10" maxlength="20" />
                    </div>
                </div>
                <div class="row">
                    <div class="col l2 s5 x12">
                        <button id="btnIngresar" class="ui-button ui-corner-all ui-widget waves-effect">Ingresar</button>
                    </div>
                    <div class="col l10 s7 x12">
                        <button id="btnRegistrarUsuario" class="ui-button ui-corner-all ui-widget waves-effect">Reg&iacute;strate</button>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        var home;

        $(document).ready(function () {

            var main;

            const no_pagina = "SRC_Home.aspx";

            main = function () {
                var me = this;

                me.Globales = {
                    BtnIngresar: '#btnIngresar',
                    BtnRegistrarUsuario: '#btnRegistrarUsuario'
                },
                me.Funciones = {

                    //funciones a usar dentro de la pagina
                    InicializarEventos: function () {
                        $(document).on("click", me.Globales.BtnIngresar, me.Eventos.Login);
                        $(document).on("click", me.Globales.BtnRegistrarUsuario, me.Eventos.RegistrarUsuario);
                    },
                    InicializarAcciones: function () {

                        //Guardar Login de Usuario
                        var id_usuario;
                        if (sessionStorage.getItem('loginId')) {
                            id_usuario = JSON.parse(sessionStorage.getItem("loginId"));

                            $('#divLogin').css('display', 'none');
                            $('#msgBienvenida').html('Bienvenido al Sistema');
                        } else {
                            $('#divLogin').css('display', 'block');
                            $('#msgBienvenida').html('Acceder al Sistema');
                        }

                    }

                },
                me.Eventos = {
                    //eventos de los elementos html (input, button, radiobutton, checkbutton)

                    Login: function () {

                        var msgValidacion = '';
                        var usuario = $.trim($('#txtUsuario').val());
                        var clave = $.trim($('#txtClave').val());

                        if (usuario == '') {
                            msgValidacion += '\n- Ingrese Usuario';
                        }

                        if (clave == '') {
                            msgValidacion += '\n- Ingrese Contraseña';
                        }

                        if (msgValidacion != '') {
                            fc_Alert(msgValidacion);
                            return false;
                        }


                        var parametros = new Array();
                        parametros[0] = usuario;
                        parametros[1] = clave;
                        var strParametros = "{'strParametros':" + JSON.stringify(parametros) + "}";
                        var strUrlServicio = no_pagina + "/Login";

                        fc_CallService(strParametros, strUrlServicio, function (objResponse) {

                            if (objResponse.co_retorno > 0) {

                                //Guardar Login de Usuario
                                var id_usuario;
                                if (sessionStorage.getItem('loginId')) {
                                    id_usuario = JSON.parse(sessionStorage.getItem("loginId"));
                                } else {
                                    sessionStorage.setItem("loginId", JSON.stringify(objResponse.co_retorno));
                                }

                                var pgurl = window.location.href.replace("#", "");
                                location.href = pgurl;

                            } else {

                                fc_Alert(objResponse.msg_retorno);

                            }

                        });

                        return false;

                    },
                    RegistrarUsuario: function () {

                        
                        location.href = "SRC_ActualizarCliente.aspx";

                        return false;

                    }
                },
                me.Inicializar = function () {
                    //funciones a usar ni bien se cargue la pagina
                    me.Funciones.InicializarEventos();
                    me.Funciones.InicializarAcciones();
                }

            }

            home = new main();
            home.Inicializar();

        });
    </script>
</asp:Content>