using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using Byte = System.Byte;
using Math = System.Math;
using String = System.String;

namespace ATom.CommonBasics.Extension
{
    public static class ColorExtension {
        private const int RGBMAX = 255;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="color"></param>
        /// <param name="backColor"></param>
        /// <param name="amount">Amount in percent. Has to be in Range from 1 to 0</param>
        /// <returns></returns>
        public static Color Blend(this Color color, Color backColor, double amount = 0.5d) {
            if (amount > 1 || amount < 0) throw new ArgumentOutOfRangeException("Der Parameter Amount soll einen Prozentwert darstellen und darf nicht größer 1 oder kleiner 0 sein.");
            byte r = (byte) ((color.R*amount) + backColor.R*(1 - amount));
            byte g = (byte) ((color.G*amount) + backColor.G*(1 - amount));
            byte b = (byte) ((color.B*amount) + backColor.B*(1 - amount));
            return Color.FromArgb(r, g, b);
        }

        public static Color Invert(this Color ColourToInvert) {
            return Color.FromArgb(RGBMAX - ColourToInvert.R,
                RGBMAX - ColourToInvert.G, RGBMAX - ColourToInvert.B);
        }

        public static Color FromHex(String hexColorCode,int alpha=255) {
            if (hexColorCode.IsNullOrEmpty()) throw new ArgumentException("Hex Farbcode darf nicht null oder eine LeerString sein.");
            if (hexColorCode.StartsWith("#")) hexColorCode = hexColorCode.Replace("#","");
            hexColorCode = hexColorCode.Trim();
            if (hexColorCode.Length!=6) throw new ArgumentException("Hex Farbcode muss aus 6 Hexadezimalzeichen bestehen. darf von einem # angeführt werden, muss aber nicht.");
            ulong hex = Convert.ToUInt64("0x" + hexColorCode,16);
            int r, g, b = 0;
            b = (int) (hex & 0xFF);
            g = (int) ((hex >> 8) & 0xFF);
            r = (int) ((hex >> 16) & 0xFF);
            return Color.FromArgb(alpha,r,g,b);
        }

        private static int Clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private static float Clamp(float value, float min, float max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        private static int ModColorValue(int value, float mod) {
            return Clamp((int) (value+value*mod),0,255);
        }

        public static Color ModifyRGB(this Color color, float mod) {
            return Color.FromArgb(color.A, ModColorValue(color.R, mod), ModColorValue(color.G, mod),
                ModColorValue(color.B, mod));
        }


        /// <summary>
        /// Teilt den Regenbogen gerecht auf und liefert eine Liste von Farben zurück
        /// </summary>
        /// <param name="numberOfColors">in wie viele Farben soll der Regenbogen aufgeteilt werden</param>
        /// <param name="s1">Sättigung</param>
        /// <param name="l">Lichtwert/Hellwert</param>
        /// <returns></returns>
        public static List<Color> GetRainbowColors(int numberOfColors, double s1 = 0.5d, double l = 0.5d) {
            List<Color> list = new List<Color>();
            double step = 1d/(numberOfColors + 1);
            for (double i = step; i < 1; i += step) {
                Color c = HSL2RGB(i, s1, l);
                list.Add(c);
            }
            return list;
        }

        public static HSLColor ToHslColor(this Color color) {
            return HSLColor.FromRGB(color);
        }

        public static Color AddLuminosity(this Color color,float luminosity)
        {
            HSLColor hsl= HSLColor.FromRGB(color);
            HSLColor retHsl = new HSLColor(hsl.Hue,hsl.Saturation,Clamp(hsl.Luminosity+luminosity,0f,1f));
            return retHsl.ToRGB();
        }

        public static Color WithLuminosity(this Color color, float luminosity)
        {
            if (luminosity > 1f || luminosity < 0f) throw new ArgumentOutOfRangeException("HSL Values have to be from 0 to 1.");
            HSLColor hsl = HSLColor.FromRGB(color);
            HSLColor retHsl = new HSLColor(hsl.Hue, hsl.Saturation, luminosity);
            return retHsl.ToRGB();
        }

        public static Color WithSaturation(this Color color, float saturation)
        {
            if (saturation > 1f || saturation < 0f) throw new ArgumentOutOfRangeException("HSL Values have to be from 0 to 1.");
            HSLColor hsl = HSLColor.FromRGB(color);
            HSLColor retHsl = new HSLColor(hsl.Hue,saturation, hsl.Luminosity);
            return retHsl.ToRGB();
        }

        /// <summary>
        /// Convertiert HSL/HSV zu RGB
        /// </summary>
        /// <param name="h">Farbwert</param>
        /// <param name="sl">Sättigung</param>
        /// <param name="l">Lichtwert/Hellwert</param>
        /// <returns></returns>
        public static Color HSL2RGB(double h, double sl, double l) {
            if (h>1f || sl>1f || l>1f || h <0f || sl < 0f || l < 0f) throw new ArgumentOutOfRangeException("HSL Values have to be from 0 to 1.");
            double v;
            double r, g, b;

            r = l; // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l*(1.0 + sl)) : (l + sl - l*sl);
            if (v > 0) {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m)/v;
                h *= 6.0;
                sextant = (int) h;
                fract = h - sextant;
                vsf = v*sv*fract;

                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant) {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;

                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;

                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;

                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;

                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }            
            return Color.FromArgb(Convert.ToByte(r * 255f), Convert.ToByte(g * 255f),Convert.ToByte(b * 255f));
        }

        /// <summary>
        /// http://www.easyrgb.com/index.php?X=MATH
        /// </summary>
        public class HSLColor {
            public float Hue;
            public float Saturation;
            public float Luminosity;

            public HSLColor(float H, float S, float L) {
                Hue = H;
                Saturation = S;
                Luminosity = L;
            }

            public static HSLColor FromRGB(Color Clr) {
                return FromRGB(Clr.R, Clr.G, Clr.B);
            }

            public static HSLColor FromRGB(Byte R, Byte G, Byte B) {
                float _R = (R/255f);
                float _G = (G/255f);
                float _B = (B/255f);

                float _Min = Math.Min(Math.Min(_R, _G), _B);
                float _Max = Math.Max(Math.Max(_R, _G), _B);
                float _Delta = _Max - _Min;

                float H = 0;
                float S = 0;
                float L = (float) ((_Max + _Min)/2.0f);

                if (_Delta != 0) {
                    if (L < 0.5f) {
                        S = (float) (_Delta/(_Max + _Min));
                    } else {
                        S = (float) (_Delta/(2.0f - _Max - _Min));
                    }

                    float _Delta_R = (float) (((_Max - _R)/6.0f + (_Delta/2.0f))/_Delta);
                    float _Delta_G = (float) (((_Max - _G)/6.0f + (_Delta/2.0f))/_Delta);
                    float _Delta_B = (float) (((_Max - _B)/6.0f + (_Delta/2.0f))/_Delta);

                    if (_R == _Max) {
                        H = _Delta_B - _Delta_G;
                    } else if (_G == _Max) {
                        H = (1.0f/3.0f) + _Delta_R - _Delta_B;
                    } else if (_B == _Max) {
                        H = (2.0f/3.0f) + _Delta_G - _Delta_R;
                    }

                    if (H < 0) H += 1.0f;
                    if (H > 1) H -= 1.0f;
                }

                return new HSLColor(H, S, L);
            }            

            public Color ToRGB() {
                return HSL2RGB(Hue, Saturation, Luminosity);                
            }
        }
    }
}
