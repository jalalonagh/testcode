using AutoMapper;
using ManaViewModel.Common;

namespace ManaViewModel.Profile.FavoriteProduct
{
    internal class FavoriteProductVMConfiguration : BaseVM<FavoriteProductVM, Entities.Profile.FavoriteProduct.FavoriteProduct, int>
    {
        public override void CustomMappings(IMappingExpression<Entities.Profile.FavoriteProduct.FavoriteProduct, FavoriteProductVM> mapping)
        {
            //mapping.ForMember(x => x.Qty, y => y.MapFrom(c => c.Quantity));
        }
    }
}