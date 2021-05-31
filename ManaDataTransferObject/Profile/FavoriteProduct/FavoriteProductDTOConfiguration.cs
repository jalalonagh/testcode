using AutoMapper;
using ManaDataTransferObject.Common;

namespace ManaDataTransferObject.Profile.FavoriteProduct
{
    internal class FavoriteProductDTOConfiguration : BaseDTO<FavoriteProductDTO, Entities.Profile.FavoriteProduct.FavoriteProduct, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.FavoriteProduct.FavoriteProduct, FavoriteProductDTO> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}