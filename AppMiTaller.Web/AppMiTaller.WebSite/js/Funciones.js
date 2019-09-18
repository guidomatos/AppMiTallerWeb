function fc_ExistDisplayControl(Id_control) {
    if (Id_control.indexOf("#") >= 0) Id_control = Id_control.replace("#", "");

    if (document.getElementById(Id_control) != null && $("#" + Id_control).is(':visible')) {
        return true;
    }
    else return false;
}

//Las funciones retornan => True: Formato Correcto | False: Formato Incorrecto
//#region - Funciones de Validación
function fc_ValidarRUT(nu_rut) {
    var tmpstr = "";
    if (nu_rut.length > 0) {
        crut = nu_rut;
        largo = crut.length;
        if (largo < 7) {
            //alert('El RUT ingresado es inválido.');
            return false;
        }
        for (i = 0; i < crut.length; i++) {
            if (crut.charAt(i) != ' ' && crut.charAt(i) != '.' && crut.charAt(i) != '-')
                tmpstr = tmpstr + crut.charAt(i);
        }
        rut = tmpstr;
        crut = tmpstr;
        largo = crut.length;
        rut = largo > 2 ? crut.substring(0, largo - 1) : crut.charAt(0);
        dv = crut.charAt(largo - 1);
        if (rut == null || dv == null) return 0;
        var dvr = '0';
        suma = 0;
        mul = 2;
        for (i = rut.length - 1; i >= 0; i--) {
            suma = suma + rut.charAt(i) * mul;
            if (mul == 7) mul = 2;
            else mul++;
        }
        res = suma % 11;
        if (res == 1) dvr = 'k';
        else if (res == 0) dvr = '0';
        else {
            dvi = 11 - res;
            dvr = dvi + "";
        }
        if (dvr != dv.toLowerCase()) {
            //alert('El RUT Ingresado es inválido.')
            return false;
        }
        return true;
    }
    else {
        //alert('Ingrese el número de RUT.')
        return false;
    }
}
function fc_ValidarRUC(nu_ruc) {
    if (nu_ruc.length == 11) return true;
    else return false; //alert("Ingrese 11 dìgitos para el número de RUC");
}
function fc_ValidarDNI(nu_dni) {
    if (nu_dni.length == 8) return true;
    else return false; //alert("Ingrese 8 dìgitos para el número de DNI");
}
function fc_ValidarCE(nu_CE) {
    if (nu_CE.length > 0) return true;
    else return false; // alert("Ingrese un documento CE válido");
}

function fc_ValidarEmail(email) {
    expr = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!expr.test(email))
    //alert("Error: La dirección de correo " + email + " es incorrecta.");
        return false;
    else
        return true;
}
function fc_SoloLetras() {
    var e = window.event ? event.keyCode : event.which;
    if ((e == 32) || (e >= 65 && e <= 90) || (e >= 97 && e <= 122) || (e == 209) || (e == 241)) {
    }
    else {
        event.keyCode = 0;
        alert('Solo se permite ingresar letras');
        return false;
    }
    return true;
}
function fc_SoloNumeros(e) {
    var key;
    if (window.event) // IE
    {
        key = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        key = e.which;
    }
    if (key == 13) return true;

    if (key < 48 || key > 57) {
        e.keyCode = 0;
        alert('Solo se permite ingresar números');
        return false;
    }
    return true;
}
function fc_SoloLetrasNumeros(e) {
    var key = (e.keyCode) ? e.keyCode : ((e.Which) ? e.Which : e.charCode);
    if (key >= 65 && key <= 90) { }
    else if (key >= 97 && key <= 122) { }
    else if (key >= 48 && key <= 57) { }
    else if (key == 193 || key == 201 || key == 205 || key == 211 || key == 218) { } // Á  É  Í  Ó  Ú
    else if (key == 225 || key == 223 || key == 237 || key == 243 || key == 250) { } // á  é  í  ó  ú
    else if (key == 8 || key == 9 || key == 46 || key == 37 || key == 39) { }
    else if (key == 209 || key == 241) { } // ñ Ñ
    else return false;
}
function fc_ValidarFecha(oFecha) /*Pasar el valor de la Fecha*/
{
    /*var pFecIni = oFecha.value;*/
    var pFecIni = oFecha;
    var _FechaMin = 1900;
    var _FechaMax = 2100;
    var vANIO = "";
    var vMES = "";
    var vDIA = "";

    var flError = 0;

    var dFecIni = pFecIni.substr(6, 4) + "" + pFecIni.substr(3, 2) + "" + pFecIni.substr(0, 2);

    if (dFecIni.trim() == "") {
        return false;
    }

    //verificar digitos
    var digits = "1234567890";
    for (var i = 0; i < dFecIni.length; i++) {
        if (digits.indexOf(dFecIni.charAt(i)) == -1) {
            return false;
        }
    }

    vANIO = pFecIni.substr(6, 4).trim();
    vMES = pFecIni.substr(3, 2).trim();
    vDIA = pFecIni.substr(0, 2).trim();


    // VALIDAR DIA
    if (vMES == 1 || vMES == 3 || vMES == 5 || vMES == 7 || vMES == 8 || vMES == 10 || vMES == 12) {
        if (isNaN(vDIA) || parseInt(vDIA, 10) < 1 || parseInt(vDIA, 10) > 31)
        { flError = 1; }
    }
    else if (vMES == 4 || vMES == 6 || vMES == 9 || vMES == 11) {
        if (isNaN(vDIA) || parseInt(vDIA, 10) < 1 || parseInt(vDIA, 10) > 30)
        { flError = 1; }
    }
    else {
        var dia = (((vANIO % 4 == 0) && ((!(vANIO % 100 == 0)) || (vANIO % 400 == 0))) ? 29 : 28);
        if (isNaN(vDIA) || parseInt(vDIA, 10) < 1 || parseInt(vDIA, 10) > dia)
        { flError = 1; }
    }

    if (flError == 1) {
        return false;
    }

    // VALIDAR MES
    if (parseFloat(vMES) > 12) {
        return false;
    }

    // VALIDAR AÑO
    if (parseFloat(vANIO) < _FechaMin || parseFloat(vANIO) > _FechaMax) {
        return false;
    }
    return true;
}
function fc_ValidarRangofechas(oFechaIni, oFechaFin) /*Pasar el valor de la Fecha*/
{
    var dFecIni = oFechaIni.substr(6, 4) + "" + oFechaIni.substr(3, 2) + "" + oFechaIni.substr(0, 2);
    var dFecFin = oFechaFin.substr(6, 4) + "" + oFechaFin.substr(3, 2) + "" + oFechaFin.substr(0, 2);

    /*if (dFecIni >= dFecFin)*/
    if (dFecIni > dFecFin) {
        // alert("La fecha de inicio debe ser menor que la fecha final.");
        return false;
    }
    else
        return true;
}
//#endregion - Funciones de Validación

