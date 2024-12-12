using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using zalo_server.SkyEagle.GraphQL.Type;
using zalo_server.SkyModel;

namespace zalo_server.SkyEagle.GraphQL
{
    public class Query : ObjectGraphType
    {
        public Query(ApplicationDbContext dbContext)
        {
            // Truy vấn kiểm tra kết nối server
            Field<StringGraphType>(
                "ping",
                resolve: context => "Pong"
            );
            // Truy vấn dữ liệu từ bảng Categories với phân trang
            Field<ListGraphType<CategoryType>>(
                "categories",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "take", DefaultValue = 10 }
                ),
                resolve: context =>
                {
                    int skip = context.GetArgument<int>("skip");
                    int take = context.GetArgument<int>("take");

                    return dbContext.Categories.Skip(skip).Take(take).ToList();
                }
            );

            // Truy vấn Products với phân trang
            Field<ListGraphType<ProductType>>(
                "products",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "take", DefaultValue = 10 }
                ),
                resolve: context =>
                {
                    int skip = context.GetArgument<int>("skip");
                    int take = context.GetArgument<int>("take");

                    return dbContext.Products.Skip(skip).Take(take).ToList();
                }
            );

            // Truy vấn Users với phân trang
            Field<ListGraphType<UserType>>(
                "users",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "skip", DefaultValue = 0 },
                    new QueryArgument<IntGraphType> { Name = "take", DefaultValue = 10 }
                ),
                resolve: context =>
                {
                    int skip = context.GetArgument<int>("skip");
                    int take = context.GetArgument<int>("take");

                    return dbContext.Users.Skip(skip).Take(take).ToList();
                }
            );

            // Thêm trường totalProducts để trả về tổng số bản ghi của Products
            Field<IntGraphType>(
                "totalProducts",
                resolve: context => dbContext.Products.Count()
            );

             // Truy vấn tất cả các chi tiết
            Field<ListGraphType<DetailType>>(
                "details",
                resolve: context => dbContext.Details.ToList()
            );

            // Truy vấn chi tiết theo ID
            Field<DetailType>(
                "detail",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return dbContext.Details.FirstOrDefault(d => d.Id == id);
                }
            );
        }
    }
}
