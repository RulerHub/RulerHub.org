
using RulerHub.Shared.DataTransferObjects.Item;
using RulerHub.Shared.DbModels;

namespace RulerHub.Shared.Mappers;

public static class ItemMapper
{
    public static ItemDto ToItemDto(this ItemModel item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Code = item.Code,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Quantity = item.Quantity,
            IsInStock = item.IsInStock,
            //Categories = item.Categories.Select(c => c.ToCategoryDto()).ToList(),
        };
    }
    public static ItemModel ToItemFromCreateDto(this CreateItemDto create)
    {
        return new ItemModel
        {
            Code = create.Code,
            Name = create.Name,
            Description = create.Description,
            Price = create.Price,
        };
    }
}
