using GraphQL.Types;
using zalo_server.SkyModel;

namespace zalo_server.SkyEagle.GraphQL.Type
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
      
            Field(x => x.Name).Description("Name of the user");
            Field(x => x.SDT).Description("Phone number of the user");
            Field(x => x.UID).Description("UID of the user");
            Field(x => x.Avatar).Description("avatar of the user");
        }
    }
}
