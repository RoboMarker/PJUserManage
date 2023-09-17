using UserManageRepository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using UserManageRepository.Repository;
using UserManageRepository.Repository.Interface;
using PJUserManage;
using Microsoft.EntityFrameworkCore;
using UserManageRepository.Models.Data;

namespace UserManageRepository
{
    public class BuilderExtender
    {
        public static void AddDbContexts(WebApplicationBuilder? builder)
        {
            builder.Services.AddDbContext<dbCustomDbSampleContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Scoped：注入的物件在同一Request中，參考的都是相同物件(你在Controller、View中注入的IDbConnection指向相同參考)
            builder.Services.AddScoped<IDbConnection, SqlConnection>(serviceProvider => {
                SqlConnection conn = new SqlConnection();
                //指派連線字串
                conn.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                return conn;
            });
            //  builder.Services.AddScoped<IConfiguration>(_ => builder.Configuration.GetConnectionString("DefaultConnection"));
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IBaseRepository<Menu>, BaseRepository<Menu>>();
            builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            builder.Services.AddSingleton(builder.Configuration);

            //builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();
            builder.Services.AddScoped<IMenuPermissionsRepository, MenuPermissionsRepository>();
        }
    }
}