//#region - Funciones Controles ASP.NET
function fc_ClearGridView(IdGridView, fl_clear_cabecera) {
    if (document.getElementById(IdGridView) != null) {
        if (fl_clear_cabecera == true) $("#" + IdGridView).remove(); //Quita las filas y cabecera
        else $("#" + IdGridView + " tr:not(:first-child)").remove(); //Quita las filas, menos la cabecera
    }
}
//#endregion - Funciones Controles ASP.NET

//#region - Formatos para controles
var DatePicker_Opciones_Default = { fl_changeMonth: false, fl_changeYear: false, minDate : "", maxDate : "", fl_enabled_textbox : true };
function fc_FormatFecha(IdTextBox, DatePicker_Opciones, strIni, objPadre) {
    /*
    IdTextBox: Id del control tipo texto
    fl_changeMonth: Indicador para que muestre el combo de meses
    fl_changeYear: Indicador para que muestre el combo de años
    strMinDate: fecha de comienzo D=días | M=mes | Y=año. Ejm: -15D => 15 dias antes
    strMaxDate: fecha tope D=días | M=mes | Y=año. Ejm: +5D => 5 dias despues
    -----Para rango de fechas-----
    strIni: Utilizado para los calendarios dependientes (rango => fecha inicio y fin) MIN: Fecha Inicio | MAX: Fecha Fin
    objPadre: ID textBox Calendar del cual depende
    ----------------------------------------------
    Ejemplo: this.fc_FormatFecha("txtDesde", false, false, "", "", "MIN", "txtHasta");
    this.fc_FormatFecha("txtHasta", false, false, "", "", "MAX", "txtDesde");
    */
    
    if (IdTextBox.indexOf("#") < 0) IdTextBox = ("#" + IdTextBox);

    var format_fecha = "dd/mm/yy";

    $.datepicker.regional['es'] =
    {
        closeText: 'Cerrar',
        prevText: 'Previo',
        nextText: 'Próximo',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
        'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        monthStatus: 'Ver otro mes', yearStatus: 'Ver otro año',
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
        dateFormat: format_fecha, firstDay: 0,
        initStatus: 'Selecciona la fecha', isRTL: false
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);

    //Carga datepicker
    var idControl = IdTextBox;
    $(idControl).width(80);
    $(idControl).attr("maxlength", "10");
    if (DatePicker_Opciones_Default.fl_enabled_textbox == false) $(idControl).prop("disabled", true);

    $(idControl).datepicker({
        showButtonPanel: true
        , showOn: "button"
        , buttonImage: "img/calendario.png"
        , buttonImageOnly: true
        , buttonText: "Click para mostrar el Calendario"
        , changeMonth: DatePicker_Opciones.fl_changeMonth
        , changeYear: DatePicker_Opciones.fl_changeYear
        , minDate: DatePicker_Opciones.minDate
        , maxDate: DatePicker_Opciones.maxDate
        , onClose: function (selectedDate) {
            if (strIni != "" && strIni != null && strIni != undefined) {
                $("#" + objPadre).datepicker("option", (strIni == "MIN" ? "minDate" : "maxDate"), selectedDate);
            }
        }
    });
}
function fc_FormatNumeros(IdTextBox) {
    if (IdTextBox.indexOf("#") < 0) IdTextBox = ("#" + IdTextBox);
    $(IdTextBox).keypress(function (event) {
        return fc_SoloNumeros(event);
    });    
}
/*#region - Formateo TextBox a Importe*/
var chr_miles = ".";
var chr_decimales = ",";
var mascara_importe = "999.999.999,99";
var mstrFormatoIncorrecto = " no tiene el formato correcto.\n";
function fc_FormatImporte(IdTextBox) {
    var IdTextBox_aux = IdTextBox.replace('#', '');
    var objTextBox = document.getElementById(IdTextBox_aux);

    if (IdTextBox.indexOf("#") < 0) IdTextBox = ("#" + IdTextBox);

    $(IdTextBox).keypress(function (event) {
        return fc_KeyPressTxtImporte(event, objTextBox, mascara_importe);
    });
    $(IdTextBox).bind("paste", function () {
        return false;
    });
    $(IdTextBox).focus(function (event) {
        return fc_OnFocusTxtImporte(event, objTextBox, mascara_importe);
    });
    $(IdTextBox).blur(function (event) {
        return fc_OnBlurTxtImporte(event, objTextBox, mascara_importe);
    });
}

