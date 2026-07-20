using System.ComponentModel.Design;

namespace Calculator;

public partial class Fabric_Page : ContentPage
{
	public Fabric_Page()
	{
		InitializeComponent();
	}

    string selec = "None";

    string inbas = "< 10 T";
    string onbas = "< 10 T";
    object[] innum = new object[] { };
    string innum_d = "";

    string beginum = "", stepnum = "", endnum = "";

    Basal leonbas = new Basal(10, 2, 0, 2, 2, 1);
    Basal leoutbas = new Basal(10, 2, 0, 2, 2, 1);

    public static object[] Red__Sea(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Array.Empty<object>();

        try
        {
            return input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(token => {
                        if (int.TryParse(token, out int intValue)) return (object)intValue;
                        if (double.TryParse(token, out double doubleValue)) return (object)doubleValue;
                        if (token.Length == 1) return (object)token[0];
                        return (object)token;
                    })
                    .ToArray();
        }
        catch
        {
            return ['w', 'h', 'y'];
        }

    }

    #region SET AND SELECT
    public void add_ente_n(object? sender, EventArgs e)
    {
        leinput.Text += 'ঋ';
    }
    public void add_ente_dis(object? sender, EventArgs e)
    {
        leinput.Text += 'গ';
    }
    public void add_ente_dn(object? sender, EventArgs e)
    {
        leinput.Text += 'দ';
    }
    public void add_ente_pr(object? sender, EventArgs e)
    {
        leinput.Text += "+ল";
    }
    public void add_ente_nr(object? sender, EventArgs e)
    {
        leinput.Text += "-ল";
    }
    public void add_ente_vel(object? sender, EventArgs e)
    {
        leinput.Text += 'স';
    }
    public void add_ente_rip(object? sender, EventArgs e)
    {
        leinput.Text += 'জ';
    }

    public void inbas_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Function Base Selected");
        selec = "inbas";
        leinput.Text = inbas;
    }
    public void onbas_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Projection Base Selected");
        selec = "onbas";
        leinput.Text = onbas;
    }
    public void innum_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Polynomial Selected");
        selec = "innum";
        leinput.Text = innum_d;
    }
    public void beginum_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Startpoint Selected");
        selec = "beginum";
        leinput.Text = beginum;
    }
    public void stepnum_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Step Selected");
        selec = "stepnum";
        leinput.Text = stepnum;
    }
    public void endnum_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Endpoint Selected");
        selec = "endnum";
        leinput.Text = endnum;
    }


    public void indicat_updat(string s)
    {
        indicat.Text = s;
    }


    public void sette(object? sender, EventArgs e)
    {
        switch (selec)
        {
            case "inbas":
                inbas = leinput.Text;
                break;
            case "onbas":
                onbas = leinput.Text;
                break;
            case "innum":
                innum_d = leinput.Text;
                innum = Red__Sea(leinput.Text);
                break;
            case "beginum":
                beginum = leinput.Text;
                break;
            case "endnum":
                endnum = leinput.Text;
                break;
            case "stepnum":
                stepnum = leinput.Text;
                break;
        }
    }
    #endregion

    public void conver(object? sender, EventArgs e)
    {
        sette(sender, e);
        if (inbas.Length > 2)
        {
            string[] x = inbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            leoutbas.base_value = double.Parse(x[1]);

            if (x.Contains("ঋ")) leoutbas.polar = 0;
            else if (x.Contains("দ")) leoutbas.polar = 1;
            else leoutbas.polar = 2;

            if (x.Contains("+ল"))
            {
                leoutbas.echo = 0;
                leoutbas.ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                leoutbas.echo = 1;
                leoutbas.ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else leoutbas.echo = 2;

            if (x.Contains("স")) leoutbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            leoutbas.disp();
            inbas_but.Text = $"Projection Base - {leoutbas.display}";
        }
        else { indicat.Text = "Projection Base not defined"; }

        if (onbas.Length > 2)
        {
            string[] x = onbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            leonbas.base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                leonbas.polar = 0;
            else if (x.Contains("দ"))
                leonbas.polar = 1;
            else leonbas.polar = 2;

            if (x.Contains("+ল"))
            {
                leonbas.echo = 0;
                leonbas.ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                leonbas.echo = 1;
                leonbas.ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else leonbas.echo = 2;

            if (x.Contains("স"))
            {
                leonbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            leonbas.disp();
            onbas_but.Text = $"Function Base - {leonbas.display}";
        }
        else { indicat.Text = "Function Base not defined"; }

        double start = 0, end = 0, step = 0;
        try
        {
            innum = Red__Sea(innum_d);
            step = Double.Parse(stepnum); start = Double.Parse(beginum); end = Double.Parse(endnum);
            step_but.Text = $"Step - {stepnum}"; begin_but.Text = $"Begin - {beginum}"; end_but.Text = $"End - {endnum}";
        }
        catch { num_disp.Text = "Invalid inputs"; return; }
        List<object> outout = new List<object> { }; object[] temp = innum;

        if (leonbas.echo != 2) temp = leonbas.unechor(leonbas.ripple, temp, leonbas.echo);

        if (start == end) num_disp.Text = "Why?";

        else if (start < end)
        {
            if (leonbas.polar != 2) for (double z = start; z <= end; z += step)
                outout.Add(leonbas.polaris(temp, z, leonbas.velocity, leonbas.polar));
            else
            {
                temp = temp.Reverse().ToArray();
                for (double z = start; z <= end; z += step) 
                    outout.Add(leonbas.tobasten(temp, z, leonbas.velocity));
            }

            temp = outout.ToArray().Reverse().ToArray();
            leoutbas = new Basal(temp, leoutbas.base_value, leoutbas.polar, leoutbas.discretion, leoutbas.echo, leoutbas.ripple, leoutbas.velocity);

            num_disp.Text = ($"Output sequence : {String.Join(' ', outout)} ⟶ {leoutbas.value}");
        }
        else
        {
            if (leonbas.polar != 2) for (double z = start; z >= end; z -= step)
                outout.Add(leonbas.polaris(temp, z, leonbas.velocity, leonbas.polar));
            else
            {
                temp = temp.Reverse().ToArray();
                for (double z = start; z >= end; z -= step)
                    outout.Add(leonbas.tobasten(temp, z, leonbas.velocity));
            }

            temp = outout.ToArray().Reverse().ToArray();
            leoutbas = new Basal(temp, leoutbas.base_value, leoutbas.polar, leoutbas.discretion, leoutbas.echo, leoutbas.ripple, leoutbas.velocity);

            num_disp.Text = ($"Output sequence : {String.Join(' ', outout)} ⟶ {leoutbas.value}");
        }
    }
}