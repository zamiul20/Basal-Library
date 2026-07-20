namespace Calculator;

public partial class Expander_Page : ContentPage
{
	public Expander_Page()
	{
		InitializeComponent();
	}

    string selec = "None";

    string inbas = "< 10 T";
    string onbas = "T 10 >";
    string ansbas = "< 10 T";
    object[] innum = new object[] { };
    string innum_d = "";

    Basal leinbas = new Basal(10, 2, 0, 2, 2, 1);
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
        indicat_updat("Ascending Base Selected");
        selec = "inbas";
        leinput.Text = inbas;
    }
    public void onbas_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Descending Base Selected");
        selec = "onbas";
        leinput.Text = onbas;
    }
    public void innum_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Number Selected");
        selec = "innum";
        leinput.Text = innum_d;
    }
    public void ansbas_sel(object? sender, EventArgs e)
    {
        sette(sender, e);
        indicat_updat("Output Base Selected");
        selec = "outbas";
        leinput.Text = ansbas;
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
            case "outbas":
                ansbas = leinput.Text;
                break;
        }
    }
    #endregion

    public void conver(object? sender, EventArgs e)
    {
        sette(sender, e);
        if (ansbas.Length > 2)
        {
            string[] x = ansbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            leoutbas.base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                leoutbas.polar = 0;
            else if (x.Contains("দ"))
                leoutbas.polar = 1;
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

            if (x.Contains("স"))
            {
                leoutbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            ansbas_but.Text = $"Output Base - {leoutbas.disp()}";
        }
        else { indicat.Text = "Output Base not defined"; }

        if (inbas.Length > 2)
        {
            string[] x = inbas.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToArray();

            leinbas.base_value = double.Parse(x[1]);

            if (x.Contains("ঋ"))
                leinbas.polar = 0;
            else if (x.Contains("দ"))
                leinbas.polar = 1;
            else leinbas.polar = 2;

            if (x.Contains("+ল"))
            {
                leinbas.echo = 0;
                leinbas.ripple = int.Parse(x[x.IndexOf("+ল") + 1]);
            }
            else if (x.Contains("-ল"))
            {
                leinbas.echo = 1;
                leinbas.ripple = int.Parse(x[x.IndexOf("-ল") + 1]);
            }
            else leinbas.echo = 2;

            if (x.Contains("স"))
            {
                leinbas.velocity = double.Parse(x[x.IndexOf("স") + 1]);
            }
            inbas_but.Text = $"Ascending Base - {leinbas.disp()}";
        }
        else { indicat.Text = "Ascending Base not defined"; }

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
            onbas_but.Text = $"{leonbas.bisp()} - Descending Base";
        }
        else { indicat.Text = "Descending Base not defined"; }

        double val = leoutbas.expan(innum, leinbas, leonbas);

        leoutbas = new Basal(val, leoutbas.base_value, leoutbas.polar, leoutbas.discretion, leoutbas.echo, leoutbas.ripple, leoutbas.velocity);

        num_disp.Text = $"Output Number in {leoutbas.display} ⟶" + String.Join(' ', leoutbas.number);
    }
}