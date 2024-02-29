using Microsoft.AspNetCore.Http;

namespace Application.Core.Stores.Commands.CreateStore;

public record CreateStoreCommandRequestDTO(string Name, string Description, string Currency, string? Location, IFormFile? StoreImage);
