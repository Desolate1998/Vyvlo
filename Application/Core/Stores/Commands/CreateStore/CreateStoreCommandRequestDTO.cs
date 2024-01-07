namespace Application.Core.Store.Commands.CreateStore;

public class CreateStoreCommandRequestDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long OwnerId { get; set; }
}
