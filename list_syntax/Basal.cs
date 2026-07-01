using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Swift;
using System.Text;

namespace Calculator
{
    internal class Basal
    {
        #region REQUIRED
        public static double expor(double num, double expo)
        {
            if (num < 0)
            {
                if (expo % 2 == 1)
                {
                    return (0 - Math.Pow(Math.Abs(num), expo));
                }
                else
                {
                    return (Math.Pow(Math.Abs(num), expo));
                }
            }
            else
            {
                return (Math.Pow(num, expo));
            }
        }

        #endregion

        #region CONVERT TO AND FROM DENARY

        public decimal tobasten(Array num, double bass, double velocity)
        {
            int po = 0;
            if (num[0] == '-')
            {
                po = 1;
                num = num.Substring(1);
            }
            decimal outout = 0;
            Array.Reverse(num);

            if (num.Contains('.'))
            {
                int pos = Array.IndexOf(num, '.');
                for (int z = 0; z < num.Length; z++)
                {
                    if (num[z] == '.') { pos++; continue; }
                    outout += (decimal)expor(bass, (z - pos) * velocity) * num[z];
                }
            }
            else
            {
                for (int z = 0; z < num.Length; z++)
                {
                    outout += (decimal)expor(bass, z * velocity) * num[z];
                }
            }

            if (po == 0) return outout;
            else return 0 - outout;
        }
        public string notobasten(decimal num, double bass, double velocity, int accuracy)
        {
            int statis = 0;
            if (bass < 1)
            {
                statis = 1;
                bass = 1 / bass;
            }

            int ceil = (int)(1 + Math.Floor(Math.Log(Math.Abs((double)num), bass * velocity)));
            object[] outout = {};

            for (int z = 0; z < ceil; z++)
            {
                int q = ceil - (z + 1);
                decimal index = (decimal)expor(bass, (q * velocity));

                int t = (int)(Math.Floor(num / index));

                if (t >= 1)
                {
                    num -= t * index;
                }
                outout.Append(t);
            }

            if (num == 0)
            {
                if (statis == 0) return outout;
                else
                {
                    Array.Reverse(outout);
                    return outout;
                }
            }
            else
            {
                outout.Append('.');

                for (int z = 0; z < (accuracy - ceil); z++)
                {
                    if (num == 0)
                    {
                        return outout;
                    }
                    decimal index = 1M;
                    try
                    {
                        index = (decimal)expor(bass, (0 - (z + 1)) * velocity);
                    }
                    catch
                    {
                        break;
                    }

                    int t = (int)(Math.Floor(num / index));

                    if (t >= 1)
                    {
                        num -= t * index;
                    }
                    outout.Append(t);
                }
                if (statis == 0) return outout;
                else { Array.Reverse(outout); return outout;}
            }
        }

        #endregion

        #region POLARITY

        public decimal polaris(Array num, double bass, double velocity, int mod)
        {
            decimal outout = 0m;
            int l = num.Length;
            int q = l;

            for (int z = 0; z < l; z++)
            {
                if (num[z] == '.') continue;

                q--;
                if (z % 2 == mod)
                {
                    outout += (decimal)(num[z] * expor(bass, (q * velocity)));
                }
                else
                {
                    outout -= (decimal)(num[z] * expor(bass, (q * velocity)));
                }
            }

            return outout;
        }
        public string depolaris(Array num, double bass, double velocity, int mod, int accuracy)
        {
            decimal abls = 0;

            string x = revstr(num);

            int z = 0;
            if (x.Contains('.'))
                z = x.IndexOf('.') - x.Length;

            for (int z_2 = 0; z_2 < x.Length; z_2++)
            {
                if (x[z_2] == '.') continue;

                z += 1;
                if (z % 2 == mod)
                {
                    if (x[z_2] != '0')
                    {
                        abls += (decimal)expor(bass, (z + 1) * velocity);
                        abls += (decimal)(bass - (2 * Cc(x[z_2])) * expor(bass, z * velocity));
                    }
                }
            }

            return notobasten(tobasten(num, bass, velocity) + abls, bass, velocity, accuracy);
        }
        #endregion

        #region ECHO

        public Array unechor(int rip, Array num, int mode)
        {
            object[] outout = {};
            int r = Math.Abs(rip);
            int nlen = num.Length - 1; int mid;

            try { mid = num.IndexOf('জ'); }
            catch { return "Error"; }

            object[] left = new ArraySegment(num, 0, mid);
            object[] right = new ArraySegment(num, mid + 1, num.Length - (mid + 1));
            string fire = "I";
            int rx = right.Length; int rount = rx;
            int lx = left.Length;int lount = lx;

            if (rip > 0)
                Array.Reverse(left);
            else
                Array.Reverse(right);

            if (mode == 1) fire = "780";

            for (int z = 0; z < nlen; z++)
            {
                if (fire == "I")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (rx == 0) break;

                        outout.Append(right[rount - rx]);
                        rx--;
                    }
                    fire = "780";
                }
                else if (fire == "780")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (lx == 0) break;

