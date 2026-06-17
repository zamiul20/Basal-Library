#include <iostream>
#include <string>
#include <cmath>
#include <tuple>
#include <algorithm>

using namespace std;

class Basal 
{
public:
    int echo = 2, ripple = 0, polar = 2, discretion = 0, accuracy = 30;
    double velocity = 1;

    double num_value = 0;
    double base_value = 10;
    tuple<double, char> number = {};
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
    Basal(tuple<double, char> num, double bass, double vel, int pol, int dis, int eco, int rip_val, int acc)
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
    void Deconvert(tuple<double> number)
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
    
    int tobe(tuple<double, char> num, char item)
    {
        for (int i = 0; i < tuple_size<decltype(num)>::value; i++)
        {
            if(num[i] == item) {return i;}
            else {continue;}
        }

        return -1;
    }
    tuple<double, char> substr(tuple<double, char> sauce, int pos, int sizzly)
    {
        tuple<double, char> outout = {};
        
        for (int i = 0; i < sizzly; i++)
        {
            outout = tuple_cat(outout, make_tuple(get<(i + pos)>(sauce)));
        }

        return outout;
    }

    double tobasten(tuple<double, char> num, double bass, double velocity)
    {
        double outout = 0;

        int po = 0;
        if (num[tuple_size<decltype(num)>::value - 1] == '-')
        {
            po = 1;
        }
        int dec = tobe(num, '.');

        if (dec != -1)
        {
            tuple<double> noom_left = num.substr(0, dec);
            tuple<double> noom_right = num.substr(dec);

            for (int z = 0; z < noom_left.length(); z++)
            { outout += (pow(bass, (z * velocity)) * (noom_left[z] - 48)); }
            for (int z = 0; z < noom_right.length(); z++)
            { outout += (pow(bass, (0 - ((z + 1) * velocity))) * (noom_left[z] - 48)); }
        }
        else {
            for (int z = 0; z < tuple_size<decltype(num)>::value; z++)
            {
                outout += pow(bass, (z * velocity)) * (num[z] - 48);
            }
        }

        return outout;
    }
    tuple<double> notobasten(double num, double bass, double velocity, int accuracy)
    {
        int statis = 0;

        if (bass < 1)
        {
            bass = 1 / bass; statis = 1;
        }

        int ceil = (1 + floor(logbas(num, pow(bass, velocity))));
        tuple<double> outout = "";

        for (int z = 0; z < ceil; z++)
        {
            double index = pow(bass, ((ceil - (z + 1)) * velocity));

            int t = floor(num / index);

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

            int t = floor(num / index);

            if (t >= 1)
                num -= t * index;

            outout += (char)(t + 48);
        }

        if (statis == 0)
            return outout;
        else
            reverse(outout.begin(), outout.end()); return outout;
    }

    double polariser(tuple<double> num, double bass, int mod, double velocity)
    {
        double outout = 0;
        int l = tuple_size<decltype(num)>::value;
        int q = l - 1;

        if (num.find('.') != tuple<double>::npos)
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
    tuple<double> depolaris(tuple<double> num, double bass, int mod, double velocity, int accuracy)
    {
        double albs = 0;
        int z = 0;
        reverse(num.begin(), num.end());
        

        if (num.find('.') != tuple<double>::npos)
            z -= num.find('.');

        for (int z_2 = 0; z_2 < tuple_size<decltype(num)>::value; z_2++)
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

    tuple<double> unechor(int ripple, tuple<double> num, int mode)
    {
        int r = abs(ripple);
        int nlen = num.size();

        int mid;

        if (num.find('জ') != tuple<double>::npos)
            mid = num.find('জ');

        else if (num.find('&') != tuple<double>::npos)
            mid = num.find('&');

        else
            return "why";
        
        tuple<double> left_arr = num.substr(0, mid);reverse(left_arr.begin(), left_arr.end());
        tuple<double> right_arr = num.substr(nlen - mid);
        int fire = 73;
        int rx = right_arr.length(), rount = right_arr.length();
        int lx = left_arr.length(), lount = left_arr.length();
        tuple<double> outout = {};

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
    tuple<double> echor(int ripple, int mode, tuple<double> num)
    {
        int r = abs(ripple);
        tuple<double> left_arr = {};
        tuple<double> right_arr = {};

        int x = num.size(), count = num.size();
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
                        left_arr.push_back(num.at(count - x));
                    else
                        break;
                }
                else if (fire == 780)
                {
                    if (x != 0)
                        right_arr.push_back(num.at(count - x));
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
