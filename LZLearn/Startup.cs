using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LZLearn
{
    /*
     * Startup类由DotNet Core SDK默认生成，主要有两个作用：
     * （1）在ConfigureServices中注入各种服务组件的依赖
     * （2）在congfigure方法中创建中间件，设置请求通道RequestPipe
     
         */
    public class Startup
    {
        /*
         * 在运行时被调用，管理组件服务依赖
         * .Asp.Net Core提供了内置的IOC容器，
         * 该ConfigureServices用来将我们自己的服务Service注入到IOC容器中
         * 注入容器方法：利用函数的参数IServiceCollection进行注入，
         * 注入的两种方法：
         * （1）自定义服务注入
         * （2）DotNet Core自带服务的注入
         * 两种方法的注入过程略有不同
         
        */
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //注入MVC服务
            services.AddMvc();

        }

        /*
         * 用来配置系统的Http请求通道Request Pipeline
         * 请求通道：有人访问网站时，访问都是以Http请求方式传入系统，请求传递过程中
         * 首先对请求进行检查和处理，如：
         * 检查该用户是否登录，
         * 检查URL路径是否正确
         * 访问出错时，抛出异常等
         * 
         * 在Configure函数中，http请求是由中间件MiddleWare处理，每个中间件接收上一个中间件的输出，并把自己的处理结果传给下一个中间件，
         * 通过对中间件有顺序的组合排列，形成Http请求处理的管道RequestPipeLine
         * 
         * 中间件：组装到应用程序管道中，用来处理请求和响应的软件。Asp.Net Core自带许多中间件，如：
         * 调用开始<——>Logging<——>Static Files<——>MVC，
         * 其中MVC作为终端中间件，可对请求进行短路处理，即请求对象来到MVC后，
         * 不会再调用其他中间件，直接在此处理后，Return
         * 所以，一般来说，程序中调用的最后一个中间件基本是App.UseMvc
         
             */

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        /*
         * 中间件及请求通道的解释：
         * （1）请求通道由IApplicationBuilder创建
         * （2）每个中间件都可以截获、修改、传递请求对象，输出响应对象
         * （3）特定情况下，某些中间件可做短路处理，直接向前端输出相应对象，如下（例1）
         * 
         * Configure函数第二个参数：
         * 实际开发中，常将环境分为开发环境、集成环境、测试环境、预发布环境、生产环境
         */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //例：app.Map创建映射URL的中间件,并作短路处理
            /*
             * Map两个参数，第一个是URL字符串，第二个是是请求的处理对象Action
             * 第二个参数使用Lambda表达式来对请求进行处理
             */
            app.Map("/test", build =>
             {
                 //函数体内嵌套Run中间件来处理短路请求对象
                 build.Run(async context =>
                 {
                     //异步等待Context完成响应操作
                     await context.Response.WriteAsync("Hello from test");
                 });
             });

            //例1：App.Run中间件截获请求对象后，直接向前端输出Hello World
            //任何在App.Run之后的代码不会被执行
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            //所有中间件共用一个请求通道，中间件对请求的处理紧密结合；不同中间件之间还可以通过嵌套产生更强大处理能力
            //每个中间件截获的请求对象都来自于上一个中间件所输出的响应对象，所以在管道设置上有一定的顺序要求
        }
    }
}
