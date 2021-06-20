using ManaBaseEntity.Common;

namespace Entities.Profile.FavoriteProduct
{
    public class FavoriteProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}