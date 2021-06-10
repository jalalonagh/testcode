using ManaAutoMapper.Interfaces;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile.FavoriteProduct
{
    public class FavoriteProductDTO : BaseDTO<FavoriteProductDTO, Entities.Profile.FavoriteProduct.FavoriteProduct, int>, IHaveCustomMapping
    {
        public int ProductId { get; set; }
        public int ProfileId { get; set; }
    }
}