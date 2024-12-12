using GraphQL.Types;
using zalo_server.SkyModel;

namespace zalo_server.SkyEagle.GraphQL.Type
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType()
        {
            Field(x => x.ID).Description("ID of the category");
            Field(x => x.Name).Description("Name of the category");
            Field(x => x.Icon).Description("Icon of the category");
            Field(x => x.TotalProduct).Description("Total product in category");
        }
    }
}