function fc_KeyPressTxtImporte(e, objTextBox, mascara) {
    mascara = fc_Replace(mascara, chr_miles, "");
    //Partimos la mascara para determinar la parte entera y la parte decimal.
    var arrMascara = mascara.split(chr_decimales);
    var intKeyDecimal;
    if (chr_decimales == ".") intKeyDecimal = 46; //"." => 46
    else intKeyDecimal = 44; //"," => 44

    //Validando que la tecla seleccionada sea válida.
    if (e == null) { e = window.event; }

    if (e != null) {
        var intKeyPress = 0;
        if (e.which) // Netscape/Firefox/Opera
        {
            intKeyPress = e.which;
        }
        else {
            intKeyPress = e.keyCode;
        }

        if (intKeyPress == 35 || intKeyPress == 36 || intKeyPress == 37 || intKeyPress == 38 || intKeyPress == 39 ||
            intKeyPress == 40 || intKeyPress == intKeyDecimal || intKeyPress == 45 || intKeyPress == 9 || intKeyPress == 8) {
            return true;
        }
        //Verificamos el MaxLen
        if (objTextBox.value.length >= mascara.length) {
            return false;
        }

        if (intKeyPress != intKeyDecimal && (intKeyPress < 48 || intKeyPress > 57)) return false;
        //Validamos que solo se halla introducido un punto decimal.
        if (intKeyPress == intKeyDecimal && ((arrMascara.length > 1 && objTextBox.value.indexOf(chr_decimales) > -1) || arrMascara.length <= 1)) {
            return false;
        }
    }
    return true;
}
function fc_OnFocusTxtImporte(e, objTextBox, mascara) {
    objTextBox.value = fc_Replace(objTextBox.value, chr_miles, "");
    //objTextBox.focus();
    return true;
}
function fc_OnBlurTxtImporte(e, objTextBox, mascara) {
    var exRegDecimales;
    if (chr_decimales == ".") exRegDecimales = /^[\- \d ,.]+$/i;
    else exRegDecimales = /^[\- \d .,]+$/i;
    var exRegEnteros = /^\d+$/i;

    objTextBox.value = fc_Replace(objTextBox.value, chr_miles, "");

    if (fc_Trim(objTextBox.value) != "") {
        var arrMascara = mascara.split(chr_decimales);
        if (arrMascara.length > 1) {
            if (!fc_Trim(objTextBox.value).match(exRegDecimales)) {
                alert("El valor ingresado" + mstrFormatoIncorrecto + "El formato correcto es: " + mascara);
                objTextBox.value = "";
                objTextBox.focus();
                return false;
            }
        }
        else {
            if (!fc_Trim(objTextBox.value).match(exRegEnteros)) {
                alert("El valor ingresado" + mstrFormatoIncorrecto + "El formato correcto es: " + mascara);
                objTextBox.value = "";
                objTextBox.focus();
                return false;
            }
        }

        var mstrResultado = "";

        if (arrMascara.length > 1) {
            //objTextBox.value = parseFloat(objTextBox.value);
            //if (isNaN(objTextBox.value)) { objTextBox.value = 0; }
            if (isNaN(objTextBox.value.replace(",", "."))) { objTextBox.value = 0; }
            objTextBox.value = roundNumber(objTextBox.value, arrMascara[1].length);
        }
        else {
            //objTextBox.value = parseFloat(objTextBox.value);
            //if (isNaN(objTextBox.value)) { objTextBox.value = 0; }
            if (isNaN(objTextBox.value.replace(",", "."))) { objTextBox.value = 0; }
        }
        //objTextBox.value = mstrResultado;
        objTextBox.value = objTextBox.value;

        arrTextBox = objTextBox.value.split(chr_decimales);
        var arrParteEntera = arrTextBox[0].split("");
        for (var j = arrParteEntera.length - 1; j >= 0; j--) {
            mstrResultado = mstrResultado + arrParteEntera[j];
            if ((arrParteEntera.length - j) != 0 && j != 0) {
                if (((arrParteEntera.length - j) % 3) == 0) {
                    mstrResultado = mstrResultado + chr_miles;
                }
            }
        }

        arrParteEntera = mstrResultado.split("");
        mstrResultado = "";
        for (var j = arrParteEntera.length - 1; j >= 0; j--) {
            mstrResultado = mstrResultado + arrParteEntera[j];
        }

        if (arrTextBox.length > 1) {
            mstrResultado = mstrResultado + chr_decimales + arrTextBox[1];
        }

        objTextBox.value = mstrResultado;
    }
}
function roundNumber(number, decimals) {
    var newString; // The new rounded number
    decimals = Number(decimals);
    if (decimals < 1) {
        newString = (Math.round(number)).toString();
    } else {
        var numString = number.toString();
        if (numString.lastIndexOf(chr_decimales) == -1) {// If there is no decimal point
            numString += chr_decimales; // give it one at the end
        }
        var cutoff = numString.lastIndexOf(chr_decimales) + decimals; // The point at which to truncate the number
        var d1 = Number(numString.substring(cutoff, cutoff + 1)); // The value of the last decimal place that we'll end up with
        var d2 = Number(numString.substring(cutoff + 1, cutoff + 2)); // The next decimal, after the last one we want
        if (d2 >= 5) {// Do we need to round up at all? If not, the string will just be truncated
            if (d1 == 9 && cutoff > 0) {// If the last digit is 9, find a new cutoff point
                while (cutoff > 0 && (d1 == 9 || isNaN(d1))) {
                    if (d1 != chr_decimales) {
                        cutoff -= 1;
                        d1 = Number(numString.substring(cutoff, cutoff + 1));
                    } else {
                        cutoff -= 1;
                    }
                }
            }
            d1 += 1;
        }
        newString = numString.substring(0, cutoff) + d1.toString();
    }
    if (newString.lastIndexOf(chr_decimales) == -1) {// Do this again, to the new string
        newString += chr_decimales;
    }
    var decs = (newString.substring(newString.lastIndexOf(chr_decimales) + 1)).length;
    for (var i = 0; i < decimals - decs; i++) newString += "0";
    //var newNumber = Number(newString);// make it a number if you like
    return newString; // Output the result to the form field (change for your purposes)
}
/*#endregion - Formateo TextBox a Importe*/
//#endregion - Formatos para controles

