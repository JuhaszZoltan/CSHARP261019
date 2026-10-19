using Diacritics.Extensions;
using MySql.Data.MySqlClient;

namespace FlowerShopGUI;

public partial class FrmFlowerShopGUI : Form
{
    const string ConnStr = "server=127.0.0.1;database=viraguzlet;uid=root;pwd=";

    public FrmFlowerShopGUI()
    {
        InitializeComponent();
        this.Load += FrmFlowerShopGUILoad;
        dgv.CellClick += DgvCellClick;
    }

    private void DgvCellClick(object? sender, DataGridViewCellEventArgs e)
    {

        string filename = $"{dgv[1, e.RowIndex].Value}_{dgv[2, e.RowIndex].Value}".RemoveDiacritics().ToLower();

        if (File.Exists($"..\\..\\..\\imgs\\{filename}.jpg") )
        {
            pb.Image = Image.FromFile($"..\\..\\..\\imgs\\{filename}.jpg");
        }
        else pb.Image = Image.FromFile("..\\..\\..\\imgs\\placeholder.png");
    }

    private void FrmFlowerShopGUILoad(object? sender, EventArgs e)
    {
        dgv.Rows.Clear();

        using MySqlConnection connection = new(ConnStr);
        connection.Open();

        MySqlDataReader reader = new MySqlCommand(
            "SELECT " +
                "vevo.nev AS megrendelo, " +
                "virag.vnev AS virag, " +
                "virag.szin AS szin, " +
                "(rendeles.rendelesi_egysegar * rendeles.mennyiseg) AS ar, " +
                "rendeles.atveteldatum AS atvetel, " +
                "virag.kepurl AS url " +
            "FROM vevo " +
                "INNER JOIN rendeles ON vevo.vevoid = rendeles.vevoid " +
                "INNER JOIN virag ON rendeles.viragid = virag.viragid;", 
            connection).ExecuteReader();

        while(reader.Read())
        {
            dgv.Rows.Add(
                reader["megrendelo"],
                reader["virag"],
                reader["szin"],
                $"{(ulong)reader["ar"]:N0} Ft",
                $"{(DateTime)reader["atvetel"]:yyyy. MM. dd.}",
                reader["url"]);
        }
    }
}
