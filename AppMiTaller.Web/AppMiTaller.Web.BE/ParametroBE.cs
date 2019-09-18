using System;
using System.Collections.Generic;

namespace AppMiTaller.Web.BE
{
    [Serializable]
    public class ParametroBE
    {
        public Int32 nid_parametro;
        public string co_parametro;
        public string no_parametro;
        public string no_tipo_valor;
        public string no_valor1;
        public string qt_valor2;
        public string fl_valor3;
    }
    [Serializable]
    public class ParametroBEList : List<ParametroBE> { }
}