//#region - Funciones JQGrid
var JQGrid_Opciones_Default = { pageSize: 10, height: "auto", fl_paginar: true, fl_paginar_scroll: false, fl_multiselect: false, altRows: true };
var JQGrid_Util = new Object();
JQGrid_Util.GetTabla_Local = function (IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, objDatos, fn_Click, fn_dblClick, fn_Complete) {
    fc_GetJQGrid_Local(IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, objDatos, fn_Click, fn_dblClick, fn_Complete);
};
JQGrid_Util.GetTabla_Ajax = function (arr_parametros, strUrlServicio, IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, fn_Click, fn_dblClick, fn_Complete) {
    fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, fn_Click, fn_dblClick, fn_Complete);
};
JQGrid_Util.getIDs = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    var IDs = $(IdTabla).jqGrid('getDataIDs');
    return IDs;
}
JQGrid_Util.getRowData = function (IdTabla, RowID) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    return $(IdTabla).getRowData(RowID);
}
JQGrid_Util.getRowDataSelected = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    var RowID = $(IdTabla).jqGrid('getGridParam', 'selrow');
    return $(IdTabla).getRowData(RowID);
}
JQGrid_Util.getRowIDSelected = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    var RowID = $(IdTabla).jqGrid('getGridParam', 'selrow');
    return RowID;
}
JQGrid_Util.getRowIDsSelected = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    var RowIDs = $(IdTabla).jqGrid('getGridParam', 'selarrrow');
    return RowIDs;
}
JQGrid_Util.getCountRegistros = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    var count_filas = $(IdTabla).jqGrid("getGridParam", "records");
    return count_filas;
}
JQGrid_Util.resetSelection = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    $(IdTabla).resetSelection();
}
JQGrid_Util.clearData = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    $(IdTabla).clearGridData(true);
}
JQGrid_Util.AutoWidthResponsive = function (IdTabla) {
    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    $(window).resize(function () {
        gridParentWidth = $('#gbox_' + IdTabla.replace("#", "")).parent().width();
        $(IdTabla).jqGrid('setGridWidth', gridParentWidth);
    });
}

