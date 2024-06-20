using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SGED.Context;
using SGED.Repositories.Entities;
using SGED.Repositories.Interfaces;
using SGED.Services.Entities;
using SGED.Services.Interfaces;
using System.Text.Json.Serialization;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerUI;
using SGED.Services.Server.Tasks;
using SGED.Objects.Utilities;
using SGED.Services.Server.Middleware;
using SGED.Services.Server.Attributes;
using SGED.Objects.Server;
using System;

namespace SGED
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configura��o do banco de dados
            services.AddDbContext<AppDBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // Configura��o do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SGED", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Enter 'Bearer' [space] your token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            // Configura��o da autentica��o JWT
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    SecurityEntity securityEntity = new SecurityEntity();
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = securityEntity.Issuer,
                        ValidAudience = securityEntity.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityEntity.Key)),
                    };
                });

            services.AddControllers().AddJsonOptions(
                c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000", "http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireClaim("scope", "sged");
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Inje��o de depend�ncias

            // Conjunto: Pessoa

            // Depend�ncia: Municipe
            services.AddScoped<IMunicipeRepository, MunicipeRepository>();
            services.AddScoped<IMunicipeService, MunicipeService>();

            // Depend�ncia: Fiscal
            services.AddScoped<IFiscalRepository, FiscalRepository>();
            services.AddScoped<IFiscalService, FiscalService>();

            // Depend�ncia: Engenheiro
            services.AddScoped<IEngenheiroRepository, EngenheiroRepository>();
            services.AddScoped<IEngenheiroService, EngenheiroService>();

            // Depend�ncia: Tipo Usu�rio
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<ITipoUsuarioService, TipoUsuarioService>();

            // Depend�ncia: Usu�rio
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            // Depend�ncia: Sess�o
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<ISessaoService, SessaoService>();


            // Conjunto: Im�vel

            // Depend�ncia: Estado
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            services.AddScoped<IEstadoService, EstadoService>();

            // Depend�ncia: Cidade
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<ICidadeService, CidadeService>();

            // Depend�ncia: Bairro
            services.AddScoped<IBairroRepository, BairroRepository>();
            services.AddScoped<IBairroService, BairroService>();

            // Depend�ncia: TipoLogradouro
            services.AddScoped<ITipoLogradouroRepository, TipoLogradouroRepository>();
            services.AddScoped<ITipoLogradouroService, TipoLogradouroService>();

            // Depend�ncia: Logradouro
            services.AddScoped<ILogradouroRepository, LogradouroRepository>();
            services.AddScoped<ILogradouroService, LogradouroService>();

            // Depend�ncia: Im�vel
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<IImovelService, ImovelService>();


            // Conjunto: Aliemnta��o do Im�vel

            // Depend�ncia: Topografia
            services.AddScoped<ITopografiaRepository, TopografiaRepository>();
            services.AddScoped<ITopografiaService, TopografiaService>();

            // Depend�ncia: Tipo Uso
            services.AddScoped<IUsoRepository, UsoRepository>();
            services.AddScoped<IUsoService, UsoService>();

            // Depend�ncia: Ocupa��o Atual
            services.AddScoped<IOcupacaoAtualRepository, OcupacaoAtualRepository>();
            services.AddScoped<IOcupacaoAtualService, OcupacaoAtualService>();

            // Depend�ncia: Tipo Infraestrutura
            services.AddScoped<ITipoInfraestruturaRepository, TipoInfraestruturaRepository>();
            services.AddScoped<ITipoInfraestruturaService, TipoInfraestruturaService>();

            // Depend�ncia: Infraestrutura
            services.AddScoped<IInfraestruturaRepository, InfraestruturaRepository>();
            services.AddScoped<IInfraestruturaService, InfraestruturaService>();

            // Depend�ncia: Instala�ao
            services.AddScoped<IInstalacaoRepository, InstalacaoRepository>();
            services.AddScoped<IInstalacaoService, InstalacaoService>();


            // Conjunto: Processo

            // Depend�ncia: TipoProcesso
            services.AddScoped<ITipoProcessoRepository, TipoProcessoRepository>();
            services.AddScoped<ITipoProcessoService, TipoProcessoService>();

            // Depend�ncia: Etapa
            services.AddScoped<IEtapaRepository, EtapaRepository>();
            services.AddScoped<IEtapaService, EtapaService>();

            // Depend�ncia: Tipo Documento
            services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
            services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

            // Depend�ncia: Tipo Documento Etapa
            services.AddScoped<ITipoDocumentoEtapaRepository, TipoDocumentoEtapaRepository>();
            services.AddScoped<ITipoDocumentoEtapaService, TipoDocumentoEtapaService>();


            // Conjunto: Servidor

            // Task: Fechar Sess�o
            services.AddHostedService<SessionCleanupService>();

            // Task: Remover Sess�es
            services.AddHostedService<RemoveSessionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sua API V1");
                    // Adicione essas linhas para habilitar o bot�o "Authorize"
                    c.DocExpansion(DocExpansion.None);
                    c.DisplayRequestDuration();
                    c.EnableDeepLinking();
                    c.EnableFilter();
                    c.ShowExtensions();
                    c.EnableValidator();
                    c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Delete);
                    c.OAuthClientId("swagger-ui");
                    c.OAuthAppName("Swagger UI");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}