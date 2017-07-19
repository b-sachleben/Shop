using Shop.Models;
using System.Data.Entity;

namespace Shop.DataAccessLayer
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var categoryPhotoPrint = new Category()
            {
                Name = "Photo Print"
            };

            var categoryArtPrint = new Category()
            {
                Name = "Art Print"
            };

            var categoryOriginalPainting = new Category()
            {
                Name = "Original Painting"
            };

            context.SaveChanges();
        }
    }
}