function fc_GetJQGrid_Local(IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, objDatos, fn_Click, fn_dblClick, fn_Complete) {
    try {
        var no_tabla = IdTabla.replace('#', '');
        if (document.getElementById('gbox_' + no_tabla) != null) {
            $(IdTabla).jqGrid('GridUnload'); //Limpia todos los datos (cabecera, estilos de la grilla) y lo deja como si no huviera cargado nada
        }

        if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
        if (IdPieTabla.indexOf("#") < 0) IdPieTabla = ("#" + IdPieTabla);

        //Carga JQGrid
        if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = objDatos.length;

        var gridData = objDatos;
        var theGrid = $(IdTabla);
        numberTemplate = { formatter: 'number', align: 'right', sorttype: 'number' };
        theGrid.jqGrid({
            datatype: 'local',
            data: gridData,
            colNames: Cabecera,
            colModel: ModelCol,
            pager: IdPieTabla,
            rownumbers: false,
            loadtext: "Cargando datos...",
            loadonce: true,
            viewrecords: true, /*Muestra cantidad de registros*/
            recordtext: "{0} - {1} de {2} registros",
            //emptyrecords: 'No se encontraron resultados',
            emptyrecords: 'No existen resultados',
            pgtext: 'Pág: {0} de {1}', //Paging input control text format.
            rowNum: JQGrid_Opciones.pageSize, // PageSize.
            //width: 'auto', //Se utiliza autowidth para que se ajuste ancho
            height: JQGrid_Opciones.height, //auto //'100%' //230 => para 10 registros
            scroll: JQGrid_Opciones.fl_paginar_scroll,
            pgbuttons: JQGrid_Opciones.fl_paginar,
            pginput: JQGrid_Opciones.fl_paginar,
            //rowList: [10, 20, 30], //Variable PageSize DropDownList.
            multiboxonly: true, /*Permite seleccionar fila solo desde el CheckBox*/
            multiselect: JQGrid_Opciones.fl_multiselect,
            sortname: 0, //Default SortColumn
            sortorder: "asc", //Default SortOrder.
            autowidth: true, //Para recalcular automáticamente al ancho del elemento padre
            shrinkToFit: false,
            forceFit: true,
            gridview: true,
            altRows: JQGrid_Opciones.altRows, /*Alternate Rows*/
            hoverrows: false
            , gridComplete: function () { /*Se ejecuta al terminar de cargar la grilla*/
                /*
                var rowIDs = $(IdTabla).jqGrid('getDataIDs'); //Obtiene los Id de las filas concatenados con ","
                for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(IdTabla).jqGrid('getRowData', rowID); //Obtiene los valores de la fila Ejm: row.nid ó row.customer
                }
                */
                if (fn_Complete != "" && fn_Complete != undefined) {
                    fn_Complete();
                }
            }
            , onSelectRow: function (rowID) {
                if (fn_Click != "" && fn_Click != undefined) {
                    fn_Click(rowID);
                }
            }
            , ondblClickRow: function (rowID) {
                if (fn_dblClick != "" && fn_dblClick != undefined) {
                    fn_dblClick(rowID);
                }
            }
            , onSortCol: function (index, columnIndex, sortOrder) {
                //$(IdTabla).trigger("reloadGrid");
            }
            , onPaging: function (pgButton) {
                
            }
        });

    } catch (ex) {
        alert("CATCH: " + ex);
    }
}
function fc_GetJQGrid_Ajax(arr_parametros, strUrlServicio, IdTabla, IdPieTabla, Cabecera, ModelCol, JQGrid_Opciones, fn_Click, fn_dblClick, fn_Complete) {
    var no_tabla = IdTabla.replace('#', '');
    if (document.getElementById('gbox_' + no_tabla) != null) {
        $(IdTabla).jqGrid('GridUnload'); //Limpia todos los datos (cabecera, estilos de la grilla) y lo deja como si no huviera cargado nada
    }

    if (IdTabla.indexOf("#") < 0) IdTabla = ("#" + IdTabla);
    if (IdPieTabla.indexOf("#") < 0) IdPieTabla = ("#" + IdPieTabla);

    //Carga JQGrid
    //if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = objDatos.length;
    if (JQGrid_Opciones.fl_paginar == false) JQGrid_Opciones.pageSize = 10000;

    $(IdTabla).jqGrid(
        {
            datatype: function () {
                $.ajax({
                    type: 'POST',
                    data: "{'strFiltros':" + JSON.stringify(arr_parametros) +
                        ",'pPageSize':'" + $(IdTabla).getGridParam("rowNum") +
                        "','pCurrentPage':'" + $(IdTabla).getGridParam("page") +
                        "','pSortColumn':'" + $(IdTabla).getGridParam("sortname") +
                        "','pSortOrder':'" + $(IdTabla).getGridParam("sortorder")
                        + "'}", //Parametros de entrada del PageMethod
                    dataType: 'json',
                    url: strUrlServicio,
                    contentType: 'application/json; charset=utf-8',
                    async: true,
                    //complete: function (data, textStatus) {
                    //$(IdTabla)[0].addJSONData(JSON.parse(jsondata.responseText).d);
                    //}
                    beforeSend: function () {
                        fc_show_progress(true);
                    },
                    complete: function () {
                        fc_show_progress(false);
                    },
                    success: function (data, textStatus) {
                        if (textStatus == "success")
                            $(IdTabla)[0].addJSONData(JSON.parse(data.d));
                        else
                            alert(JSON.parse(data.responseText).Message);
                    },
                    error: function (request, textStatus, error) {
                        fc_errorAjax(request, textStatus, error);
                    }
                });
            },
            jsonReader: //jsonReader –> JQGridJSonResponse data.
            {
                root: "Items",
                page: "CurrentPage",
                total: "PageCount",
                records: "RecordCount",
                repeatitems: true,
                cell: "Row",
                id: "ID"
            },
            colNames: Cabecera,
            colModel: ModelCol,
            pager: IdPieTabla,
            rownumbers: false,
            loadtext: "Cargando datos...",
            viewrecords: true, /*Muestra cantidad de registros*/
            recordtext: "{0} - {1} de {2} registros",
            emptyrecords: 'No existen resultados',
            pgtext: 'Pág: {0} de {1}', //Paging input control text format.
            rowNum: JQGrid_Opciones.pageSize, // PageSize.
            //width: 'auto', //Se utiliza autowidth para que se ajuste ancho
            height: JQGrid_Opciones.height, //auto //'100%' //230 => para 10 registros
            scroll: JQGrid_Opciones.fl_paginar_scroll,      
            pgbuttons: JQGrid_Opciones.fl_paginar,
            pginput: JQGrid_Opciones.fl_paginar,
            //rowList: [10, 20, 30], //Variable PageSize DropDownList.
            multiboxonly: true, /*Permite seleccionar fila solo desde el CheckBox*/
            multiselect: JQGrid_Opciones.fl_multiselect,
            sortname: 0, //Default SortColumn
            sortorder: "asc", //Default SortOrder.
            autowidth: true, //Para recalcular automáticamente al ancho del elemento padre
            shrinkToFit: false,
            forceFit: true,
            gridview: true,
            altRows: JQGrid_Opciones.altRows, /*Alternate Rows*/
            hoverrows: false
            , gridComplete: function () { /*Se ejecuta al terminar de cargar la grilla*/
                /*var rowIDs = $(IdTabla).jqGrid('getDataIDs'); //Obtiene los Id de las filas concatenados con ","
                for (var i = 0; i < rowIDs.length; i++) {
                var rowID = rowIDs[i];
                var rowData = $(IdTabla).jqGrid('getRowData', rowID); //Obtiene los valores de la fila Ejm: row.nid ó row.customer
                }*/
                if (fn_Complete != "" && fn_Complete != undefined) {
                    fn_Complete();
                }
            }
            , onSelectRow: function (rowID) {
                if (fn_Click != "" && fn_Click != undefined) {
                    fn_Click(rowID);
                }
            }
            , ondblClickRow: function (rowID) {
                if (fn_dblClick != "" && fn_dblClick != undefined) {
                    fn_dblClick(rowID);
                }
            }
        }).navGrid(IdPieTabla, { edit: false, add: false, search: false, del: false, refresh: false
    });
}
//#endregion - Funciones JQGrid

