namespace StoreApp.SearchServiceAPI.DTOS;
public class BarcodeDTO
{
    // public properties : 
    public int Id { get; set; }
    public string ? Code { get; set; }
    public decimal TotalPrice { get; set; }
    public string ? ProductName { get; set; }
    public decimal Volume { get; set; }
    public string ? ImageUrl { get; set; }
}
