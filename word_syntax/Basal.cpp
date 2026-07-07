#include <iostream>
#include <string>
#include <cmath>

using namespace std;

class Basal 
{
public:
    int echo = 2, ripple = 0, polar = 2, discretion = 0, accuracy = 30;
    double velocity = 1;

    double num_value = 0;
    double base_value = 10;
    string number = "0";
    string display = "<10T";

    Basal(){}
    Basal(double bass, double vel, int pol, int dis, int eco, int rip_val, int acc)
    {
        base_value = bass;
        velocity = vel;
        polar = pol;
        discretion = dis;
        echo = eco;
        ripple = rip_val;
        accuracy = acc;
    }
    Basal(string num, double bass, double vel, int pol, int dis, int eco, int rip_val, int acc)
    {
        number = num;
        base_value = bass;
        velocity = vel;
        polar = pol;
        discretion = dis;
        echo = eco;
        ripple = rip_val;
        accuracy = acc;

        Deconvert(num);
    }

    void Convert(int noom)
    {
        number = notobasten(noom, base_value, velocity, accuracy);

        if (polar != 2)
            number = depolaris(number, base_value, polar, velocity, accuracy);

        if (echo != 2)
            number = echor(ripple, echo, number);
    }
    void Deconvert(string number)
    {
        if (echo != 2)
            number = unechor(ripple, number, echo);

        if (polar != 2)
            num_value = polariser(number, base_value, polar, velocity);

        else
            num_value = tobasten(number, base_value, velocity);
    }

    double logbas(double x, double bass)
    {
        return log(x) / log(bass);
    }
    double expor(double num, double expo)
    {
        if (num < 0)
        {
            if (fmod(expo, 2) == 1)
                return (0 - pow(abs(num), expo));

            else
                return (pow(abs(num), expo));
        }
        else
            return (pow(num, expo));
    }

    double tobasten(string num, double bass, double velocity)
    {
        double outout = 0;

        int po = 0;
        if (num[num.length() - 1] == '-')
        {
            po = 1;
        }

        if (num.find('.') != string::npos)
        {
            int pos = num.find('.');
            string noom_left = num.substr(0, pos);
            string noom_right = num.substr(pos);

            for (int z = 0; z < noom_left.length(); z++)
            {
                outout += (pow(bass, (z * velocity)) * (noom_left[z] - 48));
            }
            for (int z = 0; z < noom_right.length(); z++)
            {
                outout += (pow(bass, (0 - ((z + 1) * velocity))) * (noom_right[z] - 48));                
            }
        }
        else {
            for (int z = 0; z < num.length(); z++)
            {
                outout += pow(bass, (z * velocity)) * (num[z] - 48);
            }
        }

        return outout;
    }
    string notobasten(double num, double bass, double velocity, int accuracy)
    {
        int statis = 0;

        if (bass < 1)
        {
            bass = 1 / bass; statis = 1;
        }

        int ceil = (1 + floor(logbas(abs(num), pow(bass, velocity))));
        string outout = "";

        for (int z = 0; z < ceil; z++)
        {
            double index = pow(bass, ((ceil - (z + 1)) * velocity));

            double t = floor(num / index);

            if (t >= 1)
            {
                num -= (t * index);
            }

            outout += (char)(t + 48);
        }

        if (num == 0)
        {
            if (statis == 0)
                return outout;
            else
                reverse(outout.begin(), outout.end());  return "0." + outout;
        }
        outout += '.';

        for (int z = 0; z < (accuracy - ceil); z++)
        {
            if (num == 0)
                return outout;

            double index = pow(bass, ((0 - (z + 1)) * velocity));

            double t = floor(num / index);

            if (t >= 1)
                num -= t * index;

            outout += (char)(t + 48);
        }

        if (statis == 0)
            return outout;
        else
            reverse(outout.begin(), outout.end()); return outout;
    }

    double polariser(string num, double bass, int mod, double velocity)
    {
        double outout = 0;
        int l = num.length();
        int q = l - 1;

        if (num.find('.') != string::npos)
            q -= num.find('.');

        for (int z = 0; z < l; z++)
        {
            if (num[z] == '.')
                continue;
            
            q--;

            if (z % 2 == mod)
            {
                outout += num[z] * pow(bass, (q * velocity));
            }
            else
            {
                outout -= num[z] * pow(bass, (q * velocity));                
            }
        }
        return outout;
    }
    string depolaris(string num, double bass, int mod, double velocity, int accuracy)
    {
        double albs = 0;
        int z = 0;
        reverse(num.begin(), num.end());
        

        if (num.find('.') != string::npos)
            z -= num.find('.');

        for (int z_2 = 0; z_2 < num.length(); z_2++)
        {
            if (num[z] == '.')
                continue;
            
            z += 1;

            if (num[z] != '0')
                albs += pow(bass, ((z + 1) * velocity)) + ((bass - (2 * num[z])) * pow(bass, (z * velocity)));
        }

        reverse(num.begin(), num.end());

        return notobasten(tobasten(num, bass, velocity) + albs, bass, velocity, accuracy);
    }

    string unechor(int ripple, string num, int mode)
    {
        int r = abs(ripple);
        int nlen = num.length();

        int mid;

        if (num.find('জ') != string::npos)
            mid = num.find('জ');

        else if (num.find('&') != string::npos)
            mid = num.find('&');

        else
            return "why";
        
        string left_arr = num.substr(0, mid);reverse(left_arr.begin(), left_arr.end());
        string right_arr = num.substr(nlen - mid);
        int fire = 73;
        int rx = right_arr.length(), rount = right_arr.length();
        int lx = left_arr.length(), lount = left_arr.length();
        string outout = "";

        if (ripple < 0)
        {
            reverse(right_arr.begin(), right_arr.end());
            reverse(left_arr.begin(), left_arr.end());
        }
        if (mode == 1)
            fire = 780;

        for (int z = 0; z < nlen; z++)
        {
            if (fire == 73)
            {
                for (int z_2 = 0; z_2 < r; z_2++)
                {
                    if (rx == 0)
                        break;
                    
                    outout += right_arr[rount - rx];
                    rx --;
                }
                fire = 780;
            }

            else if (fire == 780)
            {
                for (int z_2 = 0; z_2 < r; z_2++)
                {
                    if (lx == 0)
                        break;
                
                    outout += left_arr[lount - lx];
                    lx --;
                }
                fire = 73;
            }
        }
        reverse(outout.begin(), outout.end());
        return outout;
    }
    string echor(int ripple, int mode, string num)
    {
        int r = abs(ripple);
        string left_arr = "";
        string right_arr = "";

        int x = num.length(), count = num.length();
        int fire = 73;

        if (mode == 1)
            fire = 780;

        while (x >= 0)
        {
            if (fire == 780)
                fire = 73;
            else if (fire == 73)
                fire = 780;
            
            for (int z = 0; z < r; z++)
            {
                if (fire == 73)
                {
                    if (x != 0)
                        left_arr += num[count - x];
                    else
                        break;
                }
                else if (fire == 780)
                {
                    if (x != 0)
                        right_arr += num[count - x];
                    else
                        break;
                }
                x --;
            }
        }

        if (ripple < 0)
            reverse(right_arr.begin(), right_arr.end());
        else
            reverse(left_arr.begin(), left_arr.end());
        
        return left_arr + "জ" + right_arr;
    }
};

int main()
{
    Basal bass;

    cout << bass.base_value;
}