//#region - Funciones Modal
var Modal_Util = new Object();
Modal_Util.Open = function (Div_IdModal) {
    if (Div_IdModal.indexOf("#") < 0) Div_IdModal = ("#" + Div_IdModal);
    $(Div_IdModal).dialog("open");
};
Modal_Util.Close = function (Div_IdModal) {
    if (Div_IdModal.indexOf("#") < 0) Div_IdModal = ("#" + Div_IdModal);
    $(Div_IdModal).dialog("close");
};
Modal_Util.FormatModal = function (Div_IdModal, fl_modal, fn_despuesCerrar) {
    fc_Modal(Div_IdModal, fl_modal, fn_despuesCerrar);
}
Modal_Util.Alert = function (message) {
    fc_Alert(message);
}
Modal_Util.Confirm = function (message, fn_callback_cofirm) {
    fc_Confirm(message, fn_callback_cofirm);
}

function fc_Modal(Div_IdModal, fl_modal, fn_despuesCerrar) {
    if (Div_IdModal.indexOf("#") < 0) Div_IdModal = ("#" + Div_IdModal);
    $(function () {
        $(Div_IdModal).dialog({
            autoOpen: false,
            modal: fl_modal,
            width: "auto",
            height: "auto",
            close: function () {
                fn_despuesCerrar();
            },
            open: function () { }
        });
    });
}
function fc_Alert(message) {
    $("body").append("<div id='dialog-message'></div>");
    message = message.replace(/\n/g, "<br>")
    message = "<div style='margin-top: 10px;'><span class='ui-icon ui-icon-info' style='float: left;'></span><p>" + message + "</p></div>";
    $("#dialog-message").html(message);

    var no_sistema = "Sistema de Reserva de Cita";

    $("#dialog-message").dialog({
        resizable: false,
        modal: true,
        title: no_sistema,
        closeOnEscape: false,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close").remove();
            }
        },
        open: function (event, ui) {
            $(this).parent().children().children('.ui-dialog-titlebar-close').hide();
            $(".ui-dialog :button").blur();
        }
    });
}
function fc_Confirm(message, fn_callback_cofirm) {
    $("body").append("<div id='dialog-confirm'></div>");
    message = message.replace(/\n/g, "<br>")
    message = "<div style='margin-top: 10px;'><span class='ui-icon ui-icon-alert' style='float: left;'></span><p>" + message + "</p></div>";
    $("#dialog-confirm").html(message);

    var no_sistema = "Sistema de Reserva de Cita";
    
    $("#dialog-confirm").dialog({
        resizable: false,
        modal: true,
        title: no_sistema,
        closeOnEscape: false,
        buttons: {
            "Aceptar": function () {
                $(this).dialog("close").remove();
                fn_callback_cofirm(true);
            },
            "Cancelar": function () {
                $(this).dialog("close").remove();
                fn_callback_cofirm(false);
            }
        },
        open: function (event, ui) {
            $(this).parent().children().children('.ui-dialog-titlebar-close').hide();
            $(".ui-dialog :button").blur();
        }
    });
}
//#endregion

