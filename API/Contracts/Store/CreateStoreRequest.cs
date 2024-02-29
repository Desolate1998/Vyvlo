namespace API.Contracts.Store;

public class CreateStoreRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IFormFile StoreImage { get; set; }
    public string Currency { get; set; }
    public string Location { get; set; }
}
