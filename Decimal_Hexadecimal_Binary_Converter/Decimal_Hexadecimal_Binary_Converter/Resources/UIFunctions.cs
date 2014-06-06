using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

    class UIFunctions
    {
        public static void CenterObject(object obj)
        {
            int scwidth = (int)System.Windows.SystemParameters.PrimaryScreenWidth;
            int scheight = (int)System.Windows.SystemParameters.PrimaryScreenHeight;
            int objwith = (int)((Window)obj).Width;
            int objheight = (int)((Window)obj).Height;
            ((Window)obj).Left = (scwidth / 2) - (objwith / 2);
            ((Window)obj).Top = (scheight / 2) - (objheight / 2);
        }

    }

