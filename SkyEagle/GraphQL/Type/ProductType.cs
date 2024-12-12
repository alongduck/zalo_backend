using GraphQL.Types;
using zalo_server.SkyModel;

namespace zalo_server.SkyEagle.GraphQL
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id).Description("ID of the product");
            Field(x => x.Name).Description("Name of the product");
            Field(x => x.Thumbnail).Description("Thumbnail of the product");
            Field(x => x.Price).Description("Price of the product");
            Field(x => x.TimeUp).Description("Time when the product was uploaded");
            Field(x => x.CategoryId).Description("ID of the category");
            Field(x => x.DetailId).Description("ID of the detail");
            Field(x => x.Hot).Description("Is the product hot?");
            Field(x => x.UserId).Description("ID of the user");

        }
    }
}
