using GraphQL.Types;

namespace zalo_server.SkyEagle.GraphQL.Input
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Name = "ProductInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("thumbnail");
            Field<NonNullGraphType<FloatGraphType>>("price");
            Field<NonNullGraphType<StringGraphType>>("timeUp");
            Field<NonNullGraphType<IntGraphType>>("categoryId");
            Field<NonNullGraphType<IntGraphType>>("userId");
            Field<BooleanGraphType>("hot");
        }
    }
}
