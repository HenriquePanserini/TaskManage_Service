# Usar a imagem oficial do SQL Server
FROM mcr.microsoft.com/mssql/server:2019-latest
# Expõe a porta padrão do SQL Server
EXPOSE 1433
# Copiar os arquivos de migração e dataset para o contêiner (ajustar caminho conforme necessário)
COPY ./TaskManageH.Infraestrutura/Migrations/ /home/database/
# Script de inicialização (caso tenha algo específico para SQL Server)
COPY ./TaskManageH.WebService/CI/init_database.sh /usr/src/app/init_database.sh
