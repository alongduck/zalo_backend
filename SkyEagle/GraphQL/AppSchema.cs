using GraphQL.Types;

namespace zalo_server.SkyEagle.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            // Đảm bảo rằng bạn đã thêm Mutation vào Schema
            Query = provider.GetRequiredService<Query>();
            Mutation = provider.GetRequiredService<Mutation>();  // Đảm bảo rằng Mutation được inject đúng
        }
    }
}
