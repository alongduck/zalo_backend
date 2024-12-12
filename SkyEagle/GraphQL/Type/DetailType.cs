using GraphQL.Types;
using zalo_server.SkyModel;

namespace zalo_server.SkyEagle.GraphQL
{
    // Định nghĩa DetailType cho GraphQL
    public class DetailType : ObjectGraphType<Detail>
    {
        public DetailType()
        {
            Field(x => x.Id).Description("ID của chi tiết");
            Field(x => x.Description, nullable: true).Description("Mô tả chi tiết");
            Field(x => x.Features, nullable: true).Description("Tính năng sản phẩm");
            Field(x => x.Address, nullable: true).Description("Địa chỉ");
            Field(x => x.Images, nullable: true).Description("Hình ảnh sản phẩm");
            Field(x => x.Details, nullable: true).Description("Chi tiết sản phẩm");
        }
    }
}