//Funciones JQGRID -> Genericas [INICIO]
function fc_Hide_Check_All(IdGrilla) {
    var myGrid = $(IdGrilla);
    $("#cb_" + myGrid[0].id).hide();
}
//Funciones JQGRID -> Genericas [FIN]

/*[INICIO] - JQUERY TreeView*/
function fc_CrearTreeView(strIdDivArbol, strTipoArbol, strSeleccionMultiple, DataArbol, strfn_callback) {
    /*
    strIdDivArbol: Div donde se mostrara el arbol
    strTipoArbol: Tipo de Arbol [checkbox - Check al Inicio] - [Vacio - Sin Check]
    strSeleccionMultiple:  True o False
    fn_callback: funcion despues de clic, devuelve los nodos Seleccionados
    */
    $("#" + strIdDivArbol).jstree("destroy"); //Limpia DIV TreeView

    $(function () {
        $('#' + strIdDivArbol).jstree({
            'plugins': ["", strTipoArbol],
            'core': { "multiple": strSeleccionMultiple, 'data': DataArbol }
        }).on('changed.jstree', function (e, data) {
            var i, j, r = [];
            for (i = 0, j = data.selected.length; i < j; i++) {
                r.push(data.instance.get_node(data.selected[i]).id);
            }
            strfn_callback(r.join(', '));
        }).jstree();
    });
}
/*[FIN] - JQUERY TreeView*/

function fc_FillCombo(IdCombo, objDataCombo, textDefault) {
    if (IdCombo.indexOf("#") < 0) IdCombo = ("#" + IdCombo);

    $(IdCombo).html(""); //Limpia opciones
    if (objDataCombo.length == 0) {
        $(IdCombo).append("<option value=''>--Ninguno--</option>");
    }
    else {
        if (textDefault != "") $(IdCombo).append("<option value=''>" + textDefault + "</option>");
    }

    var icon = "";
    $.each(objDataCombo, function (i, item) {
        if (item.icon != undefined) {
            icon = "title='" + item.icon + "'";
        }

        $(IdCombo).append("<option " + icon + " value='" + item.value + "'>" + item.nombre + "</option>");
    });
}

