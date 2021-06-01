﻿using ManaViewModel.Common;

namespace ManaViewModel.Profile.FavoriteProduct
{
    public class FavoriteProductVM : BaseVM<FavoriteProductVM, Entities.Profile.FavoriteProduct.FavoriteProduct, int>
    {
        public int ProductId { get; set; }
        public int ProfileId { get; set; }
        public ProfileVM Profile { get; set; }
    }
}