using System.Reflection.Emit;

class Order
{
    public string CustomerName { get; set; }
    public string FlowerName { get; set; }
    public string FlowerColor { get; set; }
    public string FlowerOriginCounty { get; set; }
    public int Price { get; set; }
    public DateTime OrderDateTime { get; set; }
    public DateTime PickupDate { get; set; }

    public override string ToString() =>
        $"\tmegrendelő neve: {CustomerName}\n" +
        $"\trendelt virág: {FlowerName}\n" +
        $"\trendelt virág színe: {FlowerColor}\n" +
        $"\tvirág származási helye: {FlowerOriginCounty}\n" +
        $"\trendelés ára: {Price} HUF\n" +
        $"\trendelés ideje: {OrderDateTime:yyyy. MM. dd. HH:mm}\n" +
        $"\tátvétel napja: {PickupDate:yyyy. MM. dd.}";

    public Order(string row)
    {
        var tmp = row.Split(',');
        CustomerName = tmp[0];
        FlowerName = tmp[1];
        FlowerColor = tmp[2];
        FlowerOriginCounty = tmp[3];
        Price = int.Parse(tmp[4]);
        OrderDateTime = DateTime.Parse(tmp[5]);
        PickupDate = DateTime.Parse(tmp[6]);
    }
}