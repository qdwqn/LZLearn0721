using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LZLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //通过使用CreateDefaultBuilder函数来创建并且运行了一个虚拟网站托管主机WebHost，
        /*
         * CreateDefaultBuilder做的四件事：
         * （1）加载主机和应用程序的配置信息
         * （2）配置日志记录
         * （3）设置web服务器
         * （4）设置Asp.Net Core应用程序的托管请示
         * 
         * 在最后一行的泛型函数中，泛型类型指定为Startup类，Asp.Net Core的配置信息，如注入依赖、配置中间件、处理请求通道，
         * 都会使用Startup类来进行管理
             */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
