using GraphiQl;
using GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using tv.api.Data;
using tv.api.GraphData;

namespace tv.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddDbContext<TVDbContext>(options => options.UseInMemoryDatabase(databaseName: "tvdb"));

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddTransient<ShowType>();
            services.AddTransient<EpisodeType>();
            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<TVSchema>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                using (var dbContext = scope.ServiceProvider.GetRequiredService<TVDbContext>())
                {
                    int sid = 1;
                    int eid = 1;

                    var fen1 = 1;
                    var fen2 = 1;
                    var theFlash = new Show { Id = sid++, Name = "The Flash" };
                    var theFlashEpisodes = new List<Episode> {
                        new Episode { Id = eid++, ShowId = 1, Name = "Pilot", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Fastest Man Alive", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Things You Can't Outrun", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Going Rogue", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Plastique", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Flash is Born", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Flash vs. Arrow", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Man in the Yellow Suit", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Revenge of the Rogues", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Sound and the Fury", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Crazy for You", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Nuclear Man", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Fallout", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Out of Time", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Rogue Time", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Tricksters", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Who Is Harrison Wells?", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Trap", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Grodd Lives", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Rogue Air", SeasonNumber = 1, EpisodeNumber = fen1++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Fast Enough", SeasonNumber = 1, EpisodeNumber = fen1++ },

                        new Episode { Id = eid++, ShowId = 1, Name = "The Man Who Saved Central City", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Flash of Two Worlds", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Family of Rogues", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Fury of Firestorm", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Darkness and the Light", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Enter Zoom", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Gorilla Warfare", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Legends of Today", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Running to Stand Still", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Potential Energy", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Reverse-Flash Returns", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Fast Lane", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Welcome to Earth-2", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Escape from Earth-2", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "King Shark", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Trajectory", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Flash Back", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Versus Zoom", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Back to Normal", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Rupture", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Runaway Dinosaur", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "Invincible", SeasonNumber = 2, EpisodeNumber = fen2++ },
                        new Episode { Id = eid++, ShowId = 1, Name = "The Race of His Life", SeasonNumber = 2, EpisodeNumber = fen2++ },
                    };

                    foreach (var e in theFlashEpisodes)
                        theFlash.Episodes.Add(e);

                    dbContext.Shows.Add(theFlash);
                    dbContext.Episodes.AddRange(theFlashEpisodes);

                    var arrow = new Show { Id = sid++, Name = "Arrow" };
                    var arrowEpisodes = new List<Episode> {
                        new Episode { Id = eid++, ShowId = sid, Name = "Pilot", SeasonNumber = 1, EpisodeNumber = 1 },
                        new Episode { Id = eid++, ShowId = sid, Name = "Honor Thy Father", SeasonNumber = 1, EpisodeNumber = 2 },
                        new Episode { Id = eid++, ShowId = sid, Name = "Lone Gunmen", SeasonNumber = 1, EpisodeNumber = 3 }
                    };

                    foreach (var e in arrowEpisodes)
                        arrow.Episodes.Add(e);

                    dbContext.Shows.Add(arrow);
                    dbContext.Episodes.AddRange(arrowEpisodes);

                    var supergirl = new Show { Id = sid++, Name = "Supergirl" };
                    var supergirlEpisodes = new List<Episode> {
                        new Episode { Id = eid++, ShowId = sid, Name = "Pilot", SeasonNumber = 1, EpisodeNumber = 1 },
                        new Episode { Id = eid++, ShowId = sid, Name = "Stronger Together", SeasonNumber = 1, EpisodeNumber = 2 },
                        new Episode { Id = eid++, ShowId = sid, Name = "Fight or Flight", SeasonNumber = 1, EpisodeNumber = 3 }
                    };

                    foreach (var e in supergirlEpisodes)
                        supergirl.Episodes.Add(e);

                    dbContext.Shows.Add(supergirl);
                    dbContext.Episodes.AddRange(supergirlEpisodes);

                    dbContext.SaveChanges();
                }
            }

            app.UseGraphiQl("/graphql");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