                        outout.Append(right[lount - lx]);
                        lx--;
                    }
                    fire = "I";
                }
            }

            return outout;
        }
        public Array unechor(int rip, Array num, int mode, int mid)
        {
            object[] outout = {};
            int r = Math.Abs(rip);
            int nlen = num.Length - 1;

            object[] left = new ArraySegment(num, 0, mid);
            object[] right = new ArraySegment(num, mid + 1, num.Length - (mid + 1));
            string fire = "I";
            int rx = right.Length; int rount = rx;
            int lx = left.Length; int lount = lx;

            if (rip > 0)
                Array.Reverse(left);
            else
                Array.Reverse(right);

            if (mode == 1) fire = "780";

            for (int z = 0; z < nlen; z++)
            {
                if (fire == "I")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (rx == 0) { break; }

                        outout.Append(right[rount - rx]);
                        rx--;
                    }
                    fire = "780";
                }
                else if (fire == "780")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (lx == 0) { break; }

                        outout.Append(right[lount - lx]);
                        lx--;
                    }
                    fire = "I";
                }
            }

            return outout;
        }
        public Array echor(string num, int mode, int rip, int uni)
        {
            int ripl = Math.Abs(rip);
            object[] left_arr = {};
            object[] right_arr = {};
            int x = num.Length;
            int count = x;
            char fire = 'I';
            char[]? placehold = ['জ'];

            if (uni == 1)
                placehold[0] = '&';

            while (x >= 0)
            {
                if (fire == "780") { fire = "I"; }
                else if (fire == "I") { fire = "780"; }
                else { return "How?"; }

                for (int z = 0; z < ripl; z++)
                {
                    if (fire == "I")
                    {
                        if (x == 0) break;
                        else
                        {
                            left_arr.Append(num[count - x]);
                        }
                    }

                    else if (fire == "780")
                    {
                        if (x == 0) break;
                        else
                        {
                            right_arr.Append(num[count - x]);
                        }
                    }
                    x--;
                }
                if (x == 0) { break; }
            }
            
            Array.Reverse(left_arr);
            object[] outout = {};

            if (mode == 0)
            {
                if (rip < 0)
                {
                    Array.Reverse(left_arr);
                    Array.Reverse(right_arr);
                }
                if (uni == 0) left_arr.Append('জ');
                else if (uni == 1) left_arr.Append('&');

                outout = left_arr.Concat(right_arr);
            }
            else
            {
                if (rip < 0)
                {
                    Array.Reverse(left_arr);
                    Array.Reverse(right_arr);
                }
                if (uni == 0) right_arr.Append('জ');
                else if (uni == 1) right_arr.Append('&');

                outout = right_arr.Concat(left_arr);
            }

            return outout;
        }

        #endregion

        #region DISPLAY

        public string? disp()
        {
            string outout = $"<{base_value}";

            if (polar != 2)
            {
                if (polar == 0)
                {
                    outout += "ঋ";
                }
                else if (polar == 1)
                {
                    outout += "দ";
                }
            }
            if (discretion != 0)
            {
                outout += "গ";
            }
            if (echo != 2)
            {
                if (echo == 0)
                {
                    outout += $"+ল{ripple}";
                }
                else if (echo == 1)
                {
                    outout += $"-ল{ripple}";
                }
            }
            if (velocity != 1)
            {
                outout += $"স{velocity}";
            }

            display = outout + "T";

            return display;
        }

        #endregion

        #region CALCULUS
 
        public decimal disintegrate(Array num, Basal inbas)
        {
            if (inbas.echo != 2) { num = inbas.unechor(inbas.ripple, num, inbas.echo); }

            if (inbas.polar != 2)
            {
                decimal outout = 0M ; int l = num.Length ; int q = l - 2;

                for (int z = 0; z < l; z++)
                {
                    if (num[z] == '.') { continue ;}
                    q--;
                    if (z % 2 == inbas.polar)
                        outout += num[z] * expor(inbas.base_value, (q - 1) * inbas.velocity) * q;
                    else
                        outout += num[z] * expor(inbas.base_value, (q - 1) * inbas.velocity) * q;
                }
                return outout;
            }
            else
            {
                po = 0;
                if (num[0] == '-') { num = new ArraySegment(num, 1, num.Length - 1) ; po = 1; }
                decimal outout = 0M; Array.Reverse(num); 

                if (num.Contains('.'))
                {
                    int pos = Array.IndexOf(num, '.');
                    for (int z = 0; z < num.Length; z++)
                    {
                        if (num[z] == '.') { pos++; continue; }
                        outout += (decimal)expor(bass, (z - pos - 1) * velocity) * num[z] * z;
                    }
                }
                else
                {
                    for (int z = 0; z < num.Length; z++)
                    {
                        outout += (decimal)expor(bass, (z - 1) * velocity) * num[z] * z;
                    }
                }

                if (po == 0)
                    return outout;
                else
                    return 0 - outout;
            }
        }

        #endregion

        #region ATTRIBUTES
        public int type = 1;
        public int polar = 2;
        public int discretion = 0;
        public int echo = 2;
        public int ripple = 0;
        public double velocity = 1;
        public int po = 0;

        public double base_value = 10;

        public string? display = "<10T";

        public object[] number = {'0'};
        public decimal value = 0;
        #endregion

        public Basal() { }

        public Basal(
            object[] num,
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            number = num;
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;

            if (echo != 2)
            {
                num = unechor(rip, num, echo);
            }
            if (pol != 2)
            {
                value = polaris(num, bass, vel, pol);
            }
            else
            {
                value = tobasten(num, bass, vel);
            }
        }

        public Basal(
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;
        }

        public Basal(
            decimal num,
            double bass,
            int pol,
            int dis,
            int eco,
            int rip,
            double vel
            )
        {
            value = num;
            base_value = bass;
            polar = pol;
            discretion = dis;
            echo = eco;
            ripple = rip;
            velocity = vel;

            number = notobasten(num, bass, vel, 69);

            if (polar != 2)
            {
                number = depolaris(number, bass, vel, pol, 69);
            }

            if (echo != 2)
            {
                number = echor(number, echo, rip, 0);
            }
        }
    }
}