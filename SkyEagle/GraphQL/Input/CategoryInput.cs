using GraphQL.Types;

namespace zalo_server.SkyEagle.GraphQL.Input
{
   public class CategoryInput : InputObjectGraphType
{
    public CategoryInput()
    {
        Name = "CategoryInput";
        Field<StringGraphType>("ID");
        Field<StringGraphType>("Name");
        Field<StringGraphType>("Icon");
        Field<StringGraphType>("TotalProduct");

    }
}

}
