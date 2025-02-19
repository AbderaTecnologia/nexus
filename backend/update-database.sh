#!/usr/bin/env bash

# Caminho para os projetos
AuthProject="modules/Nexus.Auth/src/Nexus.Auth.Infra"
AuthProjectStartup="modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj"
CadastroProject="modules/Nexus.Cadastro/src/Nexus.Cadastro.Infra"
CadastroProjectStartup="modules/Nexus.Cadastro/src/Nexus.Cadastro.Api/Nexus.Cadastro.Api.csproj"

# Função para aplicar migrações
update_database() {
    local project_path=$1
    local startup_project=$2
    echo "Aplicando migrações para o projeto $project_path..."
    dotnet ef database update --project "$project_path" --startup-project "$startup_project"
}

# Aplica as migrações para o projeto de autenticação
echo "Atualizando banco de dados para o projeto de autenticação..."
update_database "$AuthProject" "$AuthProjectStartup"

# Aplica as migrações para o projeto de cadastro
echo "Atualizando banco de dados para o projeto de cadastro..."
update_database "$CadastroProject" "$CadastroProjectStartup"

echo "Processo de atualização do banco de dados concluído!"