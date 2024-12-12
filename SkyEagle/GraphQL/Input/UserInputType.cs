using GraphQL.Types;

namespace zalo_server.SkyEagle.GraphQL.Input
{
   public class UserInputType : InputObjectGraphType
{
    public UserInputType()
    {
        Name = "UserInput";
        Field<StringGraphType>("Name");
        Field<StringGraphType>("SDT");
        Field<StringGraphType>("UID");
        Field<StringGraphType>("Avatar");

        }
}

}
