using elevator_control_system.IServices;
using elevator_control_system.Services;

namespace elevator_control_system
{
    public class Startup
    {
        public void Configureservices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddTransient<IElevator, Elevator>();

          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controller endpoints
            });
            

        }
    }
}
