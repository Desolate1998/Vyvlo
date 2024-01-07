using Common.DateTimeProvider;
using Common.EnumCode;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Domain.Database;

public class Store
{
    private Store(long storeOwnerId,
                  string storeName,
                  string? storeAddress,
                  string? storePhoneNumber,
                  string? storeEmail,
                  string storeDescription)
    {
        OwnerId = storeOwnerId;
        Name = storeName;
        Address = storeAddress;
        PhoneNumber = storePhoneNumber;
        Email = storeEmail;
        Description = storeDescription;
        CreatedAt = DateTimeProvider.ApplicationDate;
        StoreStatusCode = Enums.StoreStatus.PendingActivation.GetCode();
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
    public DateTime CreatedAt { get; private set; }
    public  virtual User Owner { get; set; }
    public virtual StoreStatus StoreStatus { get; set; }
    public virtual ICollection<Product> Products { get; set; } 

    public static Store CreateStore(long storeOwnerId,
                                    string storeName,
                                    string storeDescription,
                                    string? storeAddress = null,
                                    string? storePhoneNumber = null,
                                    string? storeEmail =null)
    {
        return new(storeOwnerId, storeName, storeAddress, storePhoneNumber, storeEmail, storeDescription);
    }
}
