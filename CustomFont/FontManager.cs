using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dnlib.DotNet;

namespace Loader.CustomFont
{
    public class FontManager
    {
        private static readonly PrivateFontCollection Pfc = new PrivateFontCollection();
        private static FontFamily _customFontFamily;

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        public static FontFamily GetFont()
        {
            if (_customFontFamily == null)
            {
                byte[] fontData = Properties.BluestacksRes.DiscetMono;
                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                uint dummy = 0;
                Pfc.AddMemoryFont(fontPtr, fontData.Length);
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
                Marshal.FreeCoTaskMem(fontPtr);

                _customFontFamily = Pfc.Families[0];
            }

            return _customFontFamily;
        }
    }
}