#include <iostream>
#include <string>
#include <cmath>
#include <vector>
#include <variant>
#include <algorithm>

using namespace std;
using numbas_model = vector<variant<double, char>>;

class Basal
{
public:
    int echo = 2, ripple = 0, polar = 2, discretion = 0, accuracy = 30;
    double velocity = 1;

    double num_value = 0;
    double base_value = 10;
    numbas_model number = {};
    string display = "<10T";

    Basal() {}
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
    Basal(numbas_model num, double bass, double vel, int pol, int dis, int eco, int rip_val, int acc)
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
    void Deconvert(numbas_model number)
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

    int tobe(numbas_model num, char item)
    {
        for (int i = 0; i < num.size(); i++)
        {
            if (get<char>(num[i]) == item) { return i; }
            else { continue; }
        }

        return -1;
    }
    numbas_model substr(numbas_model sauce, int pos, int sizzly)
    {
        numbas_model outout = {};

        for (int i = 0; i < sizzly; i++)
        {
            outout.emplace_back(sauce.at(i + pos));
        }

        return outout;
    }

    double tobasten(numbas_model num, double bass, double velocity)
    {
        double outout = 0;

        int po = 0;
        if (get<char>(num[num.size() - 1]) == '-')
        {
            po = 1;
        }
        int dec = tobe(num, '.');

        if (dec != -1)
        {
            numbas_model noom_left = substr(num, 0, dec);
            numbas_model noom_right = substr(num, dec, num.size() - dec);

            for (int z = 0; z < noom_left.size(); z++)
            {
                outout += (pow(bass, (z * velocity)) * get<double>(noom_left[z]));
            }
            for (int z = 0; z < noom_right.size(); z++)
            {
                outout += (pow(bass, (0 - ((z + 1) * velocity))) * get<double>(noom_right[z]));
            }
        }
        else {
            for (int z = 0; z < num.size(); z++)
            {
                outout += pow(bass, (z * velocity)) * get<double>(num[z]);
            }
        }

        return outout;
    }
    numbas_model notobasten(double num, double bass, double velocity, int accuracy)
    {
        int statis = 0;

        if (bass < 1)
        {
            bass = 1 / bass; statis = 1;
        }

        int ceil = (1 + floor(logbas(num, pow(bass, velocity))));
        numbas_model outout = {};

        for (int z = 0; z < ceil; z++)
        {
            double index = pow(bass, ((ceil - (z + 1)) * velocity));

            int t = floor(num / index);

            if (t >= 1)
            {
                num -= (t * index);
            }

            outout.emplace_back(t);
        }

        if (num == 0)
        {
            if (statis == 0)
                return outout;
            else
                outout.emplace_back(0); outout.emplace_back('.'); reverse(outout.begin(), outout.end());  return outout;
        }
        outout.emplace_back('.');

        for (int z = 0; z < (accuracy - ceil); z++)
        {
            if (num == 0)
                return outout;

            double index = pow(bass, ((0 - (z + 1)) * velocity));

            int t = floor(num / index);

            if (t >= 1)
                num -= t * index;

            outout.emplace_back(t);
        }

        if (statis == 0)
            return outout;
        else
            reverse(outout.begin(), outout.end()); return outout;
    }

    double polariser(numbas_model num, double bass, int mod, double velocity)
    {
        double outout = 0;
        int l = num.size();
        int q = l - 1;

        if (tobe(num, '.') != -1)
            q -= tobe(num, '.');

        for (int z = 0; z < l; z++)
        {
            if (get<char>(num[z]) == '.')
                continue;

            q--;

            if (z % 2 == mod)
                outout += get<double>(num[z]) * pow(bass, (q * velocity));
            else
                outout -= get<double>(num[z]) * pow(bass, (q * velocity));
        }
        return outout;
    }
    numbas_model depolaris(numbas_model num, double bass, int mod, double velocity, int accuracy)
    {
        double albs = 0;
        int z = 0;
        reverse(num.begin(), num.end());


        if (tobe(num, '.' != -1))
            z -= tobe(num, '.');

        for (int z_2 = 0; z_2 < num.size(); z_2++)
        {
            if (get<char>(num[z]) == '.')
                continue;

            z += 1;

            if (get<double>(num[z]) != 0)
                albs += pow(bass, ((z + 1) * velocity)) + ((bass - (2 * get<double>(num[z]))) * pow(bass, (z * velocity)));
        }

        reverse(num.begin(), num.end());

        return notobasten(tobasten(num, bass, velocity) + albs, bass, velocity, accuracy);
    }

    numbas_model unechor(int ripple, numbas_model num, int mode)
    {
        int r = abs(ripple);
        int nlen = num.size();

        int mid;

        if (tobe(num, 'জ') != -1)
            mid = tobe(num, 'জ');

        else if (tobe(num, '&') != -1)
            mid = tobe(num, '&');

        else
            return {'w', 'h', 'y'};

        numbas_model left_arr = substr(num, 0, mid); reverse(left_arr.begin(), left_arr.end());
        numbas_model right_arr = substr(num, nlen - mid, num.size() - (nlen + mid));
        int fire = 73;
        int rx = right_arr.size(), rount = right_arr.size();
        int lx = left_arr.size(), lount = left_arr.size();
        numbas_model outout = {};

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

                    outout.emplace_back(right_arr[rount - rx]);
                    rx--;
                }
                fire = 780;
            }

            else if (fire == 780)
            {
                for (int z_2 = 0; z_2 < r; z_2++)
                {
                    if (lx == 0)
                        break;

                    outout.emplace_back(left_arr[lount - lx]);
                    lx--;
                }
                fire = 73;
            }
        }
        reverse(outout.begin(), outout.end());
        return outout;
    }
    numbas_model unechor(int ripple, numbas_model num, int mode, int mid)
    {
        int r = abs(ripple);
        int nlen = num.size();

        numbas_model left_arr = substr(num, 0, mid); reverse(left_arr.begin(), left_arr.end());
        numbas_model right_arr = substr(num, nlen - mid, num.size() - (nlen + mid));
        int fire = 73;
        int rx = right_arr.size(), rount = right_arr.size();
        int lx = left_arr.size(), lount = left_arr.size();
        numbas_model outout = {};

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

                    outout.emplace_back(right_arr[rount - rx]);
                    rx--;
                }
                fire = 780;
            }

            else if (fire == 780)
            {
                for (int z_2 = 0; z_2 < r; z_2++)
                {
                    if (lx == 0)
                        break;

                    outout.emplace_back(left_arr[lount - lx]);
                    lx--;
                }
                fire = 73;
            }
        }
        reverse(outout.begin(), outout.end());
        return outout;
    }
    numbas_model echor(int ripple, int mode, numbas_model num)
    {
        int r = abs(ripple);
        numbas_model left_arr = {};
        numbas_model right_arr = {};

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
                        left_arr.emplace_back(num.at(count - x));
                    else
                        break;
                }
                else if (fire == 780)
                {
                    if (x != 0)
                        right_arr.emplace_back(num.at(count - x));
                    else
                        break;
                }
                x--;
            }
        }

        if (ripple < 0)
            reverse(right_arr.begin(), right_arr.end());
        else
            reverse(left_arr.begin(), left_arr.end());

        left_arr.emplace_back('জ');
        left_arr.reserve(left_arr.size() + right_arr.size());
        left_arr.insert(left_arr.end(), right_arr.begin(), right_arr.end());
        return left_arr;
    }
};

int main()
{
    Basal bass;

    cout << bass.base_value;
}