//Funciones Acceso a Datos - JSON - -> Genericas [INICIO]
function fc_CallService(strParametros, strUrlServicio, fn_callback) {
    fc_show_progress(true);
    $.ajax({
        type: 'POST',
        data: strParametros, //PageMethod Parametros de entrada
        dataType: 'json',
        url: strUrlServicio,
        contentType: 'application/json; charset=utf-8',
        //async: false, //esto es requerido, de otra forma el jqgrid se cargaria antes que el grid
        async: true,
        beforeSend: function () {
            //fc_show_progress(true);
        },
        complete: function () {
            fc_show_progress(false);
        },
        success: function (data, textStatus) {
            if (textStatus == "success") {
                fn_callback(JSON.parse(data.d));
            }
            else alert("ERROR SUCCESS: " + JSON.parse(jsondata.responseText).Message);
        },
        error: function (request, textStatus, error) {
            fc_errorAjax(request, textStatus, error);
        }
    });
}
function fc_errorAjax(request, textStatus, error) {
    //textStatus => 'error';
    if (request.status == 401) {
        alert('Acceso no Autorizado: ' + error);
        location.reload();
    }
    else if (request.status == 0) {
        fc_Alert("Error de conexión con el sistema.\nVerificar red y volver a intertarlo.");
    }
    else {
        var indexIni = request.responseText.indexOf('<title>') + 7
        var indexFin = request.responseText.indexOf('</title>') - indexIni;
        var err = (request.responseText.substr(indexIni, indexFin));
        if (err == '') {
            try {
                err = jQuery.parseJSON(request.responseText).Message;
            } catch (ex) { }
        }
        alert("Error: (" + request.status + "): " + err);
    }
}
//Funciones Acceso a Datos - JSON - -> Genericas [FIN]

//[INICIO] - Modal Progress
function fc_show_progress(flag) {
    if (flag) $("#divProgress").show();
    else $("#divProgress").hide();
}
//[FIN] - Modal Progress

/*Ejecuta el click de un control segun evento de determinada tecla*/
function fc_PressKey(oKey, CtrlClientID) {
    if (event.keyCode == oKey)
        document.getElementById(CtrlClientID).click();
    //    return false;
}

//[INICIO] - Upload File
/*
IDobjFile: Id del control tipo input file
srtRuta: Ruta donde se subiran los archivos
fc_CallBack: Funcion despues de Subir Archivo
*/
function fc_UploadFile(IDobjFile, srtRuta, intPesoMax, fc_CallBack) {
    if (navigator.appName.indexOf("Explorer") != -1) {
        if (navigator.appVersion.indexOf("MSIE 1") == -1) {
            //Anteriores a v10
            alert('- Debe usar Internet Explorer superior a 9 o otro navegador.');
            return;
        }
    }

    var archivos = document.getElementById(IDobjFile);
    var archivo = archivos.files;
    var idFile = 1;
    var vo_NomArchivo = "";

    //Validacion Extencion
    var strExtenciones = new Array(".gif", ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".txt", ".pdf");
    var value = document.getElementById(IDobjFile).value;
    var extension = value.substring(value.lastIndexOf(".")).toLowerCase();
    var permitida = false;
    for (var i = 0; i < strExtenciones.length; i++) {
        if (strExtenciones[i] == extension) {
            permitida = true;
            break;
        }
    }
    if (!permitida) {
        alert("Comprueba la extensión de los archivos a subir. \n  Sólo se pueden subir archivos con extensiones: " + strExtenciones.join() + "\n");
        return false;
    }
    //FIn Validacion Extencion

    //Inicio Validacion Peso
    var pesoFileKB = 0;
    permitida = false;
    for (var i = 0; i < archivo.length; i++) {
        pesoFileKB = (archivo[i].size / 1024);
        if (pesoFileKB > intPesoMax) {
            permitida = true;
            break;
        }
    }
    pesoFileKB = parseInt(pesoFileKB);
    if (permitida) {
        alert('El tamaño del archivo no puede ser mayor a ' + intPesoMax.toString() + ' KB');
        return false;
    }
    //Fin Validacion Peso

    fc_show_progress(true);
    try {
        for (var i = 0; i < archivo.length; i++) {
            vo_NomArchivo = "0";
            var xhr = new XMLHttpRequest();
            var fd = new FormData();
            fd.append('file', archivo[i]);
            fd.append('name', "");
            fd.append('ruta', srtRuta)

            xhr.open('POST', '../FileUpload.ashx/ProcessRequest', true);
            xhr.onload = function (e) {
                if (this.status == 200) {
                    var rsc = this.responseText.split("|");
                    fc_CallBack(rsc, pesoFileKB);
                    fc_show_progress(false);
                }
                else { alert(e); }
            };
            xhr.send(fd);
            idFile += 1;
        }
        document.getElementById(IDobjFile).value = null;
    } catch (ex) {
        alert(ex);
    }
}
//[FIN] - Upload File


function fc_Trim(pstrInput) {
    /*************************************************************************************
    Modulo 		:    
    Descripción :    Función que quitar los espacios en blanco de del parametro string
    Inputs		:
    Autor 		:	 
    Fecha/hora	:    01/09/2014 11:00
    Empresa		:    
    Notas		:    
    *************************************************************************************/
    var i;
    var vstrTemp = '';
    var j = 0;
    var cadena = pstrInput;

    for (i = 0; i < cadena.length; ) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(i + 1, cadena.length);
        else
            break;
    }

    for (i = cadena.length - 1; i >= 0; i = cadena.length - 1) {
        if (cadena.charAt(i) == " ")
            cadena = cadena.substring(0, i);
        else
            break;
    }
    return cadena;
}
function fc_Replace(texto, s1, s2) {
    return texto.split(s1).join(s2);
}