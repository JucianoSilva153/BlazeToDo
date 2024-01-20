# Estágio de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app

# Copiar arquivos necessários para restaurar pacotes
COPY ["/*.sln", "./"]
COPY ["/*.csproj", "./BlazeTodo/"]
WORKDIR /app/BlazeTodo
# Restaurar pacotes
RUN dotnet restore

# Copiar todo o resto do projeto e publicar
COPY . .
RUN dotnet publish -c Release -o out

# Estágio final
FROM nginx:latest
WORKDIR /usr/share/nginx/html

# Copiar arquivos estáticos da aplicação ASP.NET Core
COPY --from=build /app/BlazeTodo/out/wwwroot .

# Copiar configuração do Nginx
COPY nginx.config /etc/nginx/nginx.conf

# Expor porta 8080
EXPOSE 8080
