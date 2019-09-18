using System;
using System.Collections.Generic;
using System.Reflection;

namespace AppMiTaller.Web.BE
{
    [Serializable]
    public class ComboBE
    {
        public String value { get; set; }
        public String nombre { get; set; }
    }

    [Serializable]
    public class ComboBEList : List<ComboBE>
    {
        public void Ordenar(string propertyName, direccionOrden Direction)
        {
            ComboBEComparer dc = new ComboBEComparer(propertyName, Direction);
            this.Sort(dc);
        }
    }

    class ComboBEComparer : IComparer<ComboBE>
    {
        string _prop = "";
        direccionOrden _dir;

        public ComboBEComparer(string propertyName, direccionOrden Direction)
        {
            _prop = propertyName;
            _dir = Direction;
        }

        public int Compare(ComboBE x, ComboBE y)
        {

            PropertyInfo propertyX = x.GetType().GetProperty(_prop);
            PropertyInfo propertyY = y.GetType().GetProperty(_prop);

            object px = propertyX.GetValue(x, null);
            object py = propertyY.GetValue(y, null);

            if (px == null && py == null)
            {
                return 0;
            }
            else if (px != null && py == null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (px == null && py != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if (px.GetType().GetInterface("IComparable") != null)
            {
                if (_dir == direccionOrden.Ascending)
                {
                    return ((IComparable)px).CompareTo(py);
                }
                else
                {
                    return ((IComparable)py).CompareTo(px);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}