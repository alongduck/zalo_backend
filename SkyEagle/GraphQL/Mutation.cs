using GraphQL.Types;
using zalo_server.SkyModel;
using zalo_server.SkyEagle.GraphQL.Input;
using System;
using GraphQL;
using Newtonsoft.Json;
using zalo_server.SkyEagle.GraphQL.Type;

namespace zalo_server.SkyEagle.GraphQL
{
    public class Mutation : ObjectGraphType
    {
        public Mutation(ApplicationDbContext dbContext)
        {
            // Mutation to create product with detail
            Field<ProductType>(
                "createProductWithDetail",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" },
                    new QueryArgument<NonNullGraphType<DetailInputType>> { Name = "detail" }
                ),
                resolve: context =>
                {
                    var productInput = context.GetArgument<Product>("product");
                    var detailInput = context.GetArgument<Detail>("detail");

                    // Create the product detail
                    var detail = new Detail
                    {

                        Description = detailInput.Description,
                        Features = detailInput.Features,
                        Address = detailInput.Address,
                        Details = detailInput.Details,
                        Images = detailInput.Images
                    };
                    dbContext.Details.Add(detail);
                    dbContext.SaveChanges();

                    // Create the product and link it to the created detail
                    var product = new Product
                    {
                        Name = productInput.Name,
                        Thumbnail = productInput.Thumbnail,
                        Price = productInput.Price,
                        TimeUp = productInput.TimeUp,
                        CategoryId = productInput.CategoryId,
                        DetailId = detail.Id,  // Link to the new detail
                        Hot = productInput.Hot,
                        UserId = productInput.UserId
                    };
                    dbContext.Products.Add(product);
                    dbContext.SaveChanges();

                    return product;
                }
            );
            Field<CategoryType>(
                "createCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CategoryInput>> { Name = "category" }

                ),
                resolve: context =>
                {
                    var categoryInput = context.GetArgument<Category>("category");
                   

                    // Create the product detail
                    var Category = new Category
                    {
                        ID = categoryInput.ID,
                        Name = categoryInput.Name,
                        Icon = categoryInput.Icon,
                        TotalProduct = categoryInput.TotalProduct,
             
                    };
                    dbContext.Categories.Add(Category);
                    dbContext.SaveChanges();

                    return Category;
                }
            );
                Field<UserType>(
           "createUser",
           arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }

           ),
           resolve: context =>
           {
               var userInput = context.GetArgument<User>("user");


               // Create the product detail
               var user = new User
               {
              
                   Name = userInput.Name,
                   SDT = userInput.SDT,
                   UID = userInput.UID,
                   Avatar = userInput.Avatar,

               };
               dbContext.Users.Add(user);
               dbContext.SaveChanges();

               return user;
           }
       );
            Field<BooleanGraphType>(
    "deleteCategory",
    arguments: new QueryArguments(
        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "categoryId" }
    ),
    resolve: context =>
    {
        var categoryId = context.GetArgument<int>("categoryId");

        // Tìm danh mục theo ID
        var category = dbContext.Categories.Find(categoryId);
        if (category == null)
        {
            context.Errors.Add(new ExecutionError("Category not found."));
            return false;
        }

        // Xóa danh mục
        dbContext.Categories.Remove(category);
        dbContext.SaveChanges();

        return true; // Trả về true nếu xóa thành công
    }
);
            Field<CategoryType>(
                "updateCategory",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "categoryId" },
                    new QueryArgument<NonNullGraphType<CategoryInput>> { Name = "category" }
                ),
                resolve: context =>
                {
                    var categoryId = context.GetArgument<int>("categoryId");
                    var categoryInput = context.GetArgument<Category>("category");

                    // Tìm danh mục theo ID
                    var category = dbContext.Categories.Find(categoryId);
                    if (category == null)
                    {
                        context.Errors.Add(new ExecutionError("Category not found."));
                        return null;
                    }

                    // Cập nhật thông tin danh mục
                    category.Name = categoryInput.Name;
                    category.Icon = categoryInput.Icon;
                    category.TotalProduct = categoryInput.TotalProduct;

                    dbContext.Categories.Update(category);
                    dbContext.SaveChanges();

                    return category; // Trả về danh mục đã được cập nhật
                }
            );
            Field<BooleanGraphType>(
                "deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" }
                ),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");

                    // Tìm Product theo ID
                    var product = dbContext.Products.Find(productId);
                    if (product == null)
                    {
                        context.Errors.Add(new ExecutionError("Product not found."));
                        return false;
                    }

                    // Xóa Product
                    dbContext.Products.Remove(product);
                    dbContext.SaveChanges();

                    return true; // Trả về true nếu xóa thành công
                }
            );
            Field<ProductType>(
                "updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "productId" },
                    new QueryArgument<NonNullGraphType<ProductInputType>> { Name = "product" }
                ),
                resolve: context =>
                {
                    var productId = context.GetArgument<int>("productId");
                    var productInput = context.GetArgument<Product>("product");

                    // Tìm Product theo ID
                    var product = dbContext.Products.Find(productId);
                    if (product == null)
                    {
                        context.Errors.Add(new ExecutionError("Product not found."));
                        return null;
                    }

                    // Cập nhật thông tin Product
                    product.Name = productInput.Name;
                    product.Thumbnail = productInput.Thumbnail;
                    product.Price = productInput.Price;
                    product.TimeUp = productInput.TimeUp;
                    product.CategoryId = productInput.CategoryId;
                    product.DetailId = productInput.DetailId;
                    product.Hot = productInput.Hot;
                    product.UserId = productInput.UserId;

                    dbContext.Products.Update(product);
                    dbContext.SaveChanges();

                    return product; // Trả về Product đã được cập nhật
                }
            );

        }
    }
}
