using GraphQL.Types;

namespace zalo_server.SkyEagle.GraphQL.Input
{
   public class DetailInputType : InputObjectGraphType
{
    public DetailInputType()
    {
        Name = "DetailInput";
        Field<StringGraphType>("description");
        Field<StringGraphType>("address");
        Field<NonNullGraphType<ListGraphType<StringGraphType>>>("features");
        Field<NonNullGraphType<ListGraphType<StringGraphType>>>("details");
        Field<NonNullGraphType<ListGraphType<StringGraphType>>>("images");
    }
}

}
