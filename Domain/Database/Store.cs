using Common.DateTimeProvider;
using Common.EnumCode;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Domain.Database;

public sealed class Store
{
    private Store(long storeOwnerId,
                  string storeName,
                  string? storeAddress,
                  string? storePhoneNumber,
                  string? storeEmail,
                  string storeDescription,
                  string currency)
    {
        OwnerId = storeOwnerId;
        Name = storeName;
        Address = storeAddress;
        PhoneNumber = storePhoneNumber;
        Email = storeEmail;
        Description = storeDescription;
        CreatedAt = DateTimeProvider.ApplicationDate;
        StoreStatusCode = Enums.StoreStatus.PendingActivation.GetCode();
        Currency = currency;
    }
    public Store() { }

    public long Id { get; private set; }
    public long OwnerId { get; private set; }
    public string Name { get; private set; }
    public string? Address { get; private set; }
    public string StoreStatusCode {  get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Email { get; private set; }
    public string Description { get; private set; }
    public string Currency { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public User Owner { get; set; }
    public StoreStatus StoreStatus { get; set; }
    public ICollection<Product> Products { get; set; } 
    public IEnumerable<ProductMetaTag> ProductMetaTags { get; set; }
    public static Store CreateStore(long storeOwnerId,
                                    string storeName,
                                    string storeDescription,
                                    string currency,
                                    string? storeAddress = null,
                                    string? storePhoneNumber = null,
                                    string? storeEmail = null)
    {
        return new Store(storeOwnerId, storeName, storeAddress, storePhoneNumber, storeEmail, storeDescription,currency);
    }
}
