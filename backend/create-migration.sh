#!/bin/bash

# Nome da migração
MigrationName=$1

# Verifica se o nome da migração foi fornecido
if [ -z "$MigrationName" ]; then
    echo "Uso: ./create-migration.sh <nome-da-migracao>"
    exit 1
fi

# Caminho para os projetos
AuthProject="modules/Nexus.Auth/src/Nexus.Auth.Infra"
AuthProjectStartup="modules/Nexus.Auth/src/Nexus.Auth.Api/Nexus.Auth.Api.csproj"
CadastroProject="modules/Nexus.Cadastro/src/Nexus.Cadastro.Infra"
CadastroProjectStartup="modules/Nexus.Cadastro/src/Nexus.Cadastro.Api/Nexus.Cadastro.Api.csproj"

# Função para criar e aplicar migrações
CreateAndApplyMigration() {
    projectPath=$1
    migrationName=$2
    startupProject=$3

    migrationResult=$(dotnet ef migrations add "$migrationName" --project "$projectPath" --startup-project "$startupProject" 2>&1)

    if [[ "$migrationResult" == *"No changes were found"* ]]; then
        echo "Nenhuma alteração encontrada para o projeto $projectPath. Nenhuma migração criada."
    elif [[ "$migrationResult" == *"The name '$migrationName' is already used"* ]]; then
        echo "Já existe uma migração com o nome '$migrationName' no projeto $projectPath."
    else
        echo "Aplicando migrações para o projeto $projectPath..."
        dotnet ef database update --project "$projectPath" --startup-project "$startupProject"
    fi
}

# Cria e aplica a migração para o projeto de autenticação
echo "Criando migração para o projeto de autenticação..."
CreateAndApplyMigration "$AuthProject" "$MigrationName" "$AuthProjectStartup"

# Cria e aplica a migração para o projeto de cadastro
echo "Criando migração para o projeto de cadastro..."
CreateAndApplyMigration "$CadastroProject" "$MigrationName" "$CadastroProjectStartup"

echo "Processo de migração concluído!"