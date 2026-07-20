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

        public double tobasten(object[] num, double bass, double velocity)
        {
            int po = 0; char res = 'I';
            Char.TryParse(num[0].ToString(), out res);

            if (res == '-')
            {
                po = 1;
                object[] temp = new object[] { };
                Array.Copy(num, 1, temp, 0, num.Length - 1);
                num = temp;
            }
            double outout = 0d;

            if (num.Contains('.'))
            {
                int pos = Array.IndexOf(num, '.');
                for (int z = 0; z < num.Length; z++)
                {
                    if (Object.Equals(num[z], '.')) { pos++; continue; }
                    outout += expor(bass, (z - pos) * velocity) * Convert.ToDouble(num[z]);
                }
            }
            else
            {
                for (int z = 0; z < num.Length; z++)
                {
                    outout += expor(bass, z * velocity) * Convert.ToDouble(num[z]);
                }
            }

            if (po == 0) return outout;
            else return 0 - outout;
        }
        public object[] notobasten(double num, double bass, double velocity, int accuracy)
        {
            int statis = 0;
            if (bass < 1)
            {
                statis = 1;
                bass = 1 / bass;
            }

            int ceil = (int)(1 + Math.Floor(Math.Log(Math.Abs(Convert.ToDouble(num)), expor(bass, velocity))));
            List<object> outout = new List<object> { };

            for (int z = 0; z < ceil; z++)
            {
                int q = ceil - (z + 1);
                double index = expor(bass, (q * velocity));

                int t = (int)(Math.Floor(num / index));

                if (t >= 1)
                {
                    num -= t * index;
                }
                outout.Add(t);
            }

            if (num == 0)
            {
                if (statis == 0) return outout.ToArray<object>();
                else
                {
                    object[] x = outout.ToArray<object>();
                    Array.Reverse(x);
                    return x;
                }
            }
            else
            {
                outout.Add('.');

                for (int z = 0; z < (accuracy - ceil); z++)
                {
                    if (num == 0)
                    {
                        return outout.ToArray<object>();
                    }
                    double index = 1d;
                    try
                    {
                        index = expor(bass, (0 - (z + 1)) * velocity);
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
                    outout.Add(t);
                }
                if (statis == 0) return outout.ToArray<object>();
                else { object[] x = outout.ToArray<object>(); Array.Reverse(x); return x; }
            }
        }

        #endregion

        #region POLARITY

        public double polaris(object[] num, double bass, double velocity, int mod)
        {
            double outout = 0d;
            int l = num.Length;
            int q = l;

            for (int z = 0; z < l; z++)
            {
                if (Object.Equals('.', num[z])) continue;
                q--;
                if (z % 2 == mod)
                {
                    outout += Convert.ToDouble(num[z]) * expor(bass, (q * velocity));
                }
                else
                {
                    outout -= Convert.ToDouble(num[z]) * expor(bass, (q * velocity));
                }
            }

            return outout;
        }
        public object[] depolaris(object[] num, double bass, double velocity, int mod, int accuracy)
        {
            double abls = 0;

            Array.Reverse(num);

            int z = 0;
            if (-1 != Array.IndexOf(num, '.')) z = Array.IndexOf(num, '.') - num.Length;

            for (int z_2 = 0; z_2 < num.Length; z_2++)
            {
                if ((char)num[z_2] == '.') continue;

                z += 1;
                if (z % 2 == mod)
                {
                    if ((char)num[z_2] != '0')
                    {
                        abls += expor(bass, (z + 1) * velocity);
                        abls += bass - (2 * Convert.ToDouble(num[z_2]) * expor(bass, z * velocity));
                    }
                }
            }

            return notobasten(tobasten(num, bass, velocity) + abls, bass, velocity, accuracy);
        }
        #endregion

        #region ECHO

        public object[] unechor(int rip, object[] num, int mode)
        {
            List<object> outout = new List<object> { };
            int r = Math.Abs(rip);
            int nlen = num.Length - 1; int mid;

            try { mid = Array.IndexOf(num, 'জ'); }
            catch { return num; }

            object[] left = new object[mid];
            Array.Copy(num, 0, left, 0, mid);
            object[] right = new object[num.Length - (mid + 1)];
            Array.Copy(num, mid + 1, right, 0, num.Length - (mid + 1));
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
                        if (rx == 0) break;

                        outout.Add(right[rount - rx]);
                        rx--;
                    }
                    fire = "780";
                }
                else if (fire == "780")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (lx == 0) break;

                        outout.Add(left[lount - lx]);
                        lx--;
                    }
                    fire = "I";
                }
            }

            return outout.ToArray();
        }
        public object[] unechor(int rip, object[] num, int mode, int mid)
        {
            List<object> outout = new List<object> { };
            int r = Math.Abs(rip);
            int nlen = num.Length - 1;

            object[] left = new object[mid];
            Array.Copy(num, 0, left, 0, mid);
            object[] right = new object[num.Length - (mid + 1)];
            Array.Copy(num, mid + 1, right, 0, num.Length - (mid + 1));
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
                        if (rx == 0) break;

                        outout.Add(right[rount - rx]);
                        rx--;
                    }
                    fire = "780";
                }
                else if (fire == "780")
                {
                    for (int z_2 = 0; z_2 < r; z_2++)
                    {
                        if (lx == 0) break;

                        outout.Add(left[lount - lx]);
                        lx--;
                    }
                    fire = "I";
                }
            }

            return outout.ToArray();
        }
        public object[] echor(object[] num, int mode, int rip, int uni)
        {
            int ripl = Math.Abs(rip);
            List<object> left_arr = new List<object> { };
            List<object> right_arr = new List<object> { };
            int x = num.Length;
            int count = x;
            string fire = "I";

            while (x >= 0)
            {
                if (fire == "780") { fire = "I"; }
                else if (fire == "I") { fire = "780"; }
                else { return ["How?"]; }

                for (int z = 0; z < ripl; z++)
                {
                    if (fire == "I")
                    {
                        if (x == 0) break;
                        else left_arr.Add(num[count - x]);
                    }

                    else if (fire == "780")
                    {
                        if (x == 0) break;
                        else right_arr.Add(num[count - x]);
                    }
                    x--;
                }
                if (x == 0) { break; }
            }

            left_arr.Reverse();
            object[] outout = new object[] { };

            if (mode == 0)
            {
                if (rip < 0)
                {
                    left_arr.Reverse();
                    right_arr.Reverse();
                }
                if (uni == 0) left_arr.Add('জ');
                else if (uni == 1) left_arr.Add('&');

                left_arr.AddRange(right_arr);
                outout = left_arr.ToArray();
            }
            else
            {
                if (rip < 0)
                {
                    left_arr.Reverse();
                    right_arr.Reverse();
                }
                if (uni == 0) right_arr.Add('জ');
                else if (uni == 1) right_arr.Add('&');

                right_arr.AddRange(left_arr);
                outout = right_arr.ToArray();
            }

            return outout;
        }
        public int[] echor(int[] num, int mode, int rip, int uni)
        {
            int ripl = Math.Abs(rip);
            List<int> left_arr = new List<int> { };
            List<int> right_arr = new List<int> { };
            int x = num.Length;
            int count = x;
            string fire = "I";

            while (x >= 0)
            {
                if (fire == "780") { fire = "I"; }
                else if (fire == "I") { fire = "780"; }
                else { return [0]; }

                for (int z = 0; z < ripl; z++)
                {
                    if (fire == "I")
                    {
                        if (x == 0) break;
                        else left_arr.Add(num[count - x]);
                    }

                    else if (fire == "780")
                    {
                        if (x == 0) break;
                        else right_arr.Add(num[count - x]);
                    }
                    x--;
                }
                if (x == 0) { break; }
            }

            left_arr.Reverse();
            int[] outout = new int[] { };

            if (mode == 0)
            {
                if (rip < 0)
                {
                    left_arr.Reverse();
                    right_arr.Reverse();
                }
                if (uni == 0) left_arr.Add('জ');
                else if (uni == 1) left_arr.Add('&');

                left_arr.AddRange(right_arr);
                outout = left_arr.ToArray();
            }
            else
            {
                if (rip < 0)
                {
                    left_arr.Reverse();
                    right_arr.Reverse();
                }
                if (uni == 0) right_arr.Add('জ');
                else if (uni == 1) right_arr.Add('&');

                right_arr.AddRange(left_arr);
                outout = right_arr.ToArray();
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
        public string? bisp()
        {
            string outout = "T";

            if (velocity != 1)
            {
                outout += $"স{velocity}";
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

            if (discretion != 0)
            {
                outout += "গ";
            }

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

            bisplay = outout + $"{base_value}>";

            return bisplay;
        }

        #endregion

        #region CALCULUS

        public double disintegrate(object[] num, Basal inbas)
        {
            if (inbas.echo != 2) { num = inbas.unechor(inbas.ripple, num, inbas.echo); }

            if (inbas.polar != 2)
            {
                double outout = 0d; int l = num.Length; int q = l - 2;

                for (int z = 0; z < l; z++)
                {
                    try { if ((char)num[z] == '.') { continue; } }
                    catch
                    {
                        q--;
                        if (z % 2 == inbas.polar)
                            outout += (Convert.ToDouble(num[z]) * expor(inbas.base_value, (q - 1) * inbas.velocity) * q);
                        else
                            outout += (Convert.ToDouble(num[z]) * expor(inbas.base_value, (q - 1) * inbas.velocity) * q);
                    }
                }
                return outout;
            }
            else
            {
                int po = 0; char res = 'I';
                Char.TryParse(num[0].ToString(), out res);

                if (res == '-')
                {
                    po = 1;
                    object[] temp = new object[] { };
                    Array.Copy(num, 1, temp, 0, num.Length - 1);
                    num = temp;
                }
                double outout = 0d; Array.Reverse(num);

                if (num.Contains('.'))
                {
                    int pos = Array.IndexOf(num, '.');
                    for (int z = 0; z < num.Length; z++)
                    {
                        if (Object.Equals(num[z], '.')) { pos++; continue; }
                        outout += expor(inbas.base_value, (z - pos - 1) * inbas.velocity) * Convert.ToDouble(num[z]) * z;
                    }
                }
                else
                {
                    for (int z = 0; z < num.Length; z++)
                    {
                        outout += expor(inbas.base_value, (z - 1) * inbas.velocity) * Convert.ToDouble(num[z]) * z;
                    }
                }

                if (po == 0)
                    return outout;
                else
                    return 0 - outout;
            }
        }

        #endregion

        #region EXPANLY

        public double expan(object[] num, Basal asbas, Basal debas)
        {
            double outout = 0d;
            int l = num.Length;

            int[] asarr = new int[l];
            int[] dearr = new int[l];

            for (int z = 0; z < l; z++)
            {
                asarr[z] = z;
                dearr[z] = z;
            }

            Console.WriteLine(String.Join(' ', asarr));
            Console.WriteLine(String.Join(' ', dearr));

            if (asbas.echo != 2) asarr = asbas.echor(asarr, asbas.echo, asbas.ripple, 2);
            if (debas.echo != 2) dearr = debas.echor(dearr, debas.echo, debas.ripple, 2);

            int q = 0; int pos = Array.IndexOf(num, '.');

            if (asbas.polar == debas.polar)
            {
                for (int z = 0; z < l; z++)
                {
                    if (pos == z) continue;
                    outout += Convert.ToDouble(num[z]) * expor(asbas.base_value, asarr[q] * asbas.velocity) * expor(debas.base_value, dearr[l - (q + 1)] * debas.velocity);
                    q++;
                }
            }
            else if (asbas.polar + debas.polar == 1)
            {
                for (int z = 0; z < l; z++)
                {
                    if (pos == z) continue;
                    outout -= Convert.ToDouble(num[z]) * expor(asbas.base_value, asarr[q] * asbas.velocity) * expor(debas.base_value, dearr[l - (q + 1)] * debas.velocity);
                    q++;
                }
            }
            else
            {
                int dpo = 2, apo = 2;
                if (asbas.polar == 1) apo = 0;
                else if (asbas.polar == 0) apo = 1;
                if (debas.polar == 1) dpo = 0;
                else if (debas.polar == 0) dpo = 1;


                for (int z = 0; z < l; z++)
                {
                    if (pos == z) continue;
                    if ((l - q) % 2 == dpo || q % 2 == apo)
                        outout -= Convert.ToDouble(num[z]) * expor(asbas.base_value, asarr[q] * asbas.velocity) * expor(debas.base_value, dearr[l - (q + 1)] * debas.velocity);
                    else outout += Convert.ToDouble(num[z]) * expor(asbas.base_value, asarr[q] * asbas.velocity) * expor(debas.base_value, dearr[l - (q + 1)] * debas.velocity);
                    q++;
                }
            }

            return outout;
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
        public string? bisplay = "T10>";

        public object[] number = { '0' };
        public double value = 0;
        #endregion

        #region CONSTRUCTORS
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
            double num,
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
        #endregion
    }
}